namespace Blazor.Project.Application.Users.Commands.Login;

public class LoginUserOutputModel
{
    public required string AccessToken { get; set; }
    public required string TokenType { get; set; }
    public required DateTime Expires { get; set; }
}