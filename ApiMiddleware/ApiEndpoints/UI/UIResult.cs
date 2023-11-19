using ApiMiddleware.Extensions;
using Microsoft.AspNetCore.Http;

namespace ApiMiddleware.ApiEndpoints.Info;

internal class UIResult(string data) : IApiEndpointResult
{
    public string Data = data;

    public async Task ExecuteAsync(HttpContext context)
    {
        context.Response.SetNoCache();
        await context.Response.WriteAsync(Data);
    }
}