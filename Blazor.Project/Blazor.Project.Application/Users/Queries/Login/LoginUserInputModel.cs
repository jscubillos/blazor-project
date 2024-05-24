namespace Blazor.Project.Application.Users.Queries.Login;

public class LoginUserInputModel
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}