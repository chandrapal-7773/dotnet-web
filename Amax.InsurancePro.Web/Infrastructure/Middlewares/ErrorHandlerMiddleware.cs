namespace Amax.InsurancePro.Web.Infrastructure.Middlewares;

using Amax.InsurancePro.Web.Models;
using Microsoft.AspNetCore.Http;
using Refit;
using System;

using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

public class ErrorHandlerMiddleware
{
	private readonly RequestDelegate _next;

	public ErrorHandlerMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception error)
		{
			var response = context.Response;
			response.ContentType = "application/json";

			var content = new ErrorResponse
			{
				Code = 500,
				Message = "Uncaught Exception!",
			};

			switch (error)
			{
				case ApiException e:
					//TODO separate handler for api exceptions
					response.StatusCode = (int)e.StatusCode;
					try
					{
						content = JsonSerializer.Deserialize<ErrorResponse>(e.Content);
					}catch(Exception ex)
					{
						content.Code = (int)e.StatusCode;
						content.Message = e.Message;
					}
					
					break;
				//case ValidationException e:
				//	response.StatusCode = (int)HttpStatusCode.BadRequest;
				//	errResponse.ValidationErrors = e.Errors.ToList()
				//		.Select(e => new ValidationError
				//		{
				//			PropertyName = e.PropertyName,
				//			ErrorMessage = e.ErrorMessage
				//		})
				//		.ToList();
				//	break;
				//case ResourceNotFoundException e:
				//	response.StatusCode = e.Code;
				//	break;
				//case BusinessException e:
				//	response.StatusCode = e.Code;
				//	break;
				//case AppException e:
				//	response.StatusCode = (int)HttpStatusCode.BadRequest;
				//	break;
				default:
					response.StatusCode = (int)HttpStatusCode.InternalServerError;
					content.Code = response.StatusCode;
					content.Message = error.Message;
					break;
			}



			var result = JsonSerializer.Serialize(content);
			await response.WriteAsync(result);
		}
	}
}