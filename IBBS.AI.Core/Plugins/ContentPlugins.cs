// *********************************************************************************
//	<copyright file="ContentPlugins.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>The Content Plugins.</summary>
// *********************************************************************************

namespace IBBS.AI.Core.Plugins
{
	using IBBS.AI.Shared.Constants;
	using IBBS.AI.Shared.DTO;
	using Microsoft.SemanticKernel;
	using Newtonsoft.Json;
	using System.ComponentModel;
	using static PluginHelpers.ContentPlugins;

	/// <summary>
	/// The Content Plugins.
	/// </summary>
	public class ContentPlugins
	{
		/// <summary>
		/// Executes the generate tag for story plugin asynchronous.
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		/// <param name="input">The input.</param>
		/// <returns>The AI response.</returns>
		[KernelFunction(name: GenerateGenreTagForStoryPlugin.FunctionName)]
		[Description(description: GenerateGenreTagForStoryPlugin.FunctionDescription)]
		public static async Task<string> ExecuteGenerateTagForStoryPluginAsync(
			Kernel kernel, [Description(GenerateGenreTagForStoryPlugin.InputDescription)]string input)
		{
			var arguments = new KernelArguments
			{{
				AiConstants.KernelArgumentsInputConstant, input
			}};

			var result = await kernel.InvokePromptAsync(GenerateGenreTagForStoryPlugin.FunctionInstructions, arguments).ConfigureAwait(false);
			var aiMetadata = result.Metadata;

			return JsonConvert.SerializeObject(new TagResponseDTO
			{
				UserStoryTag = result.GetValue<string>() ?? string.Empty,
				TotalTokensConsumed = Convert.ToInt32(aiMetadata?[AiConstants.TotalTokenCountConstant] ?? 0),
				CandidatesTokenCount = Convert.ToInt32(aiMetadata?[AiConstants.CandidatesTokenCountConstant] ?? 0),
				PromptTokenCount = Convert.ToInt32(aiMetadata?[AiConstants.PromptTokenCountConstant] ?? 0)
			});
		}

		/// <summary>
		/// Executes the content moderation plugin.
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		/// <param name="input">The input.</param>
		/// <returns>The AI response.</returns>
		[KernelFunction(name: ContentModerationPlugin.FunctionName)]
		[Description(description: ContentModerationPlugin.FunctionDescription)]
		public static async Task<string> ExecuteContentModerationPlugin(
			Kernel kernel, [Description(ContentModerationPlugin.InputDescription)] string input)
		{
			var arguments = new KernelArguments
			{{
				AiConstants.KernelArgumentsInputConstant, input
			}};

			var result = await kernel.InvokePromptAsync(ContentModerationPlugin.FunctionInstructions, arguments).ConfigureAwait(false);
			var aiMetadata = result.Metadata;

			return JsonConvert.SerializeObject(new ModerationContentResponseDTO
			{
				ContentRating = result.GetValue<string>() ?? string.Empty,
				TotalTokensConsumed = Convert.ToInt32(aiMetadata?[AiConstants.TotalTokenCountConstant] ?? 0),
				CandidatesTokenCount = Convert.ToInt32(aiMetadata?[AiConstants.CandidatesTokenCountConstant] ?? 0),
				PromptTokenCount = Convert.ToInt32(aiMetadata?[AiConstants.PromptTokenCountConstant] ?? 0)
			});
		}
	}
}
