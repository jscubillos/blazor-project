using Blazor.Project.Application.Users.Commands.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Project.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController(IRegisterUserCommand registerUserCommand) : ControllerBase
{   
    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterUserInputModel inputModel)
    {
        registerUserCommand.Execute(inputModel);
        return Created();
    }
}