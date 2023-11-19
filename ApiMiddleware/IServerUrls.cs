namespace ApiMiddleware;

public interface IServerUrls
{
    string Origin { get; set; }
    string? BasePath { get; set; }
    string BaseUrl { get => Origin + BasePath; }
}