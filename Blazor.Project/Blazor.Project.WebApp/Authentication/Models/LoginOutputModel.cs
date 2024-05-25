using System.Text.Json.Serialization;

namespace Blazor.Project.WebApp.Authentication.Models;

public class LoginOutputModel
{
    [JsonPropertyName("accessToken")]
    public string? AccessToken { get; set; }
    
    [JsonPropertyName("tokenType")]
    public string? TokenType { get; set; }
    
    [JsonPropertyName("expires")]
    public string? Expires { get; set; }
    
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}