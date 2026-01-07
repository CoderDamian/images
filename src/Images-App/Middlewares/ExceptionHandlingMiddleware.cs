using Images_App.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Images_App.Middlewares
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            _logger.LogError(ex.Message);

            ProblemDetails problem = ex switch
            {
                DomainException => new()
                {
                    Title = "Business rule violation",
                    Status = StatusCodes.Status422UnprocessableEntity,
                    Detail = ex.Message,
                    Type = "https://example.com/problems/business-rule"
                },
                _ => new()
                {
                    Title = "Internal server error",
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = "An unexpected error occurred",
                    Type = "https://example.com/problems/internal-error"
                }
            };

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = problem.Status!.Value;

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
