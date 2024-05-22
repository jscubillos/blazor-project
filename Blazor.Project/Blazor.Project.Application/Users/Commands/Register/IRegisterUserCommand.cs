namespace Blazor.Project.Application.Users.Commands.Register;

public interface IRegisterUserCommand
{
    void Execute(RegisterUserInputModel inputModel);
}