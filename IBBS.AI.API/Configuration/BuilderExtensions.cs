// *********************************************************************************
//	<copyright file="BuilderExtensions.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Builder extensions.</summary>
// *********************************************************************************

namespace IBBS.AI.API.Configuration
{
    using System.Globalization;
    using System.Security.Claims;
    using Azure.Identity;
    using IBBS.AI.Shared.Constants;
    using IBBS.AI.Business.Contracts;
    using IBBS.AI.Business.Services;
    using IBBS.AI.API.Controllers;
    using Microsoft.Extensions.Configuration.AzureAppConfiguration;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using static IBBS.AI.Shared.Constants.ConfigurationConstants;

    /// <summary>
    /// Builder extensions.
    /// </summary>
    public static class BuilderExtensions
    {
        /// <summary>
        /// Adds azure services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="credentials">The credentials.</param>
        /// <exception cref="InvalidOperationException">InvalidOperationException error.</exception>
        public static void AddAzureServices(this WebApplicationBuilder builder, DefaultAzureCredential credentials)
        {
            var appConfigurationEndpoint = builder.Configuration[AppConfigurationEndpointKeyConstant];
            if (string.IsNullOrEmpty(appConfigurationEndpoint))
            {
                throw new InvalidOperationException(LoggingConstants.MissingConfigurationMessage);
            }

            builder.Configuration.AddAzureAppConfiguration(options =>
            {
                options.Connect(new Uri(appConfigurationEndpoint), credentials)
                .Select(KeyFilter.Any).Select(KeyFilter.Any, BaseConfigurationAppConfigKeyConstant).Select(KeyFilter.Any, IbbsAIAppConfigKeyConstant)
                .ConfigureKeyVault(configure =>
                {
                    configure.SetCredential(credentials);
                });
            });
        }

        /// <summary>
        /// Configures api services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void ConfigureApiServices(this WebApplicationBuilder builder)
        {
            builder.ConfigureAuthenticationServices();
            builder.ConfigureBusinessDependencies();
        }

        /// <summary>
        /// Configures authentication services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private static void ConfigureAuthenticationServices(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = string.Format(CultureInfo.CurrentCulture, TokenFormatUrl, configuration[AzureAdTenantIdConstant]);
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidAudience = configuration[IbbsAiAdClientIdConstant],
                    ValidateLifetime = true,
                };
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = HandleAuthTokenValidationSuccessAsync,
                    OnAuthenticationFailed = HandleAuthTokenValidationFailedAsync
                };
            });

        }

        /// <summary>
        /// Configures business dependencies.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private static void ConfigureBusinessDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton(KernelFactory.CreateKernel(builder.Configuration));
            builder.Services.AddSingleton(KernelFactory.CreateMemory());
            builder.Services.AddScoped<IBulletinAIServices, BulletinAIServices>();
        }

        /// <summary>
        /// Handles auth token validation success async.
        /// </summary>
        /// <param name="context">The token validation context.</param>
        private static async Task HandleAuthTokenValidationSuccessAsync(this TokenValidatedContext context)
        {
            var claimsPrincipal = context.Principal;
            if (claimsPrincipal?.Identity is not ClaimsIdentity claimsIdentity || !claimsIdentity.IsAuthenticated)
            {
                context.Fail(LoggingConstants.InvalidTokenExceptionConstant);
                return;
            }

            context.HttpContext.User = new ClaimsPrincipal(claimsIdentity);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Handles auth token validation failed async.
        /// </summary>
        /// <param name="context">The auth failed context.</param>
        private static async Task HandleAuthTokenValidationFailedAsync(this AuthenticationFailedContext context)
        {
            var authenticationFailedException = new UnauthorizedAccessException(LoggingConstants.InvalidTokenExceptionConstant);
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<BaseController>>();
            logger.LogError(authenticationFailedException, authenticationFailedException.Message);
            await Task.CompletedTask;
        }
    }
}