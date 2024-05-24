namespace Blazor.Project.Application.Users.Queries.Login;

public class LoginUserOutputModel
{
    public required string AccessToken { get; init; }
    public required string TokenType { get; init; }
    public required DateTime Expires { get; init; }
}