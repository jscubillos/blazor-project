using Blazored.LocalStorage;

namespace Blazor.Project.WebApp.Authentication.Services;

public class AuthenticationHttpHandler(ILocalStorageService localStorageService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string[] urisDesconsiderar = ["auth/login", "user"];
        if (urisDesconsiderar.Contains(request.RequestUri?.AbsolutePath.ToLower()))
            return await base.SendAsync(request, cancellationToken);

        var token = await localStorageService.GetItemAsStringAsync("authToken", cancellationToken);
        if (!string.IsNullOrEmpty(token))
            request.Headers.Add("Authorization", $"Bearer {token}");

        return await base.SendAsync(request, cancellationToken);
    }
}