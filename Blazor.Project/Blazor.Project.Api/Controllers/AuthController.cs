using Blazor.Project.Application.Users.Queries.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Project.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AuthController(ILoginUserQuery loginUserQuery) : ControllerBase
{
    [HttpPost("login"), AllowAnonymous]
    public IActionResult Login([FromBody] LoginUserInputModel inputModel)
    {
        return Ok(loginUserQuery.Execute(inputModel));
    }
}