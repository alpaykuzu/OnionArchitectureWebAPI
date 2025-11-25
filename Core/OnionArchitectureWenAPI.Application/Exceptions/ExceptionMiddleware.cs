using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace OnionArchitectureWebAPI.Application.Exceptions
{
    internal class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
			try
			{
				await next(httpContext);
            }
			catch (Exception ex)
			{
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            if(exception is ValidationException validationException)
            {
                List<string> validationErrors = validationException.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return httpContext.Response.WriteAsync(new ExceptionModel
                {
                    StatusCode = statusCode,
                    Errors = validationErrors
                }.ToString());
            }

            List<string> errors = new()
            {
                exception.Message,
                exception.InnerException?.ToString()
            };

            return httpContext.Response.WriteAsync(new ExceptionModel
            {
                StatusCode = statusCode,
                Errors = errors.Where(e => e != null)
            }.ToString());
        }
        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                ForbiddenException => StatusCodes.Status403Forbidden,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
