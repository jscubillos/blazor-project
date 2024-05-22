namespace Blazor.Project.Application.Users.Commands.Register;

public class RegisterUserInputModel
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}