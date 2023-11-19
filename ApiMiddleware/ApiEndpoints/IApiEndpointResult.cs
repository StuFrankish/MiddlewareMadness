using Microsoft.AspNetCore.Http;

namespace ApiMiddleware.ApiEndpoints;

public interface IApiEndpointResult
{
    Task ExecuteAsync(HttpContext context);
}
