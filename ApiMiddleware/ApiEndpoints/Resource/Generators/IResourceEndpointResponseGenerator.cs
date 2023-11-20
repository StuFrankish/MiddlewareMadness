namespace ApiMiddleware.ApiEndpoints.Info;

public interface IResourceEndpointResponseGenerator
{
    Task<byte[]> ProcessAsync(string fileName);
}