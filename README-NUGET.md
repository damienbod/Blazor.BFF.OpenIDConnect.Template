# Blazor.BFF.OpenIDConnect.Template

[![.NET](https://github.com/damienbod/Blazor.BFF.OpenIDConnect.Template/actions/workflows/dotnet.yml/badge.svg)](https://github.com/damienbod/Blazor.BFF.OpenIDConnect.Template/actions/workflows/dotnet.yml) [![NuGet Status](http://img.shields.io/nuget/v/Blazor.BFF.OpenIDConnect.Template.svg?style=flat-square)](https://www.nuget.org/packages/Blazor.BFF.OpenIDConnect.Template/) [Change log](https://github.com/damienbod/Blazor.BFF.OpenIDConnect.Template/blob/main/Changelog.md)

This template can be used to create a Blazor WASM application hosted in an ASP.NET Core Web app using OpenID Connect to authenticate using the BFF security architecture. (server authentication) This removes the tokens from the browser and uses cookies with each HTTP request, response. The template also adds the required security headers as best it can for a Blazor application.

## Features

- WASM hosted in ASP.NET Core 9
- BFF (backend for frontend) with Standard OpenID Connect
- OAuth2 and OpenID Connect OIDC
- No tokens in the browser

## Using the template

### install

```
dotnet new install Blazor.BFF.OpenIDConnect.Template
```

### run

```
dotnet new blazorbffoidc -n YourCompany.Bff --HttpsPortCustom 44348
```

Use the `-n` or `--name` parameter to change the name of the output created. This string is also used to substitute the namespace name in the .cs file for the project.

## Setup after installation

Add the OpenID Connect App registration settings

```
{
  "OpenIDConnectSettings": {
    "Authority": "--your-authority--",
    "ClientId": "--client ID--",
    "ClientSecret": "--client-secret (user secrets)--"
  },
```


### uninstall

```
dotnet new uninstall Blazor.BFF.OpenIDConnect.Template
```


## Credits, Used NuGet packages + ASP.NET Core 9.0 standard packages

- NetEscapades.AspNetCore.SecurityHeaders

## Links

https://github.com/andrewlock/NetEscapades.AspNetCore.SecurityHeaders
