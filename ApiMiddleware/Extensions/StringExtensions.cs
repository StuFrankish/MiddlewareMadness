using System.Diagnostics;

namespace ApiMiddleware.Extensions;

public static class StringExtensions
{
    [DebuggerStepThrough]
    public static string? EnsureLeadingSlash(this string url)
    {
        return !string.IsNullOrWhiteSpace(url) && !url.StartsWith(value: '/') ? $"/{url}" : url;
    }
}
