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

    public async Task Register(HospitalInputModel inputModel)
    {
        var requestBody = apiIntegrationService.SerializarBody(inputModel);
        var  responseMessage = await apiIntegrationService.ExecuteRequest(HttpMethod.Post, "hospital",requestBody);
        
        if (!responseMessage.IsSuccessStatusCode)
            throw apiIntegrationService.HandleException(responseMessage);
    }

    public async Task Delete(int id)
    {
        var  responseMessage = await apiIntegrationService.ExecuteRequest(HttpMethod.Delete, $"hospital/{id.ToString()}");
        if (!responseMessage.IsSuccessStatusCode)
            throw apiIntegrationService.HandleException(responseMessage);
    }

    public async Task<GetHospitalOutputModel?> GetById(int id)
    {
        var responseMessage = await apiIntegrationService.ExecuteRequest(HttpMethod.Get, "hospital", null, new Dictionary<string, string>() { { "id", id.ToString() } });
        if (!responseMessage.IsSuccessStatusCode)
            throw apiIntegrationService.HandleException(responseMessage);
        
        var responseBody = responseMessage.Content.ReadAsStringAsync().Result;
        return apiIntegrationService.Deserializar<GetHospitalOutputModel>(responseBody);
    }

    public async Task Update(HospitalInputModel inputModel)
    {
        var requestBody = apiIntegrationService.SerializarBody(inputModel);
        var responseMessage = await apiIntegrationService.ExecuteRequest(HttpMethod.Put, "hospital", requestBody);
        if (!responseMessage.IsSuccessStatusCode)
            throw apiIntegrationService.HandleException(responseMessage);
    }
}