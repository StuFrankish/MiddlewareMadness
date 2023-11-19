using Microsoft.Extensions.DependencyInjection;

namespace ApiMiddleware;

public interface IMyMiddlewareBuilder
{
    IServiceCollection Services { get; }
}
