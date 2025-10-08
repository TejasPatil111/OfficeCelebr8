using System.Net;
using OfficeCelebr8.Application.Exceptions;

namespace OfficeCelebr8.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");

                HttpStatusCode statusCode;
                string errorStatus;
                switch (ex)
                {
                    case NotFoundException NotFound:
                        statusCode = HttpStatusCode.NotFound;
                        errorStatus = "errorNotFound";
                        break;
                    
                    default:
                        statusCode = HttpStatusCode.InternalServerError;
                        errorStatus = "error";
                        break;
                };

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                var response = new
                {
                    status = errorStatus,
                    message = ex.Message,
                    timestamp = DateTime.UtcNow
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
