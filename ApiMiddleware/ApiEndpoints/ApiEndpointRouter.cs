using ApiMiddleware.ApiEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ApiMiddleware.Routing;

public class ApiEndpointRouter(IEnumerable<ApiEndpoint> endPoints, IOptions<MyMiddlewareOptions> options) : IApiEndpointRouter
{
    private readonly IEnumerable<ApiEndpoint> _endpoints = endPoints;
    private readonly MyMiddlewareOptions _options = options.Value;

    public IApiEndpointHandler? Find(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        foreach (var endpoint in _endpoints)
        {
            var path = endpoint.Path;
            if (context.Request.Path.Equals(path, StringComparison.OrdinalIgnoreCase))
            {
                return GetEndpointHandler(endpoint, context);
            }
        }

        return null;
    }

    private IApiEndpointHandler? GetEndpointHandler(ApiEndpoint endpoint, HttpContext context)
    {
        if (_options.Endpoints.IsEndpointEnabled(endpoint) && context.RequestServices.GetService(endpoint.Handler) is IApiEndpointHandler handler)
        {
            return handler;
        }

        return null;
    }
}
