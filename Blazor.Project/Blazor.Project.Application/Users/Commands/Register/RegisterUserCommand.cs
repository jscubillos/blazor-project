using Blazor.Project.Application.Interfaces;
using Blazor.Project.Common.Extensions;
using Blazor.Project.Domain.Users;

namespace Blazor.Project.Application.Users.Commands.Register;

public class RegisterUserCommand(
    IMapperService mapperService,
    IPasswordService passwordService,
    IUserRepository userRepository) : IRegisterUserCommand
{
    public void Execute(RegisterUserInputModel inputModel)
    {
        Validate(inputModel);
        
        var user = mapperService.Map<RegisterUserInputModel, User>(inputModel);
        user.PasswordSalt = passwordService.GenerateSalt();
        user.PasswordHash = passwordService.HashPassword(inputModel.Password, user.PasswordSalt);
        userRepository.Add(user);
    }
    
    public void Validate(RegisterUserInputModel inputModel)
    {
        ValidateName(inputModel.Name);
        ValidateEmail(inputModel.Email);
        ValidatePassword(inputModel.Password);
    }

    private void ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ApplicationException("Name is required");
    }
    
    private void ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new ApplicationException("Email is required");
        
        if(!email.ValidEmail())
            throw new ApplicationException("Invalid email");
        
        if (userRepository.GetByEmail(email)  != null)
            throw new ApplicationException("User already exists");
    }
    
    private void ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ApplicationException("Password is required");
    }
}