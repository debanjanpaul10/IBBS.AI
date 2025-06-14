// *********************************************************************************
//	<copyright file="RewriteTextPlugin.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Rewrite text plugin.</summary>
// *********************************************************************************

namespace IBBS.AI.Core.Plugins
{
	using System.ComponentModel;
	using IBBS.AI.Shared.Constants;
	using IBBS.AI.Shared.DTO;
	using Microsoft.SemanticKernel;
	using Newtonsoft.Json;
	using static PluginHelpers.RewriteTextPlugin;

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
		[KernelFunction(name: RewriteUserStoryPlugin.FunctionName)]
		[Description(RewriteUserStoryPlugin.FunctionDescription)]
		public static async Task<string> ExecuteRewriteUserStoryAsync(Kernel kernel, [Description(RewriteUserStoryPlugin.InputDescription)] string input)
		{
			var arguments = new KernelArguments
			{{
				AiConstants.KernelArgumentsInputConstant, input
			}};

			var result = await kernel.InvokePromptAsync(RewriteUserStoryPlugin.FunctionInstructions, arguments).ConfigureAwait(false);
			var aiMetadata = result.Metadata;

			return JsonConvert.SerializeObject(new RewriteResponseDTO
			{
				RewrittenStory = result.GetValue<string>() ?? string.Empty,
				TotalTokensConsumed = Convert.ToInt32(aiMetadata?[AiConstants.TotalTokenCountConstant] ?? 0),
				CandidatesTokenCount = Convert.ToInt32(aiMetadata?[AiConstants.CandidatesTokenCountConstant] ?? 0),
				PromptTokenCount = Convert.ToInt32(aiMetadata?[AiConstants.PromptTokenCountConstant] ?? 0)
			});
		}
	}
}


