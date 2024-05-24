using Blazor.Project.Application.Users.Commands.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Project.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AuthController(ILoginUserCommand loginUserCommand) : ControllerBase
{
    [HttpPost("login"), AllowAnonymous]
    public IActionResult Login([FromBody] LoginUserInputModel inputModel)
    {
        return Ok(loginUserCommand.Execute(inputModel));
    }
}