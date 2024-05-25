using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Blazor.Project.WebApp.Authentication.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Project.WebApp.Authentication.Services;

public class AuthenticationService(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService, AuthenticationStateProvider authenticationStateProvider) : IAuthenticationService
{
    public async Task<LoginOutputModel> Login(LoginInputModel loginModel)
    {
        var httpClient = httpClientFactory.CreateClient("API");
        var loginModelJson = JsonSerializer.Serialize(loginModel);
        var requestContent = new StringContent(loginModelJson, Encoding.UTF8, "application/json");

        var responseMessage = await httpClient.PostAsync("auth/login", requestContent);
        var loginResultJson = JsonSerializer.Deserialize<LoginOutputModel>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (!responseMessage.IsSuccessStatusCode)
            return loginResultJson;

        await localStorageService.SetItemAsStringAsync("authToken", loginResultJson.AccessToken);
        await localStorageService.SetItemAsStringAsync("authTokenExpiration", loginResultJson.Expires);

        ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(loginResultJson.AccessToken);

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(loginResultJson.TokenType, loginResultJson.AccessToken);

        return loginResultJson;
    }

    public async Task Logout()
    {
        var httpClient = httpClientFactory.CreateClient("API");
        await localStorageService.RemoveItemAsync("authToken");
        ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();
        httpClient.DefaultRequestHeaders.Authorization = null;
    }
}