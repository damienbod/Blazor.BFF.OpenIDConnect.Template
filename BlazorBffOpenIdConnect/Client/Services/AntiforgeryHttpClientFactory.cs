namespace BlazorBffOpenIDConnect.Client.Services;

public class AntiforgeryHttpClientFactory : IAntiforgeryHttpClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IJSRuntime _jSRuntime;

    public AntiforgeryHttpClientFactory(IHttpClientFactory httpClientFactory, IJSRuntime jSRuntime)
    {
        _httpClientFactory = httpClientFactory;
        _jSRuntime = jSRuntime;
    }

    public async Task<HttpClient> CreateClientAsync(string clientName = AuthDefaults.AuthorizedClientName)
    {
        var token = await _jSRuntime.InvokeAsync<string>("getAntiForgeryToken");

        var client = _httpClientFactory.CreateClient(clientName);
        client.DefaultRequestHeaders.Add(AntiforgeryDefaults.HeaderName, token);

        return client;
    }
}
