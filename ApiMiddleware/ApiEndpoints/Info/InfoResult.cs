using ApiMiddleware.ApiEndpoints.Info.Dto;
using ApiMiddleware.Extensions;
using Microsoft.AspNetCore.Http;

namespace ApiMiddleware.ApiEndpoints.Info;

internal class InfoResult(List<InfoDataItem> data) : IApiEndpointResult
{
    public List<InfoDataItem> Data = data;

    public async Task ExecuteAsync(HttpContext context)
    {
        context.Response.SetNoCache();
        await context.Response.WriteJsonAsync(Data);
    }
}