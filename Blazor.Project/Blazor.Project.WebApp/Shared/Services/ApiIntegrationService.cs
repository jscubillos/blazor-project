using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace Blazor.Project.WebApp.Shared.Services;

public class ApiIntegrationService(IHttpClientFactory httpClientFactory) : IApiIntegrationService
{
    public async Task<HttpResponseMessage> ExecuteRequest(HttpMethod httpMethod, string url, string? requestBody = null, Dictionary<string, string>? queryParams = null)
    {
        using var client = httpClientFactory.CreateClient("API");
        try
        {

            if (httpMethod == HttpMethod.Get && queryParams != null)
                url = GetUrlQueryParams(url, queryParams);

            var request = new HttpRequestMessage(httpMethod, url);
            if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put)
                request.Content = new StringContent(requestBody ?? string.Empty, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);
            return response;
        }
        catch (Exception exception)
        {
            var innerException = exception.InnerException;
            while (innerException?.InnerException != null)
                innerException = innerException.InnerException;
                    
            throw new Exception("Error when executing request to API service: " + innerException?.Message);
        }

        
    }

    public async Task<string> ExecuteRequestResponseBody(HttpMethod httpMethod, string url, string? requestBody, Dictionary<string, string>? queryParams)
    {
        var response = await ExecuteRequest(httpMethod, url, requestBody, queryParams);
        var responseBody = await response.Content.ReadAsStringAsync(); 
        response.EnsureSuccessStatusCode();
        return responseBody;
    }
    
    public string SerializarBody(object objeto)
    {
        var settings = GetJsonSerializerOptions();
        var objectoSerializado = JsonSerializer.Serialize(objeto, settings);
        return objectoSerializado;
    }

    public Dictionary<string, string>? SerializarQueryParameters(object objeto)
    {
        var objectoSerializadoBody = SerializarBody(objeto);

        Dictionary<string, string>? queryParams = null;
        if (!string.IsNullOrEmpty(objectoSerializadoBody))
            queryParams = JsonSerializer.Deserialize<Dictionary<string, string>>(objectoSerializadoBody);

        return queryParams;
    }

    public T Deserializar<T>(string responseBody)
    {
        var settings = GetJsonSerializerOptions();
        var objetoDeserializado = JsonSerializer.Deserialize<T>(responseBody, settings);
        return objetoDeserializado ?? throw new Exception("Error when deserializing object");
    }

    private JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions()
        { 
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }

    private string GetUrlQueryParams(string url, Dictionary<string, string> queryParams)
    {
        var builder = new UriBuilder(url);
        var query = HttpUtility.ParseQueryString(builder.Query, Encoding.UTF8);
        foreach (var param in queryParams)
        {
            query[param.Key] = param.Value;
        }
        builder.Query = query.ToString();
        url = builder.ToString();
        return url;
    }
}