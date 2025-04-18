﻿// *********************************************************************************
//	<copyright file="BulletinAIServices.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Bulletin Board AI services interface.</summary>
// *********************************************************************************

namespace IBBS.AI.Business.Services
{
    using System.Globalization;
    using System.Threading.Tasks;
    using IBBS.AI.Business.Contracts;
    using IBBS.AI.Shared.Constants;
    using Microsoft.Extensions.Logging;
    using Microsoft.SemanticKernel;

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
        /// Rewrites text async.
        /// </summary>
        /// <param name="story">The story.</param>
        /// <exception cref="Exception">Exception error.</exception>
        /// <exception cref="Exception">Exception error.</exception>
        public async Task<string> RewriteTextAsync(string story)
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
                    [PromptsConstants.KernelArgumentsInputConstant] = story
                };
                
                var responseFromAI = await this._kernel.InvokeAsync(PromptsConstants.RewritePlugins, PromptsConstants.RewriteUserStoryPlugin, kernelArguments);
                return responseFromAI.ToString();
            }
            catch (Exception ex)
            {
                this._logger.LogError(string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(RewriteTextAsync), DateTime.UtcNow, ex.Message));
                throw;
            }
        }
    }
}


