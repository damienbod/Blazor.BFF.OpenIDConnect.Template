namespace BlazorBffOpenIDConnect.Client.Services;

// orig src https://github.com/berhir/BlazorWebAssemblyCookieAuth
public class HostAuthenticationStateProvider(NavigationManager navigation, HttpClient client, ILogger<HostAuthenticationStateProvider> logger)
    : AuthenticationStateProvider
{
    private static readonly TimeSpan userCacheRefreshInterval = TimeSpan.FromSeconds(60);
    private DateTimeOffset userLastCheck = DateTimeOffset.FromUnixTimeSeconds(0);
    private ClaimsPrincipal cachedUser = new(new ClaimsIdentity());

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        => new AuthenticationState(await GetUser(useCache: true));

    public void SignIn(string? customReturnUrl = null)
    {
        var returnUrl = customReturnUrl != null ? navigation.ToAbsoluteUri(customReturnUrl).ToString() : null;
        var encodedReturnUrl = Uri.EscapeDataString(returnUrl ?? navigation.Uri);
        var logInUrl = navigation.ToAbsoluteUri($"{AuthDefaults.LogInPath}?returnUrl={encodedReturnUrl}");
        navigation.NavigateTo(logInUrl.ToString(), true);
    }

    private async ValueTask<ClaimsPrincipal> GetUser(bool useCache = false)
    {
        var now = DateTimeOffset.Now;
        if (useCache && now < userLastCheck + userCacheRefreshInterval)
        {
            logger.LogDebug("Taking user from cache");
            return cachedUser;
        }

        logger.LogDebug("Fetching user");
        cachedUser = await FetchUser();
        userLastCheck = now;

        return cachedUser;
    }

    private async Task<ClaimsPrincipal> FetchUser()
    {
        UserInfo? user = null;

        try
        {
            logger.LogInformation("{clientBaseAddress}", client.BaseAddress?.ToString());
            user = await client.GetFromJsonAsync<UserInfo>("api/User");
        }
        catch (Exception exc)
        {
            logger.LogWarning(exc, "Fetching user failed.");
        }

        if (user == null || !user.IsAuthenticated)
        {
            return new ClaimsPrincipal(new ClaimsIdentity());
        }

        var identity = new ClaimsIdentity(
            nameof(HostAuthenticationStateProvider),
            user.NameClaimType,
            user.RoleClaimType);

        if (user.Claims != null)
        {
            identity.AddClaims(user.Claims.Select(c => new Claim(c.Type, c.Value)));
        }

        return new ClaimsPrincipal(identity);
    }
}
