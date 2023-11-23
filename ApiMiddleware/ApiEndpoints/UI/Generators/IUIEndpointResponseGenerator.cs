namespace ApiMiddleware.ApiEndpoints.Info;

public interface IUIEndpointResponseGenerator
{
    Task<string> ProcessAsync();
}