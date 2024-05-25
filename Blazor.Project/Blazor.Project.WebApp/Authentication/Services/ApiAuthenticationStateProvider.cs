using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Project.WebApp.Authentication.Services;

public class ApiAuthenticationStateProvider(ILocalStorageService localStorageService) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await localStorageService.GetItemAsync<string>("authToken");
        var tokenExpiration = await localStorageService.GetItemAsync<string>("authTokenExpiration");

        if (string.IsNullOrWhiteSpace(token) || TokenExpired(tokenExpiration))
        {
            MarkUserAsLoggedOut();
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
    }

    public void MarkUserAsAuthenticated(string token)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);
    }

    public void MarkUserAsLoggedOut()
    { 
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
        NotifyAuthenticationStateChanged(authState);
    }

    private bool TokenExpired(string? tokenExpiration)
    {
        if (string.IsNullOrWhiteSpace(tokenExpiration))
            return true;

        var expirationDate = DateTime.Parse(tokenExpiration, null, DateTimeStyles.RoundtripKind);
        return expirationDate < DateTime.UtcNow;
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(jwt);
        return token.Claims;
    }
}