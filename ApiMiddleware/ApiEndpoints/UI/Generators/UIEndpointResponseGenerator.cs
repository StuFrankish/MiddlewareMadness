using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace ApiMiddleware.ApiEndpoints.Info;

public class UIEndpointResponseGenerator(ILogger<InfoEndpointResponseGenerator> logger) : IUIEndpointResponseGenerator
{
    private readonly ILogger _logger = logger;

    public virtual async Task<string> ProcessAsync()
    {
        _logger.LogInformation("This is some information being logged :)");

        var doc = new HtmlDocument();

        using (HttpClient client = new HttpClient())
        {
            try
            {
                string Url = "https://www.example.com/";
                HttpResponseMessage response = await client.GetAsync(Url);

                response.EnsureSuccessStatusCode();

                string htmlContent = await response.Content.ReadAsStringAsync();
                doc.LoadHtml(htmlContent);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        return doc.DocumentNode.OuterHtml;
    }
}
