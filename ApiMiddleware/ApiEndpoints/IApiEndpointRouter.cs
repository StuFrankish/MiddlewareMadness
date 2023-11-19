using Microsoft.AspNetCore.Http;

namespace ApiMiddleware.ApiEndpoints;

public interface IApiEndpointRouter
{
    IApiEndpointHandler? Find(HttpContext context);
}