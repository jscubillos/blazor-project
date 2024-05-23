using System.Net;

namespace Blazor.Project.Api.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch(ApplicationException applicationException)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.BadRequest, applicationException);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        if(statusCode == HttpStatusCode.InternalServerError)
        {
            return context.Response.WriteAsync(new
            {
                context.Response.StatusCode,
                Message = "Internal Server Error - Unexpected error, contact your System Administrator",
                Detailed = exception.Message
            }.ToString() ?? string.Empty);
        }
        else
        {
            return context.Response.WriteAsync(new
            {
                context.Response.StatusCode,
                Message = exception.Message
            }.ToString() ?? string.Empty);
        }
    }
}