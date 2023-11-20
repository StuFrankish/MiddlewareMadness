namespace ApiMiddleware;

public class ApiEndpointOptions
{
    public bool EnableInfoEndpoint { get; set; } = false;
    public bool EnableUIEndpoint { get; set; } = false;
    public bool EnableResourceEndpoint { get; set; } = false;
}