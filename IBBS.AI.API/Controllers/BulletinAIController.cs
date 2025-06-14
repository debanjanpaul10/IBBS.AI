// *********************************************************************************
//	<copyright file="BulletinAiController.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>The Bulletin AI Controller Class.</summary>
// *********************************************************************************

namespace IBBS.AI.API.Controllers
{
	using System.Globalization;
	using IBBS.AI.Core.Contracts;
	using IBBS.AI.Shared.Constants;
	using IBBS.AI.Shared.DTO;
	using Microsoft.AspNetCore.Mvc;

	/// <summary>
	/// The Bulletin AI Controller Class.
	/// </summary>
	/// <param name="bulletinAIServices">The Bulletin AI Services</param>
	/// <param name="logger">The logger</param>
	/// <seealso cref="BaseController"/>
	[ApiController]
	[Route(RouteConstants.AiBase_RoutePrefix)]
	public class BulletinAiController(IBulletinAIServices bulletinAIServices, ILogger<BulletinAiController> logger) : BaseController
	{
		/// <summary>
		/// The bulletin ai services.
		/// </summary>
		private readonly IBulletinAIServices _bulletinAiServices = bulletinAIServices;

		/// <summary>
		/// The logger.
		/// </summary>
		private readonly ILogger<BulletinAiController> _logger = logger;

		/// <summary>
		/// Rewrites the text async.
		/// </summary>
		/// <param name="requestDto">The rewrite request dto.</param>
		/// <returns>The AI rewritten story.</returns>
		/// <exception cref="Exception"></exception>
		[HttpPost]
		[Route(RouteConstants.RewriteText_Route)]
		public async Task<RewriteResponseDTO> RewriteTextAsync(UserStoryRequestDTO requestDto)
		{
			try
			{
				this._logger.LogInformation(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodStart, nameof(RewriteTextAsync), DateTime.UtcNow));
				{
					var result = await this._bulletinAiServices.RewriteTextAsync(requestDto.Story).ConfigureAwait(false);
					if (string.IsNullOrEmpty(result.RewrittenStory))
					{
						var exception = new Exception(LoggingConstants.AiServicesDownMessage);
						this._logger.LogError(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(RewriteTextAsync), DateTime.UtcNow, exception.Message));
						throw exception;
					}
					else
					{
						return result;
					}
				}

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

		/// <summary>
		/// Generates the tag for story asynchronous.
		/// </summary>
		/// <param name="requestDto">The request dto.</param>
		/// <returns>The tag response dto.</returns>
		[HttpPost]
		[Route(RouteConstants.GenerateTag_Route)]
		public async Task<TagResponseDTO> GenerateTagForStoryAsync(UserStoryRequestDTO requestDto)
		{
			try
			{
				this._logger.LogInformation(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodStart, nameof(GenerateTagForStoryAsync), DateTime.UtcNow));
				{
					var result = await this._bulletinAiServices.GenerateTagForStoryAsync(requestDto.Story).ConfigureAwait(false);
					if (string.IsNullOrEmpty(result.UserStoryTag))
					{
						var exception = new Exception(LoggingConstants.AiServicesDownMessage);
						this._logger.LogError(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(GenerateTagForStoryAsync), DateTime.UtcNow, exception.Message));
						throw exception;
					}
					else
					{
						return result;
					}
				}

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
		/// <param name="requestDto">The request dto.</param>
		/// <returns>The moderation content response.</returns>
		[HttpPost]
		[Route(RouteConstants.ModerateContent_Route)]
		public async Task<ModerationContentResponseDTO> ModerateContentDataAsync(UserStoryRequestDTO requestDto)
		{
			try
			{
				this._logger.LogInformation(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodStart, nameof(ModerateContentDataAsync), DateTime.UtcNow));
				{
					var result = await this._bulletinAiServices.ModerateContentDataAsync(requestDto.Story).ConfigureAwait(false);
					if (string.IsNullOrEmpty(result.ContentRating))
					{
						var exception = new Exception(LoggingConstants.AiServicesDownMessage);
						this._logger.LogError(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(ModerateContentDataAsync), DateTime.UtcNow, exception.Message));
						throw exception;
					}
					else
					{
						return result;
					}
				}

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
	}
}


