// *********************************************************************************
//	<copyright file="BuilderExtensions.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Builder extensions.</summary>
// *********************************************************************************

namespace IBBS.AI.API.Configuration
{
    using Azure.Identity;
    using IBBS.AI.Shared.Constants;
    using Microsoft.Extensions.Configuration.AzureAppConfiguration;

    /// <summary>
    /// Builder extensions.
    /// </summary>
    public static class BuilderExtensions
    {
        /// <summary>
        /// Adds azure services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="credential">The credential.</param>
        /// <exception cref="InvalidOperationException">InvalidOperationException error.</exception>
        public static void AddAzureServices(this WebApplicationBuilder builder, DefaultAzureCredential credential)
        {
            var appConfigurationEndpoint = builder.Configuration[ConfigurationConstants.AppConfigurationEndpointKeyConstant];
            if (string.IsNullOrEmpty(appConfigurationEndpoint))
            {
                throw new InvalidOperationException(LoggingConstants.MissingConfigurationMessage);
            }

            builder.Configuration.AddAzureAppConfiguration(options =>
            {
                options.Connect(new Uri(appConfigurationEndpoint), credential)
                .Select(KeyFilter.Any).ConfigureKeyVault(configure =>
                {
                    configure.SetCredential(credential);
                });
            });
        }
    }
}