// *********************************************************************************
//	<copyright file="BulletinAiController.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>The Bulletin AI Controller Class.</summary>
// *********************************************************************************

namespace IBBS.AI.API.Controllers
{
    using System.Globalization;
    using IBBS.AI.Business.Contracts;
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
        public async Task<string> RewriteTextAsync(RewriteRequestDTO requestDto)
        {
            try
            {
                this._logger.LogInformation(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodStart, nameof(RewriteTextAsync), DateTime.UtcNow));
                {
                    var result = await this._bulletinAiServices.RewriteTextAsync(requestDto.Story).ConfigureAwait(false);
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


