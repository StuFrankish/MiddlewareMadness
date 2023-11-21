using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;

namespace ApiMiddleware.ApiEndpoints.Info;

public class InfoEndpoint(IInfoEndpointResponseGenerator responseGenerator, IOptions<MyMiddlewareOptions> myMiddlewareOptions, ILogger<InfoEndpoint> logger) : IApiEndpointHandler
{
    private readonly IInfoEndpointResponseGenerator _responseGenerator = responseGenerator;
    private readonly MyMiddlewareOptions _options = myMiddlewareOptions.Value;
    private readonly ILogger<InfoEndpoint> _logger = logger;

    public async Task<IApiEndpointResult?> ProcessAsync(HttpContext context)
    {
        if (!HttpMethods.IsGet(context.Request.Method) && !HttpMethods.IsPost(context.Request.Method))
        {
            _logger.LogError(message: "Wrong HTTP method used.");
            return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
        }

        _logger.LogInformation(message: "Beginning response processing...");
        return await ProcessInfoRequestAsync(context);
    }

    private async Task<IApiEndpointResult> ProcessInfoRequestAsync(HttpContext context)
    {
        var optionValue = _options.IntSomething;

        var response = await _responseGenerator.ProcessAsync();
        return new InfoResult(response);
    }
}
