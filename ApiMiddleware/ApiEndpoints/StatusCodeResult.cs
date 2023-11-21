using Microsoft.AspNetCore.Http;
using System.Net;

namespace ApiMiddleware.ApiEndpoints;

public class StatusCodeResult(HttpStatusCode statusCode) : IApiEndpointResult
{
    public int StatusCode { get; } = (int)statusCode;

    public Task ExecuteAsync(HttpContext context)
    {
        context.Response.StatusCode = StatusCode;
        return Task.CompletedTask;
    }
}