using Microsoft.AspNetCore.Http;

namespace ApiMiddleware.ApiEndpoints;

public class ApiEndpoint(string name, string path, Type handlerType)
{
    public string Name { get; set; } = name;
    public PathString Path { get; set; } = path;
    public Type Handler { get; set; } = handlerType;
}