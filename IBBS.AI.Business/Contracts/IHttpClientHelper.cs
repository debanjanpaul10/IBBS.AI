// *********************************************************************************
//	<copyright file="IHttpClientHelper.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>The HTTP Client Helper Interface.</summary>
// *********************************************************************************

namespace IBBS.AI.Business.Contracts
{
    /// <summary>
    /// Http client helper interface.
    /// </summary>
    public interface IHttpClientHelper
    {
        /// <summary>
        /// Gets async.
        /// </summary>
        /// <param name="url">The url.</param>
        Task<HttpResponseMessage> GetAsync(string url);

        /// <summary>
        /// Posts async.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="data">The data.</param>
        Task<HttpResponseMessage> PostAsync(string url, string data);
    }
}