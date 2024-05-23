using Blazor.Project.Application.Users.Commands.Login;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Project.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(ILoginUserCommand loginUserCommand) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUserInputModel inputModel)
    {
        return Ok(loginUserCommand.Execute(inputModel));
    }
}