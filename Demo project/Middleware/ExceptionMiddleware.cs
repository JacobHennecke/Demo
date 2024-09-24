using System.Net;
using System.Text.Json;

namespace Demo_project.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate request;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            this.request = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await request(context);
            }
            catch (ArgumentException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (BadHttpRequestException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, ex.Message ?? "An internal server error occurred.");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(
                JsonSerializer.Serialize(
                    new
                    {
                        statusCode = (int)statusCode,
                        message = message,
                        // Introduce a log layer to catch the actual exception with this guid, to trace back to the Error
                        errorId = Guid.NewGuid().ToString()
                    }
                    )
                );
        }
    }
}
