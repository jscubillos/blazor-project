using System.Text;
using System.Text.Json;
using Blazor.Project.WebApp.User.Models;

namespace Blazor.Project.WebApp.User.Services;

public class UserService(IHttpClientFactory httpClientFactory) : IUserService
{
    public async Task<RegisterUserOutputModel?> Register(RegisterUserInputModel inputModel)
    {
        var httpClient = httpClientFactory.CreateClient("API");
        var loginModelJson = JsonSerializer.Serialize(inputModel);
        var requestContent = new StringContent(loginModelJson, Encoding.UTF8, "application/json");

        var responseMessage = await httpClient.PostAsync("user", requestContent);
        if (!responseMessage.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<RegisterUserOutputModel>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        
        return new RegisterUserOutputModel();
    }
}