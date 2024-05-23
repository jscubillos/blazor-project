namespace Blazor.Project.Application.Users.Commands.Login;

public interface ILoginUserCommand
{
    LoginUserOutputModel Execute(LoginUserInputModel inputModel);
    
    void Validate(LoginUserInputModel inputModel);
}