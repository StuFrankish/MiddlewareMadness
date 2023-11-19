using ApiMiddleware.ApiEndpoints;
using ApiMiddleware.ApiEndpoints.Info;
using ApiMiddleware.Extensions;
using ApiMiddleware.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Serilog;
using static ApiMiddleware.Constants.MyMiddlewareConstants;

namespace ApiMiddleware.Extensions;

public static class MyMiddlewareExtensions
{
    public static IMyMiddlewareBuilder AddMyMiddlewareBuilder(this IServiceCollection services)
    {
        return new MyMiddlewareBuilder(services);
    }

    public static IMyMiddlewareBuilder AddMyMiddleware(this IServiceCollection services)
    {
        var builder = services.AddMyMiddlewareBuilder();

        Log.Logger = new LoggerConfiguration()
            .CreateLogger();

        services.AddLogging(loggingBuilder =>
            loggingBuilder.AddSerilog());

        builder
            .AddBaseServices()
            .AddEndpoints()
            .AddResponseGenerators();

        return builder;
    }

    public static IMyMiddlewareBuilder AddMyMiddleware(this IServiceCollection services, Action<MyMiddlewareOptions> setupAction)
    {
        services.Configure(setupAction);

        return services.AddMyMiddleware();
    }

    public static IMyMiddlewareBuilder AddEndpoints(this IMyMiddlewareBuilder builder)
    {
        builder.Services.AddTransient<IApiEndpointRouter, ApiEndpointRouter>();

        builder.AddEndpoint<InfoEndpoint>(EndpointNames.Info, EndpointPaths.Info.EnsureLeadingSlash());
        builder.AddEndpoint<UIEndpoint>(EndpointNames.UI, EndpointPaths.UI.EnsureLeadingSlash());

        return builder;
    }

    public static IMyMiddlewareBuilder AddResponseGenerators(this IMyMiddlewareBuilder builder)
    {
        builder.Services.TryAddTransient<IInfoEndpointResponseGenerator, InfoEndpointResponseGenerator>();
        builder.Services.TryAddTransient<IUIEndpointResponseGenerator, UIEndpointResponseGenerator>();

        return builder;
    }

    public static IMyMiddlewareBuilder AddBaseServices(this IMyMiddlewareBuilder builder)
    {
        builder.Services.AddTransient<IServerUrls, ServerUrls>();

        return builder;
    }

    private static IMyMiddlewareBuilder AddEndpoint<T>(this IMyMiddlewareBuilder builder, string name, PathString path) where T : class, IApiEndpointHandler
    {
        builder.Services.AddTransient<T>();
        builder.Services.AddSingleton(implementationInstance: new ApiEndpoint(name, path, typeof(T)));

        return builder;
    }

    public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<MyMiddleware>();

        return app;
    }
}

public static class OptionsServiceCollectionExtensions
{
    public static IServiceCollection Configure<TOptions>(this IServiceCollection services, Action<TOptions> configureOptions) where TOptions : class
            => services.Configure(Options.DefaultName, configureOptions);
}