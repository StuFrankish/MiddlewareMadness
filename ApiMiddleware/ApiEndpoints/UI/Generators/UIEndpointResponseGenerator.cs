using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Resources;

namespace ApiMiddleware.ApiEndpoints.Info;

public class UIEndpointResponseGenerator(ILogger<InfoEndpointResponseGenerator> logger) : IUIEndpointResponseGenerator
{
    private readonly ILogger _logger = logger;

    public virtual async Task<string> ProcessAsync()
    {
        _logger.LogInformation(message: "Running the middleware homepage");

        var doc = new HtmlDocument();

        var assembly = Assembly.GetExecutingAssembly();
        
        var rm = new ResourceManager(baseName: Constants.MyMiddlewareConstants.ResourceFileNames.ResourceFileBaseName, assembly);
        var contentString = rm.GetString(name: "index");

        doc.LoadHtml(contentString);


        return doc.DocumentNode.OuterHtml;
    }
}
