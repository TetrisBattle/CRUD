using Application.Errors;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Middleware
{
	public class ExceptionMiddleware(IHostEnvironment env) : IMiddleware
	{

		public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
		{
			httpContext.Response.ContentType = "application/json";

			try
			{
				await next(httpContext);
			}
			catch (ValidationException ex)
			{
				await HandleValidationException(httpContext, ex);
			}
			catch (ServiceException ex)
			{
				httpContext.Response.StatusCode = ex.StatusCode;

				var errorResponse = new
				{
					error = ex.ErrorMessage,
					stackTrace = env.IsDevelopment() ? ex.StackTrace : null
				};

				await httpContext.Response.WriteAsJsonAsync(errorResponse);
			}
			catch (Exception ex)
			{
				httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

				var errorResponse = new
				{
					error = "An unexpected error occurred.",
					stackTrace = env.IsDevelopment() ? ex.StackTrace : null
				};

				await httpContext.Response.WriteAsJsonAsync(errorResponse);
			}
		}
		private static async Task HandleValidationException(HttpContext context, ValidationException ex)
		{
			var validationErrors = new Dictionary<string, string[]>();

			if (ex.Errors != null)
			{
				foreach (var error in ex.Errors)
				{
					if (validationErrors.TryGetValue(error.PropertyName, out var existingErrors))
					{
						validationErrors[error.PropertyName] = [.. existingErrors, error.ErrorMessage];
					}
					else
					{
						validationErrors[error.PropertyName] = [error.ErrorMessage];
					}
				}
			}

			context.Response.StatusCode = StatusCodes.Status400BadRequest;

			var validationProblemDetails = new ValidationProblemDetails(validationErrors)
			{
				Title = "Validation error",
			};

			await context.Response.WriteAsJsonAsync(validationProblemDetails);
		}
	}
}
