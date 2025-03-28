// *********************************************************************************
//	<copyright file="Program.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Program class from where the execution starts</summary>
// *********************************************************************************

namespace IBBS.AI.API
{
    using Azure.Identity;
    using IBBS.AI.API.Configuration;
    using IBBS.AI.Business.Contracts;
    using IBBS.AI.Business.Services;
    using IBBS.AI.Shared.Constants;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Program class from where the execution starts
    /// </summary>
    public static class Program
    {
        /// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.development.json", optional: true)
                .AddEnvironmentVariables();

            var miCredentials = builder.Configuration[ConfigurationConstants.ManagedIdentityClientIdConstant];
            var credentials = builder.Environment.IsDevelopment()
                ? new DefaultAzureCredential()
                : new DefaultAzureCredential(new DefaultAzureCredentialOptions
                {
                    ManagedIdentityClientId = miCredentials,
                });

            builder.AddAzureServices(credentials);
            builder.Services.ConfigureServices();

            var app = builder.Build();
            app.ConfigureApplication();
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true
                    };
                });
            services.AddControllers();
            services.AddOpenApi();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddHttpClient<IHttpClientHelper, HttpClientHelper>(client =>
            {
                client.Timeout = TimeSpan.FromMinutes(3);
            });
            services.AddScoped<IBulletinAIServices, BulletinAIServices>();
            services.AddTransient<TokenHelper>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "IBBS.AI API",
                    Version = "v1",
                    Description = "API Documentation for IBBS.AI",
                    Contact = new OpenApiContact
                    {
                        Name = "Debanjan Paul",
                        Email = "debanjanpaul10@gmail.com"
                    }
                });
            });
        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void ConfigureApplication(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "IBBS.AI API v1");
                    c.RoutePrefix = "swaggerui";
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors();
            app.MapControllers();
            app.Run();
        }

    }
}

