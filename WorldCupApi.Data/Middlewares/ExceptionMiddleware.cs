using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WorldCupApi.Data.Errors;
using WorldCupApi.Data.Models;

namespace WorldCupApi.Data.Middlewares;

using System.Net;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        string errorMessage = "";
        context.Response.ContentType = "application/json";
        var response = context.Response;
        
        switch (exception)
        {
            case ApplicationException ex:
                if (ex.Message.Contains("Invalid Token"))
                {
                    response.StatusCode = (int) HttpStatusCode.Forbidden;
                    break;
                }
                response.StatusCode = (int) HttpStatusCode.BadRequest;
                errorMessage = ex.Message;
                break;
            case WorldCupException ex:
                response.StatusCode = (int) HttpStatusCode.BadRequest;
                errorMessage = ex.Message;
                break;
            default:
                response.StatusCode = (int) HttpStatusCode.InternalServerError;
                errorMessage = CustomError.E_001;
                break;
        }
        
        _logger.LogError(exception.Message);
        var result = JsonSerializer.Serialize(new
        {
            Error = errorMessage
        });
        await context.Response.WriteAsync(result);
    }
}