using ApiMiddleware.ApiEndpoints.Info.Dto;
using Microsoft.Extensions.Logging;

namespace ApiMiddleware.ApiEndpoints.Info;

public class InfoEndpointResponseGenerator(ILogger<InfoEndpointResponseGenerator> logger) : IInfoEndpointResponseGenerator
{
    private readonly ILogger _logger = logger;

    public virtual async Task<List<InfoDataItem>> ProcessAsync()
    {
        _logger.LogInformation("This is some information being logged :)");

        var outgoingData = new List<InfoDataItem>
        {
            new() { Name = "Item 1", Description = "Info Item", Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") },
            new() { Name = "Item 2", Description = "Info Item", Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") }
        };

        return outgoingData;
    }
}
