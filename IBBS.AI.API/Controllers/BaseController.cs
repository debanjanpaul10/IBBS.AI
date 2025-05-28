// *********************************************************************************
//	<copyright file="BaseController.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>The Base Controller Class.</summary>
// *********************************************************************************

namespace IBBS.AI.API.Controllers
{
	using System.Net;
	using IBBS.AI.Shared.DTO;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	/// <summary>
	/// The Base Controller Class.
	/// </summary>
	[Authorize]
	public abstract class BaseController : ControllerBase
	{
		/// <summary>
		/// Handles the success result.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <returns>The ok object result</returns>
		protected OkObjectResult HandleSuccessResult(object response)
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
		protected BadRequestObjectResult HandleBadRequest(string message)
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