namespace ApiMiddleware;

public class MyMiddlewareOptions
{
    public string? StringSomething { get; set; }
    public int IntSomething { get; set; }

    public ApiEndpointOptions Endpoints { get; set; } = new ApiEndpointOptions();
}
