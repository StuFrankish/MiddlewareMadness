using ApiMiddleware.ApiEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ApiMiddleware;

public class MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger _logger = logger;

    public async Task Invoke(HttpContext context, IApiEndpointRouter router)
    {
        try
        {
            var endpoint = router.Find(context);
            if (endpoint != null)
            {
                var result = await endpoint.ProcessAsync(context);
                if (result != null)
                {
                    await result.ExecuteAsync(context);
                }

                return;
            }
            else
            {
                _logger.LogTrace(message: $"Endpoint not found for {context.Request.Path}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.Message, ex);
            throw;
        }

        await _next(context);
    }

}
