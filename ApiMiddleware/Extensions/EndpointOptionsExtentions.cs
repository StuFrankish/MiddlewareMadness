using ApiMiddleware.Constants;
using ApiMiddleware.ApiEndpoints;

namespace ApiMiddleware;

public static class EndpointOptionsExtensions
{
    public static bool IsEndpointEnabled(this ApiEndpointOptions options, ApiEndpoint endpoint) => endpoint?.Name switch
    {
        MyMiddlewareConstants.EndpointNames.Info => options.EnableInfoEndpoint,
        MyMiddlewareConstants.EndpointNames.UI => options.EnableUIEndpoint,
        MyMiddlewareConstants.EndpointNames.Resource => options.EnableResourceEndpoint,
        _ => false
    };
}