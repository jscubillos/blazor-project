namespace Blazor.Project.Application.Users.Commands.Login;

public class LoginUserOutputModel
{
    public required string Token { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string RefreshToken { get; set; }
    public required DateTime Expires { get; set; }
}