using Microsoft.AspNetCore.Http;

namespace ApiMiddleware.ApiEndpoints;

public interface IApiEndpointHandler
{
    Task<IApiEndpointResult?> ProcessAsync(HttpContext context);
}
