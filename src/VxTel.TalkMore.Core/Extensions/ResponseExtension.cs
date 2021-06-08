using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using VxTel.TalkMore.Core.DomainObjects;

namespace VxTel.TalkMore.Core.Extensions
{
	public static class ResponseExtension
	{
		private static ObjectResult _response;

		public static IActionResult ToResponse(this object result)
		{
			_response = new ObjectResult(new { Success = true, Data = result });
			_response.StatusCode = (int)HttpStatusCode.OK;
			return _response;
		}

		public static IActionResult ToResponseError(this Exception exception)
		{
			var error = new
			{
				Success = false,
				ErrorMessages = new List<Error>()
				{
					new Error(exception.HResult.ToString(), exception.Message)
				}
			};

			_response = new ObjectResult(error);
			_response.StatusCode = (int)HttpStatusCode.InternalServerError;

			return _response;
		}

		public static object ToResponseError(this ValidationException exception)
		{
			var error = new
			{
				Success = false,
				ErrorMessages = new List<Error>()
				{
					new Error(exception.HResult.ToString(), exception.Errors.FirstOrDefault().ErrorMessage)
				}
			};

			return error;
		}
	}
}