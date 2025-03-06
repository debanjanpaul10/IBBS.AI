// *********************************************************************************
//	<copyright file="AiBaseController.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>The IBBS AI Base Controller Class.</summary>
// *********************************************************************************

namespace IBBS.AI.API.Controllers
{
    using System.Globalization;
    using IBBS.AI.Business.Contracts;
    using IBBS.AI.Shared.Constants;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
	/// The IBBS AI Base Controller Class.
	/// </summary>
    /// <param name="bulletinAIServices">The Bulletin AI Services</param>
    /// <param name="logger">The logger</param>
    [ApiController]
    [Route(RouteConstants.AiBase_RoutePrefix)]
    public class AiBaseController(IBulletinAIServices bulletinAIServices, ILogger<AiBaseController> logger)
    {
        /// <summary>
        /// The bulletin ai services.
        /// </summary>
        private readonly IBulletinAIServices _bulletinAiServices = bulletinAIServices;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<AiBaseController> _logger = logger;

        /// <summary>
        /// Rewrites the text async.
        /// </summary>
        /// <param name="story">The story that user presents.</param>
        /// <returns>The AI rewritten story.</returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route(RouteConstants.RewriteText_Route)]
        public async Task<string> RewriteTextAsync([FromBody] string story)
        {
            try
            {
                this._logger.LogInformation(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodStart, nameof(RewriteTextAsync), DateTime.UtcNow));
                if (string.IsNullOrEmpty(story))
                {
                    var exception = new Exception(LoggingConstants.StoryCannotBeEmptyMessage);
                    this._logger.LogError(string.Format(
                        CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(RewriteTextAsync), DateTime.UtcNow, exception.Message));
                    throw exception;
                }

                var result = await this._bulletinAiServices.RewriteTextAsync(story).ConfigureAwait(false);
                if (string.IsNullOrEmpty(result))
                {
                    var exception = new Exception(LoggingConstants.AiServicesDownMessage);
                    this._logger.LogError(string.Format(
                        CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(RewriteTextAsync), DateTime.UtcNow, exception.Message));
                    throw exception;
                }
                else
                {
                    return result;
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
    }
}


