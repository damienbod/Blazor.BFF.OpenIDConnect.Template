﻿namespace BlazorBffOpenIDConnect.Server.Modules;

public class UserModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/User");

        group.MapGet("/", GetCurrentUser)
             .AllowAnonymous();
    }

    public IResult GetCurrentUser(IHttpContextAccessor hca) => Results.Ok(CreateUserInfo(hca.HttpContext!.User));

    private static UserInfo CreateUserInfo(ClaimsPrincipal claimsPrincipal)
    {
        if(!claimsPrincipal?.Identity?.IsAuthenticated ?? true)
        {
            return UserInfo.Anonymous;
        }

        var userInfo = new UserInfo
        {
            IsAuthenticated = true
        };

        if(claimsPrincipal?.Identity is ClaimsIdentity claimsIdentity)
        {
            userInfo.NameClaimType = claimsIdentity.NameClaimType;
            userInfo.RoleClaimType = claimsIdentity.RoleClaimType;
        }
        else
        {
            userInfo.NameClaimType = ClaimTypes.Name;
            userInfo.RoleClaimType = ClaimTypes.Role;
        }

        if(claimsPrincipal?.Claims?.Any() ?? false)
        {
            // Add just the name claim
            var claims = claimsPrincipal.FindAll(userInfo.NameClaimType)
                                        .Select(u => new ClaimValue(userInfo.NameClaimType, u.Value))
                                        .ToList();

            // Uncomment this code if you want to send additional claims to the client.
            //var claims = claimsPrincipal.Claims.Select(u => new ClaimValue(u.Type, u.Value))
            //                                      .ToList();

            userInfo.Claims = claims;
        }

        return userInfo;
    }
}
