using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Users;

namespace Blazor.Project.Application.Users.Commands.Register;

public class RegisterUserCommand(
    IMapperService mapperService,
    IUserRepository userRepository) : IRegisterUserCommand
{
    public void Execute(RegisterUserInputModel inputModel)
    {
        var user = mapperService.Map<RegisterUserInputModel, User>(inputModel);
        user.Validate();
        
        var userExists = userRepository.GetByEmail(user.Email);
        if (userExists != null)
            throw new ApplicationException("User already exists");
        
        userRepository.Add(user);
    }
}