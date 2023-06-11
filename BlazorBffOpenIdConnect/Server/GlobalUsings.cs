global using System.Diagnostics;
global using System.Security.Claims;

global using BlazorBffOpenIDConnect.Server;
global using BlazorBffOpenIDConnect.Server.Services;
global using BlazorBffOpenIDConnect.Shared.Authorization;
global using BlazorBffOpenIDConnect.Shared.Defaults;

global using Carter;

global using Microsoft.AspNetCore.Antiforgery;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.Cookies;
global using Microsoft.AspNetCore.Authentication.OpenIdConnect;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.RazorPages;
global using Microsoft.IdentityModel.Protocols.OpenIdConnect;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.Net.Http.Headers;
