// *********************************************************************************
//	<copyright file="RewriteTextPlugin.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Rewrite text plugin.</summary>
// *********************************************************************************

namespace IBBS.AI.Business.Plugins
{
	using IBBS.AI.Shared.Constants;
	using IBBS.AI.Shared.DTO;
	using Microsoft.SemanticKernel;
	using Newtonsoft.Json;
	using System.ComponentModel;

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
			var arguments = new KernelArguments
			{{
				PromptsConstants.KernelArgumentsInputConstant, input
			}};

			var result = await kernel.InvokePromptAsync(PluginHelpers.RewriteUserStoryPlugin.FunctionInstructions, arguments).ConfigureAwait(false);
			
			// Get the tokens consumed from the result metadata
			var tokensConsumed = result.Metadata?["TotalTokenCount"] ?? 0;
			
			// Return both the rewritten text and tokens consumed as JSON
			return JsonConvert.SerializeObject(new RewriteResponseDTO
			{
				RewrittenStory = result.GetValue<string>() ?? string.Empty,
				TokensConsumed = Convert.ToInt32(tokensConsumed)
			});
		}
	}
}


