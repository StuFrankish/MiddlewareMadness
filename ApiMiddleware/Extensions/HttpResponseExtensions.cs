using ApiMiddleware.Helpers;
using Microsoft.AspNetCore.Http;

namespace ApiMiddleware.Extensions;

public static class HttpResponseExtensions
{
    public static async Task WriteJsonAsync(this HttpResponse response, object o, string? contentType = null)
    {
        var json = ObjectSerializer.ToString(o);
        await response.WriteJsonAsync(json, contentType);
    }

    public static async Task WriteJsonAsync(this HttpResponse response, string json, string? contentType = null)
    {
        response.ContentType = contentType ?? "application/json; charset=UTF-8";
        await response.WriteAsync(json);
        await response.Body.FlushAsync();
    }

    public static void SetNoCache(this HttpResponse response)
    {
        if (!response.Headers.ContainsKey("Cache-Control"))
        {
            response.Headers.Add(key: "Cache-Control", value: "no-store, no-cache, max-age=0");
        }
        else
        {
            response.Headers[key: "Cache-Control"] = "no-store, no-cache, max-age=0";
        }

        if (!response.Headers.ContainsKey(key: "Pragma"))
        {
            response.Headers.Add(key: "Pragma", value: "no-cache");
        }
    }
}
