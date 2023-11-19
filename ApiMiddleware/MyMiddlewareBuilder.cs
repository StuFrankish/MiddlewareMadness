using Microsoft.Extensions.DependencyInjection;

namespace ApiMiddleware;

public class MyMiddlewareBuilder(IServiceCollection services) : IMyMiddlewareBuilder
{
    public IServiceCollection Services { get; } = services ?? throw new ArgumentNullException(nameof(services));
}
