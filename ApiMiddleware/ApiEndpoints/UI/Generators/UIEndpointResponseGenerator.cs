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

        var assembly = Assembly.GetExecutingAssembly();
        var rm = new ResourceManager(baseName: Constants.MyMiddlewareConstants.ResourceFileNames.ResourceFileBaseName, assembly);

        var doc = new HtmlDocument();

        // Load the main HTML document
        doc.LoadHtml(rm.GetString(name: "index"));

        // Add the script content
        var scriptElement = doc.CreateElement(name: "script");
        scriptElement.InnerHtml = rm.GetString(name: "mainjs");

        var bodyElement = doc.DocumentNode.SelectSingleNode(xpath: "//body");
        bodyElement.AppendChild(scriptElement);

        // Return the document
        return doc.DocumentNode.OuterHtml;
    }
}
