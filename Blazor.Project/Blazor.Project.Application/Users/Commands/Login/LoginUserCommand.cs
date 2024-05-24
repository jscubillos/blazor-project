using Blazor.Project.Application.Interfaces;
using Blazor.Project.Common.Extensions;
using Blazor.Project.Domain.Authentication;

namespace Blazor.Project.Application.Users.Commands.Login;

public class LoginUserCommand(IAuthenticationService authenticationService, IMapperService mapperService, IPasswordService passwordService, IUserRepository userRepository) : ILoginUserCommand
{
    public LoginUserOutputModel Execute(LoginUserInputModel inputModel)
    {
        Validate(inputModel);
        var user = userRepository.GetByEmail(inputModel.Email);
        if (user == null)
            throw new ApplicationException("User not found");
        
        if(!passwordService.VerifyPassword(inputModel.Password, user.PasswordHash, user.PasswordSalt))
            throw new ApplicationException("Invalid password");

        var jwtToken = authenticationService.GenerateJwtToken(user);
        return mapperService.Map<JwtToken, LoginUserOutputModel>(jwtToken);
    }

    public void Validate(LoginUserInputModel inputModel)
    {
        if (string.IsNullOrWhiteSpace(inputModel.Email))
            throw new ApplicationException("Email is required");

        if(!inputModel.Email.ValidEmail())
            throw new ApplicationException("Invalid email");
        
        if (string.IsNullOrWhiteSpace(inputModel.Password))
            throw new ApplicationException("Password is required");
    }
}