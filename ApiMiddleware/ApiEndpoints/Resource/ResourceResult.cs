using ApiMiddleware.Extensions;
using Microsoft.AspNetCore.Http;

namespace ApiMiddleware.ApiEndpoints.Info;

internal class ResourceResult(byte[] data) : IApiEndpointResult
{
    public byte[] Data = data;

    public async Task ExecuteAsync(HttpContext context)
    {
        context.Response.SetNoCache();
        context.Response.ContentType = "image/png";

        await context.Response.Body.WriteAsync(Data, offset: 0, Data.Length);
    }
}