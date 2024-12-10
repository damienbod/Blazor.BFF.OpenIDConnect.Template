namespace BlazorBffOpenIDConnect.Client.Services;

public class AntiforgeryHttpClientFactory(IHttpClientFactory httpClientFactory, IJSRuntime jSRuntime)
    : IAntiforgeryHttpClientFactory
{
    public async Task<HttpClient> CreateClientAsync(string clientName = AuthDefaults.AuthorizedClientName)
    {
        var token = await jSRuntime.InvokeAsync<string>("getAntiForgeryToken");

        var client = httpClientFactory.CreateClient(clientName);
        client.DefaultRequestHeaders.Add(AntiforgeryDefaults.HeaderName, token);

        return client;
    }
}
