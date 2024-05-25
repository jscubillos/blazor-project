namespace Blazor.Project.WebApp.Shared.Services;

public interface IApiIntegrationService
{
    HttpResponseMessage ExecuteRequest(HttpMethod httpMethod, string url, string? requestBody = null, Dictionary<string, string>? queryParams = null);
    string SerializarBody(object objeto);
    Dictionary<string, string>? SerializarQueryParameters(object objeto);

    T? Deserializar<T>(string responseBody);
}