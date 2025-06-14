// *********************************************************************************
//	<copyright file="BulletinAIServices.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Bulletin Board AI services interface.</summary>
// *********************************************************************************

namespace IBBS.AI.Core.Services
{
	using IBBS.AI.Core.Contracts;
	using IBBS.AI.Shared.Constants;
	using IBBS.AI.Shared.DTO;
	using Microsoft.Extensions.Logging;
	using Microsoft.SemanticKernel;
	using Newtonsoft.Json;
	using System.Globalization;
	using System.Threading.Tasks;
	using static IBBS.AI.Core.Plugins.PluginHelpers;

	/// <summary>
	/// Bulletin Board AI services class.
	/// </summary>
	/// <param name="logger">The logger</param>
	/// <param name="kernel">The Kernel</param>
	/// <seealso cref="IBulletinAIServices" />
	public class BulletinAIServices(ILogger<BulletinAIServices> logger, Kernel kernel) : IBulletinAIServices
	{
		/// <summary>
		/// The _logger.
		/// </summary>
		private readonly ILogger<BulletinAIServices> _logger = logger;

		/// <summary>
		/// The kernel.
		/// </summary>
		private readonly Kernel _kernel = kernel;

		/// <summary>
		/// Generates the tag for story asynchronous.
		/// </summary>
		/// <param name="story">The story.</param>
		/// <returns>
		/// The genre tag response dto.
		/// </returns>
		public async Task<TagResponseDTO> GenerateTagForStoryAsync(string story)
		{
			try
			{
				this._logger.LogInformation(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodStart, nameof(GenerateTagForStoryAsync), DateTime.UtcNow));
				if (string.IsNullOrEmpty(story))
				{
					var exception = new Exception(LoggingConstants.StoryCannotBeEmptyMessage);
					this._logger.LogError(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(GenerateTagForStoryAsync), DateTime.UtcNow, exception.Message));
					throw exception;
				}

				var kernelArguments = new KernelArguments()
				{
					[AiConstants.KernelArgumentsInputConstant] = story
				};

				var responseFromAI = await this._kernel.InvokeAsync(ContentPlugins.PluginName, ContentPlugins.GenerateGenreTagForStoryPlugin.FunctionName, kernelArguments);
				var response = JsonConvert.DeserializeObject<TagResponseDTO>(responseFromAI.GetValue<string>()!);

				return response ?? new TagResponseDTO();
			}
			catch (Exception ex)
			{
				this._logger.LogError(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(GenerateTagForStoryAsync), DateTime.UtcNow, ex.Message));
				throw;
			}
			finally
			{
				this._logger.LogInformation(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodEnd, nameof(GenerateTagForStoryAsync), DateTime.UtcNow));
			}
		}

		/// <summary>
		/// Moderates the content data asynchronous.
		/// </summary>
		/// <param name="story">The story.</param>
		/// <returns>
		/// The moderation content response dto.
		/// </returns>
		public async Task<ModerationContentResponseDTO> ModerateContentDataAsync(string story)
		{
			try
			{
				this._logger.LogInformation(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodStart, nameof(ModerateContentDataAsync), DateTime.UtcNow));
				if (string.IsNullOrEmpty(story))
				{
					var exception = new Exception(LoggingConstants.StoryCannotBeEmptyMessage);
					this._logger.LogError(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(ModerateContentDataAsync), DateTime.UtcNow, exception.Message));
					throw exception;
				}

				var kernelArguments = new KernelArguments()
				{
					[AiConstants.KernelArgumentsInputConstant] = story
				};

				var responseFromAI = await this._kernel.InvokeAsync(ContentPlugins.PluginName, ContentPlugins.ContentModerationPlugin.FunctionName, kernelArguments);
				var response = JsonConvert.DeserializeObject<ModerationContentResponseDTO>(responseFromAI.GetValue<string>()!);

				return response ?? new ModerationContentResponseDTO();
			}
			catch (Exception ex)
			{
				this._logger.LogError(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(ModerateContentDataAsync), DateTime.UtcNow, ex.Message));
				throw;
			}
			finally
			{
				this._logger.LogInformation(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodEnd, nameof(ModerateContentDataAsync), DateTime.UtcNow));
			}
		}

		/// <summary>
		/// Rewrites text async.
		/// </summary>
		/// <param name="story">The story.</param>
		/// <returns>
		/// The rewrite response dto.
		/// </returns>
		public async Task<RewriteResponseDTO> RewriteTextAsync(string story)
		{
			try
			{
				this._logger.LogInformation(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodStart, nameof(RewriteTextAsync), DateTime.UtcNow));
				if (string.IsNullOrEmpty(story))
				{
					var exception = new Exception(LoggingConstants.StoryCannotBeEmptyMessage);
					this._logger.LogError(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(RewriteTextAsync), DateTime.UtcNow, exception.Message));
					throw exception;
				}

				var kernelArguments = new KernelArguments()
				{
					[AiConstants.KernelArgumentsInputConstant] = story
				};

				var responseFromAI = await this._kernel.InvokeAsync(RewriteTextPlugin.PluginName, RewriteTextPlugin.RewriteUserStoryPlugin.FunctionName, kernelArguments);
				var response = JsonConvert.DeserializeObject<RewriteResponseDTO>(responseFromAI.GetValue<string>()!);

				return response ?? new RewriteResponseDTO();
			}
			catch (Exception ex)
			{
				this._logger.LogError(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(RewriteTextAsync), DateTime.UtcNow, ex.Message));
				throw;
			}
			finally
			{
				this._logger.LogInformation(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodEnd, nameof(RewriteTextAsync), DateTime.UtcNow));
			}
		}
	}
}


