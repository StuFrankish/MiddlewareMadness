using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;

namespace ApiMiddleware.ApiEndpoints.Info;

public class ResourceEndpoint(IResourceEndpointResponseGenerator responseGenerator, IOptions<MyMiddlewareOptions> myMiddlewareOptions, ILogger<ResourceEndpoint> logger) : IApiEndpointHandler
{
    private readonly IResourceEndpointResponseGenerator _responseGenerator = responseGenerator;
    private readonly MyMiddlewareOptions _options = myMiddlewareOptions.Value;
    private readonly ILogger<ResourceEndpoint> _logger = logger;

    public async Task<IApiEndpointResult?> ProcessAsync(HttpContext context)
    {
        if (!HttpMethods.IsGet(context.Request.Method))
        {
            _logger.LogError(message: "Wrong HTTP method used.");
            return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
        }

        _logger.LogInformation(message: "Beginning response processing...");
        return await ProcessInfoRequestAsync(context);
    }

    private async Task<IApiEndpointResult> ProcessInfoRequestAsync(HttpContext context)
    {
        var fileName = context.Request.Query[key: "r"];
        var response = await _responseGenerator.ProcessAsync(fileName!);

        if (response == null)
        {
            _logger.LogError(message: $"Resource {fileName} could not be found.");
            return new StatusCodeResult(HttpStatusCode.NotFound);
        }

        return new ResourceResult(response);
    }
}
