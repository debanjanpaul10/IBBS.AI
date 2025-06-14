// *********************************************************************************
//	<copyright file="ConfigurationConstants.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>The Configuration Constants Class.</summary>
// *********************************************************************************

namespace IBBS.AI.Shared.Constants
{
        /// <summary>
        /// Configuration constants.
        /// </summary>
        public static class ConfigurationConstants
        {
                /// <summary>
                /// The gemini api key constant.
                /// </summary>
                public const string GeminiAPIKeyConstant = "GeminiAPIKey";

                /// <summary>
                /// The app configuration endpoint key.
                /// </summary>
                public const string AppConfigurationEndpointKeyConstant = "AppConfigurationEndpoint";

                /// <summary>
                /// The managed identity client id constant.
                /// </summary>
                public const string ManagedIdentityClientIdConstant = "ManagedIdentityClientId";

                /// <summary>
                /// The base configuration app config key constant.
                /// </summary>
                public const string BaseConfigurationAppConfigKeyConstant = "BaseConfiguration";

                /// <summary>
                /// The ibbs ai app config key constant.
                /// </summary>
                public const string IbbsAIAppConfigKeyConstant = "IBBS.AI";


                /// <summary>
                /// The gemini ai model id constant.
                /// </summary>
                public const string GeminiAiModelIdConstant = "GeminiAiModelId";

                /// <summary>
                /// The local appsetings file name.
                /// </summary>
                public const string LocalAppsetingsFileName = "appsettings.development.json";

                /// <summary>
                /// The ibbs ai ad client id constant.
                /// </summary>
                public const string IbbsAiAdClientIdConstant = "IbbsAiApiClientId";

                /// <summary>
                /// The ibbs ai ad client secret constant.
                /// </summary>
                public const string IbbsAiAdClientSecretConstant = "IbbsAiClientSecret";

                /// <summary>
                /// The token format url.
                /// </summary>
                public const string TokenFormatUrl = "https://login.microsoftonline.com/{0}/v2.0";

                /// <summary>
                /// The azure ad tenant id constant.
                /// </summary>
                public const string AzureAdTenantIdConstant = "TenantId";

        }
}