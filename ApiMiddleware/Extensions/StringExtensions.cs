using System.Diagnostics;

namespace ApiMiddleware.Extensions;

public static class StringExtensions
{
    [DebuggerStepThrough]
    public static string? EnsureLeadingSlash(this string url)
    {
        if (!String.IsNullOrWhiteSpace(url) && !url.StartsWith(value: '/'))
        {
            return "/" + url;
        }

        return url;
    }
}
