// *********************************************************************************
//	<copyright file="BaseController.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>The Base Controller Class.</summary>
// *********************************************************************************

namespace IBBS.AI.API.Controllers
{
    using System.Net;
    using IBBS.AI.Shared.Constants;
    using IBBS.AI.Shared.DTO;
    using Microsoft.AspNetCore.Mvc;
    using static IBBS.AI.Shared.Constants.ConfigurationConstants;

    /// <summary>
    /// The Base Controller Class.
    /// </summary>
    /// <param name="configuration">The configuration</param>
    public class BaseController(IConfiguration configuration) : ControllerBase
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _configuration = configuration;

        /// <summary>
		/// Determines whether this instance is authorized.
		/// </summary>
		/// <returns>
		///   <c>true</c> if this instance is authorized; otherwise, <c>false</c>.
		/// </returns>
        public bool IsAuthorized()
        {
            var requestHeaders = this.HttpContext.Request.Headers;
            var acceptableToken = this._configuration[BulletinAITokenConstant];
            if (string.Equals(requestHeaders[BulletinAIAntiforgeryTokenConstant], acceptableToken, StringComparison.Ordinal))
            {
                return true;
            }

            return false;
        }

        /// <summary>
		/// Handles the bad request.
		/// </summary>
		/// <returns>The unauthorized object result</returns>
		public UnauthorizedObjectResult HandleUnAuthorizedRequest()
		{
			var responseData = new ResponseDTO()
			{
				Data = LoggingConstants.UserUnauthorizedMessageConstant,
				StatusCode = (int)HttpStatusCode.Unauthorized,
				IsSuccess = false,
			};
			return this.Unauthorized(responseData);
		}

        /// <summary>
		/// Handles the success result.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <returns>The ok object result</returns>
		public OkObjectResult HandleSuccessResult(object response)
		{
			var responseData = new ResponseDTO()
			{
				Data = response,
				IsSuccess = true,
				StatusCode = (int)HttpStatusCode.OK
			};
			return this.Ok(responseData);
		}

        /// <summary>
		/// Handles the bad request.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <returns>The bad request result.</returns>
		public BadRequestObjectResult HandleBadRequest(string message)
		{
			var responseData = new ResponseDTO()
			{
				Data = message,
				IsSuccess = false,
				StatusCode = (int)HttpStatusCode.BadRequest
			};
			return this.BadRequest(responseData);
		}
    }
}