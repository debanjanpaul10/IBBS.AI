// *********************************************************************************
//	<copyright file="PluginHelpers.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Plugin helpers.</summary>
// *********************************************************************************
namespace IBBS.AI.Business.Plugins
{
    /// <summary>
    /// Plugin helpers.
    /// </summary>
    public static class PluginHelpers
    {
        /// <summary>
        /// Rewrite user story plugin.
        /// </summary>
        public static class RewriteUserStoryPlugin
        {
            /// <summary>
            /// The function name.
            /// </summary>
            public const string FunctionName = nameof(RewriteUserStoryPlugin);

            /// <summary>
            /// The function description.
            /// </summary>
            public const string FunctionDescription = "Rewrites a user story to be clearer, more concise, and actionable.";

            /// <summary>
            /// The function instructions.
            /// </summary>
            public const string FunctionInstructions = """
            You are an assistant tasked with modifying what user has written based on the following parameters:
                1. Users will be giving you an experience or story and you will be modifying and cleaning the story.
                2. Ensure that the modified response sounds natural and align's with the user's original intent and story.
                3. Pay attention to the user's story and intent and based on that only modify the content.
                4. If the story contains gramatical errors, fix them subtly.
                5. You will only return the fixed output and nothing else.

                Input:
                ++++++++++++

                {{$input}}

                +++++++++++
            """;

            /// <summary>
            /// The input description.
            /// </summary>
            public const string InputDescription = "The user story text to rewrite";
        }
    }

}

