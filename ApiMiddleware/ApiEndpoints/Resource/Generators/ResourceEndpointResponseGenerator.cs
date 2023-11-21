using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Resources;

namespace ApiMiddleware.ApiEndpoints.Info;

public class ResourceEndpointResponseGenerator(ILogger<ResourceEndpointResponseGenerator> logger) : IResourceEndpointResponseGenerator
{
    private readonly ILogger _logger = logger;

    public virtual async Task<byte[]> ProcessAsync(string fileName)
    {
        _logger.LogTrace(message: $"Getting file content for {fileName}");

        var assembly = Assembly.GetExecutingAssembly();

        var rm = new ResourceManager(baseName: Constants.MyMiddlewareConstants.ResourceFileNames.ResourceFileBaseName, assembly);
        var imageBytes = rm.GetObject(fileName) as Byte[];

        return imageBytes;
    }
}
