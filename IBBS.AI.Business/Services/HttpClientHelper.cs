// *********************************************************************************
//	<copyright file="HttpClientHelper.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>The HTTP Client Helper Class.</summary>
// *********************************************************************************

namespace IBBS.AI.Business.Services
{
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using IBBS.AI.Business.Contracts;
    using IBBS.AI.Shared.Constants;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The HTTP Client Helper Class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="logger">The Logger.</param>
    /// <param name="tokenHelper">The Token Helper</param>
    public class HttpClientHelper(HttpClient httpClient, ILogger<HttpClientHelper> logger, TokenHelper tokenHelper) : IHttpClientHelper
    {
        /// <summary>
        /// The http client.
        /// </summary>
        private readonly HttpClient _httpClient = httpClient;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<HttpClientHelper> _logger = logger;

        /// <summary>
        /// The token helper.
        /// </summary>
        private readonly TokenHelper _tokenHelper = tokenHelper;

        /// <summary>
        /// Gets async.
        /// </summary>
        /// <param name="url">The url.</param>
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            try
            {
                var token = await this._tokenHelper.GetAzureAdTokenAsync();
                this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ConfigurationConstants.BearerConstant, token);
                
                var response = await this._httpClient.GetAsync(new Uri(url)).ConfigureAwait(false);
                return response;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, string.Format(LoggingConstants.LogHelperMethodFailed, nameof(GetAsync), DateTime.UtcNow, ex.Message));
                throw;
            }
        }

        /// <summary>
        /// Posts async.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="data">The data.</param>
        public async Task<HttpResponseMessage> PostAsync(string url, string data)
        {
            try
            {
                var token = await this._tokenHelper.GetAzureAdTokenAsync();
                this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ConfigurationConstants.BearerConstant, token);
                
                var content = new StringContent(data, Encoding.UTF8, ConfigurationConstants.ApplicationJsonConstant);
                var response = await this._httpClient.PostAsync(url, content).ConfigureAwait(false);
                return response;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, string.Format(LoggingConstants.LogHelperMethodFailed, nameof(PostAsync), DateTime.UtcNow, ex.Message));
                throw;
            }
        }
    }
}