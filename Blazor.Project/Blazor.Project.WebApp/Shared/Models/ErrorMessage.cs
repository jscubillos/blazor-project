using System.Net;
using System.Text.Json.Serialization;

namespace Blazor.Project.WebApp.Shared.Models;

public class ErrorMessage
{
    [JsonPropertyName("statusCode")]
    public required HttpStatusCode StatusCode { get; set; }
    
    [JsonPropertyName("message")]
    public required string Message { get; set; }
}