// *********************************************************************************
//	<copyright file="PromptsConstants.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Prompts constants.</summary>
// *********************************************************************************

namespace IBBS.AI.Shared.Constants
{
    /// <summary>
    /// Prompts constants.
    /// </summary>
    public static class PromptsConstants
    {
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
    }
}