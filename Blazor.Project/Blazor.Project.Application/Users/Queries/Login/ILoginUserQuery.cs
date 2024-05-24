namespace Blazor.Project.Application.Users.Queries.Login;

public interface ILoginUserQuery
{
    LoginUserOutputModel Execute(LoginUserInputModel inputModel);
    
    void Validate(LoginUserInputModel inputModel);
}