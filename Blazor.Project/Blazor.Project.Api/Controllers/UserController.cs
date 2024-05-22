using Blazor.Project.Application.Users.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Project.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IRegisterUserCommand registerUserCommand) : ControllerBase
{
    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterUserInputModel inputModel)
    {
        registerUserCommand.Execute(inputModel);
        return Ok();
    }
    
}