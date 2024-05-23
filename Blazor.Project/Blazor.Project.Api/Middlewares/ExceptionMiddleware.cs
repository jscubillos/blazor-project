using System.Net;
using Microsoft.AspNetCore.Mvc;

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
        
        var result = new ObjectResult(new
        {
            StatusCode = statusCode,
            Message = statusCode == HttpStatusCode.InternalServerError ? "Internal Server Error - Unexpected error, contact your System Administrator" : exception.Message
        });
        
       return result.ExecuteResultAsync(new ActionContext
        {
            HttpContext = context
        });
    }
}