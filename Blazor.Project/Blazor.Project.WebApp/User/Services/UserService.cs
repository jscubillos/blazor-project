using Blazor.Project.WebApp.Shared.Services;
using Blazor.Project.WebApp.User.Models;

namespace Blazor.Project.WebApp.User.Services;

public class UserService(IApiIntegrationService apiIntegrationService) : IUserService
{
    public async Task<RegisterUserOutputModel?> Register(RegisterUserInputModel inputModel)
    {
        var requestBody = apiIntegrationService.SerializarBody(inputModel);
        var  responseMessage = await apiIntegrationService.ExecuteRequest(HttpMethod.Post, "user", requestBody);

        if (!responseMessage.IsSuccessStatusCode)
            return new RegisterUserOutputModel();
        
        var responseBody =  responseMessage.Content.ReadAsStringAsync().Result;
        return apiIntegrationService.Deserializar<RegisterUserOutputModel>(responseBody);
    }
}