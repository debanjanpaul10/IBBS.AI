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
	using IBBS.AI.Shared.DTO;
	using Microsoft.SemanticKernel;
	using Newtonsoft.Json;

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
			var aiMetadata = result.Metadata;

			return JsonConvert.SerializeObject(new RewriteResponseDTO
			{
				RewrittenStory = result.GetValue<string>() ?? string.Empty,
				TotalTokensConsumed = Convert.ToInt32(aiMetadata?[PromptsConstants.TotalTokenCountConstant] ?? 0),
				CandidatesTokenCount = Convert.ToInt32(aiMetadata?[PromptsConstants.CandidatesTokenCountConstant] ?? 0),
				PromptTokenCount = Convert.ToInt32(aiMetadata?[PromptsConstants.PromptTokenCountConstant] ?? 0)
			});
		}
	}
}


