# Blazor.BFF.OpenIDConnect.Template

[![.NET](https://github.com/damienbod/Blazor.BFF.OpenIDConnect.Template/actions/workflows/dotnet.yml/badge.svg)](https://github.com/damienbod/Blazor.BFF.OpenIDConnect.Template/actions/workflows/dotnet.yml) [![NuGet Status](http://img.shields.io/nuget/v/Blazor.BFF.OpenIDConnect.Template.svg?style=flat-square)](https://www.nuget.org/packages/Blazor.BFF.OpenIDConnect.Template/) [Change log](https://github.com/damienbod/Blazor.BFF.OpenIDConnect.Template/blob/main/Changelog.md)

This template can be used to create a Blazor WASM application hosted in an ASP.NET Core Web app using OpenID Connect to authenticate using the BFF security architecture. (server authentication) This removes the tokens from the browser and uses cookies with each HTTP request, response. The template also adds the required security headers as best it can for a Blazor application.

![Blazor BFF OpenID Connect](https://github.com/damienbod/Blazor.BFF.OpenIDConnect.Template/blob/main/images/blazorBFFOpenIDConnect.png)

## Features

- WASM hosted in ASP.NET Core 7
- BFF with OpenID Connect
- OAuth2 and OpenID Connect OIDC
- No tokens in the browser

## Other templates

[Blazor BFF Azure AD](https://github.com/damienbod/Blazor.BFF.AzureAD.Template)

[Blazor BFF Azure B2C](https://github.com/damienbod/Blazor.BFF.AzureB2C.Template)

## Using the template

### install

```
dotnet new -i Blazor.BFF.OpenIDConnect.Template
```

### run

```
dotnet new blazorbffoidc -n YourCompany.Bff --HttpsPortCustom 44348
```

Use the `-n` or `--name` parameter to change the name of the output created. This string is also used to substitute the namespace name in the .cs file for the project.

## Setup after installation

Add the OpenID Connect registration settings

```
"OpenIDConnectSettings": {
    "Authority": "--your-authority--",
    "ClientId": "--client ID--",
    "ClientSecret": "--client-secret (user secrets)--"
},

```

### uninstall

```
dotnet new -u Blazor.BFF.OpenIDConnect.Template
```

## Development

### build

https://docs.microsoft.com/en-us/dotnet/core/tutorials/create-custom-template

```
dotnet pack -o ./publish -c Release -p:PackageVersion=2.0.4 --no-build
```

### install developement

Locally built nupkg:

```
dotnet new -i Blazor.BFF.OpenIDConnect.Template.2.0.4.nupkg
```

Local folder:

```
dotnet new -i <PATH>
```

Where `<PATH>` is the path to the folder containing .template.config.


## Credits, Used NuGet packages + ASP.NET Core 7.0 standard packages

- NetEscapades.AspNetCore.SecurityHeaders

## Links

https://documentation.openiddict.com/

https://auth0.com/

https://www.keycloak.org/

https://github.com/andrewlock/NetEscapades.AspNetCore.SecurityHeaders
