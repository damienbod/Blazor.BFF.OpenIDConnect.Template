using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BlazorBffOpenIDConnect.Server.Controllers;

// orig src https://github.com/berhir/BlazorWebAssemblyCookieAuth
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    [HttpGet("Login")]
    public ActionResult Login(string returnUrl) => Challenge(new AuthenticationProperties
    {
        RedirectUri = !string.IsNullOrEmpty(returnUrl) ? returnUrl : "/"
    });

    [ValidateAntiForgeryToken]
    [Authorize]
    [HttpPost("Logout")]
    public IActionResult Logout() => SignOut(new AuthenticationProperties
    {
        RedirectUri = "/"
    },
    CookieAuthenticationDefaults.AuthenticationScheme,
    OpenIdConnectDefaults.AuthenticationScheme);
}
