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
        #region Key Vault Keys Constants

        /// <summary>
        /// The application configuration connection string
        /// </summary>
        public const string AppConfigurationConnectionString = "AppConfig-Connection-kv";

        /// <summary>
        /// The azure open ai app key.
        /// </summary>
        public const string AzureOpenAiAppKey = "AzureOpenAiAppKey-kv";

        /// <summary>
        /// The key vault endpoint constant
        /// </summary>
        public const string KeyVaultEndpointConstant = "KeyVaultUrl";

        #endregion

        #region App Configuration

        /// <summary>
        /// The azure open ai endpoint constant.
        /// </summary>
        public const string AzureOpenAiEndpointConstant = "AzureOpenAiEndpoint";

        /// <summary>
        /// The gemini api key constant.
        /// </summary>
        public const string GeminiAPIKeyConstant = "GeminiAPIKey";

        #endregion

        #region Prompts

        /// <summary>
        /// The plugins directory.
        /// </summary>
        public const string PluginsDirectory = @"Plugins\RewriteTextPlugins";

        /// <summary>
        /// The rewrite plugins.
        /// </summary>
        public const string RewritePlugins = "RewriteTextPlugins";

        /// <summary>
        /// The rewrite user story plugin.
        /// </summary>
        public const string RewriteUserStoryPlugin = "RewriteUserStoryPlugin";

        /// <summary>
        /// The prompt name text file.
        /// </summary>
        public const string PromptNameTextFile = "skprompt.txt";

        /// <summary>
        /// The user input in prompt.
        /// </summary>
        public const string UserInputInPrompt = "{{$input}}";

        #endregion

        #region Misc

        /// <summary>
        /// The bulletin ai client constant.
        /// </summary>
        public const string bulletinAiClientConstant = "bulletinAiClient";

        /// <summary>
        /// The application json constant
        /// </summary>
        public const string ApplicationJsonConstant = "application/json";

        /// <summary>
        /// The gemini ai api url.
        /// </summary>
        public const string GeminiAIApiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=";

        #endregion
    }
}