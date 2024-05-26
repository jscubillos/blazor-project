using Blazor.Project.WebApp.Shared.Services;
using Blazor.Project.WebApp.User.Models;

namespace Blazor.Project.WebApp.User.Services;

public class UserService(IApiIntegrationService apiIntegrationService) : IUserService
{
    public async Task Register(RegisterUserInputModel inputModel)
    {
        var requestBody = apiIntegrationService.SerializarBody(inputModel);
        var  responseMessage = await apiIntegrationService.ExecuteRequest(HttpMethod.Post, "user", requestBody);

        if (!responseMessage.IsSuccessStatusCode)
            throw apiIntegrationService.HandleException(responseMessage);
    }
}