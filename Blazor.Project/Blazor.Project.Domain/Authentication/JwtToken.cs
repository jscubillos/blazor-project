namespace Blazor.Project.Domain.Authentication;

public class JwtToken
{
     public required string AccessToken { get; set; }
     public required string TokenType { get; set; }
     public required DateTime Expires { get; set; } 
}