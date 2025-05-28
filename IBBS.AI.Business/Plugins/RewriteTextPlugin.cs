// *********************************************************************************
//	<copyright file="RewriteTextPlugin.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Rewrite text plugin.</summary>
// *********************************************************************************

namespace IBBS.AI.Business.Plugins
{
    using System.ComponentModel;
    using IBBS.AI.Shared.Constants;
    using Microsoft.SemanticKernel;

    /// <summary>
    /// Rewrite text plugin.
    /// </summary>
    public class RewriteTextPlugin
    {
        /// <summary>
        /// Executes rewrite user story async.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="input">The input.</param>
        [KernelFunction(name: PluginHelpers.RewriteUserStoryPlugin.FunctionName)]
        [Description(PluginHelpers.RewriteUserStoryPlugin.FunctionDescription)]
        public static async Task<string> ExecuteRewriteUserStoryAsync(Kernel kernel, [Description(PluginHelpers.RewriteUserStoryPlugin.InputDescription)] string input)
        {
            var arguments = new KernelArguments{{
                PromptsConstants.KernelArgumentsInputConstant, input
            }};

            var result = await kernel.InvokePromptAsync(PluginHelpers.RewriteUserStoryPlugin.FunctionInstructions, arguments).ConfigureAwait(false);
            return result.GetValue<string>() ?? string.Empty;
        }
    }
}


