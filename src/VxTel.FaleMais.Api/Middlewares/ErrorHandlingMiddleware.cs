using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using VxTel.TalkMore.Core.Extensions;

namespace VxTel.TalkMore.Api.Middlewares
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate next;

		public ErrorHandlingMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			if (exception.GetType() == typeof(ValidationException))
			{
				var code = HttpStatusCode.BadRequest;
				var result = JsonConvert.SerializeObject(((ValidationException)exception).ToResponseError());
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = (int)code;
				return context.Response.WriteAsync(result);
			}
			else
			{
				var code = HttpStatusCode.InternalServerError;
				var result = JsonConvert.SerializeObject(new { isSuccess = false, error = exception.Message });
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = (int)code;
				return context.Response.WriteAsync(result);
			}
		}
	}
}
