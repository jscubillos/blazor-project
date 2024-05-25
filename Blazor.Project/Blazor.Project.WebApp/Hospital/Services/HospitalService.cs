using Blazor.Project.WebApp.Hospital.Models;
using Blazor.Project.WebApp.Shared.Services;

namespace Blazor.Project.WebApp.Hospital.Services;

public class HospitalService(IApiIntegrationService apiIntegrationService) : IHospitalService
{
    public async Task<List<GetHospitalOutputModel>?> GetAll()
    {
        var  responseMessage = await apiIntegrationService.ExecuteRequest(HttpMethod.Get, "hospital/all");
        if (!responseMessage.IsSuccessStatusCode)
            return [];
        
        var responseBody =  responseMessage.Content.ReadAsStringAsync().Result;
        return apiIntegrationService.Deserializar<List<GetHospitalOutputModel>>(responseBody);
    }
}