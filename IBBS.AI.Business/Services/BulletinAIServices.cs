// *********************************************************************************
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
    using IBBS.AI.Shared.DTO;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// Bulletin Board AI services class.
    /// </summary>
    /// <param name="logger">The logger</param>
    /// <param name="configuration">The configuration</param>
    /// <seealso cref="IBulletinAIServices" />
    public class BulletinAIServices(ILogger<BulletinAIServices> logger, IConfiguration configuration, IHttpClientHelper httpClientHelper) : IBulletinAIServices
    {
        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly ILogger<BulletinAIServices> _logger = logger;

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _configuration = configuration;

        /// <summary>
        /// The http client helper.
        /// </summary>
        private readonly IHttpClientHelper _httpClientHelper = httpClientHelper;

        /// <summary>
        /// Rewrites text async.
        /// </summary>
        /// <param name="story">The story.</param>
        /// <exception cref="Exception">Exception error.</exception>
        /// <exception cref="Exception">Exception error.</exception>
        public async Task<string> RewriteTextAsync(string story)
        {
            var path = $"{AppContext.BaseDirectory}/{ConfigurationConstants.PluginsDirectory}/" +
                $"{ConfigurationConstants.RewriteUserStoryPlugin}/{ConfigurationConstants.PromptNameTextFile}";

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(LoggingConstants.PluginNotFoundMessage);
            }

            try
            {
                var prompt = await File.ReadAllTextAsync(path).ConfigureAwait(false);
                var modifiedContent = prompt.Replace(ConfigurationConstants.UserInputInPrompt, story);

                var geminiAiRequest = PrepareGeminiAiRequestDTO(modifiedContent);
                var geminiAiRequestJson = JsonConvert.SerializeObject(geminiAiRequest);

                var geminiApiKey = this._configuration[ConfigurationConstants.GeminiAPIKeyConstant];
                if (string.IsNullOrEmpty(geminiApiKey))
                {
                    throw new ArgumentNullException(LoggingConstants.AiAPIKeyMissingMessage);
                }

                var geminiAiApiUrl = ConfigurationConstants.GeminiAIApiUrl + geminiApiKey;
                var response = await this._httpClientHelper.PostAsync(geminiAiApiUrl, geminiAiRequestJson).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                
                var responseBody = await response.Content.ReadAsStringAsync();
                var aiResponse = PrepareResponseData(responseBody);
                return aiResponse;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, string.Format(CultureInfo.CurrentCulture, LoggingConstants.LogHelperMethodFailed, nameof(RewriteTextAsync), DateTime.UtcNow, ex.Message));
                throw;
            }
        }

        #region PRIVATE Methods

        /// <summary>
        /// Prepares gemini ai request dto.
        /// </summary>
        /// <param name="promptData">The prompt data.</param>
        private static GeminiAiRequestDto PrepareGeminiAiRequestDTO(string promptData)
        {
            var request = new GeminiAiRequestDto
            {
                contents = new List<Content>
                {
                    new Content
                    {
                        parts = new List<Part>
                        {
                            new Part
                            {
                                text = promptData
                            }
                        }
                    }
                }
            };
            return request;
        }

        /// <summary>
        /// Prepares response data.
        /// </summary>
        /// <param name="responseBody">The response body.</param>
        private static string PrepareResponseData(string responseBody)
        {
            var deserializedData = JsonConvert.DeserializeObject<GeminiAiResponseDto>(responseBody);
            var aiResponse = deserializedData?.Candidates?.First()?.Content?.parts?.First()?.text;
            return aiResponse ?? string.Empty;
        }

        #endregion
    }
}


