namespace BlazorBffOpenIDConnect.Server.Modules;

public class AccountModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Account");

        group.MapGet("Login", Login);

        group.MapPost("Logout", Logout)
             .RequireAuthorization()
             .ValidateAntiforgery();
    }

    public IResult Login([FromQuery] string returnUrl = "") => Results.Challenge(new AuthenticationProperties
    {
        RedirectUri = !string.IsNullOrEmpty(returnUrl) ? returnUrl : "/"
    });

    public IResult Logout() => Results.SignOut(new AuthenticationProperties
    {
        RedirectUri = "/"
    }, 
    new string[] 
    {
        CookieAuthenticationDefaults.AuthenticationScheme,
        OpenIdConnectDefaults.AuthenticationScheme
    });
}
