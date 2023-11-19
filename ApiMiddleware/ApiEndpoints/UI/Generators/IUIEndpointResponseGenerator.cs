using Microsoft.AspNetCore.Mvc;

namespace ApiMiddleware.ApiEndpoints.Info;

public interface IUIEndpointResponseGenerator
{
    Task<string> ProcessAsync();
}