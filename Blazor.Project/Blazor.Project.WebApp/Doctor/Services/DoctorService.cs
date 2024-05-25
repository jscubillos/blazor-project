using Blazor.Project.WebApp.Doctor.Models;
using Blazor.Project.WebApp.Doctor.Services;
using Blazor.Project.WebApp.Shared.Services;

namespace Blazor.Project.WebApp.Doctor.Services;

public class DoctorService(IApiIntegrationService apiIntegrationService) : IDoctorService
{
    public async Task<List<GetDoctorOutputModel>?> GetAll()
    {
        var  responseMessage = await apiIntegrationService.ExecuteRequest(HttpMethod.Get, "doctor/all");
        if (!responseMessage.IsSuccessStatusCode)
            return [];
        
        var responseBody =  responseMessage.Content.ReadAsStringAsync().Result;
        return apiIntegrationService.Deserializar<List<GetDoctorOutputModel>>(responseBody);
    }
}