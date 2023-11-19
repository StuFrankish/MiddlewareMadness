using Microsoft.AspNetCore.Http;

namespace ApiMiddleware;

public class ServerUrls(IHttpContextAccessor httpContextAccessor) : IServerUrls
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private static readonly string separator = "://";

    public string Origin
    {
        get
        {
            var request = _httpContextAccessor.HttpContext.Request;
            return request?.Scheme + separator + request?.Host.ToUriComponent();
        }
        set
        {
            var split = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            var request = _httpContextAccessor.HttpContext.Request;
            request.Scheme = split.First();
            request.Host = new HostString(split.Last());
        }
    }

    public string? BasePath { get; set; }
}