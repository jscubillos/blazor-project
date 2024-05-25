using System.Net.Http.Headers;
using Blazor.Project.WebApp.Authentication.Models;
using Blazor.Project.WebApp.Shared.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Project.WebApp.Authentication.Services;

public class AuthenticationService(IApiIntegrationService apiIntegrationService, ILocalStorageService localStorageService, IHttpClientFactory httpClientFactory, AuthenticationStateProvider authenticationStateProvider) : IAuthenticationService
{
    public async Task<LoginOutputModel> Login(LoginInputModel inputModel)
    {
        var requestBody = apiIntegrationService.SerializarBody(inputModel);
        var  responseMessage = await apiIntegrationService.ExecuteRequest(HttpMethod.Post, "auth/login", requestBody);
        var loginResultJson = apiIntegrationService.Deserializar<LoginOutputModel>(responseMessage.Content.ReadAsStringAsync().Result);
        if (!responseMessage.IsSuccessStatusCode || loginResultJson.AccessToken == null || loginResultJson.Expires == null || loginResultJson.TokenType == null)
            return loginResultJson;

        await localStorageService.SetItemAsStringAsync("authToken", loginResultJson.AccessToken);
        await localStorageService.SetItemAsStringAsync("authTokenExpiration", loginResultJson.Expires);
        ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(loginResultJson.AccessToken);
        
        var httpClient = httpClientFactory.CreateClient("API");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(loginResultJson.TokenType, loginResultJson.AccessToken);

        return loginResultJson;
    }

    public async Task Logout()
    {
        await localStorageService.RemoveItemAsync("authToken");
        ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();
        
        var httpClient = httpClientFactory.CreateClient("API");
        httpClient.DefaultRequestHeaders.Authorization = null;
    }
}