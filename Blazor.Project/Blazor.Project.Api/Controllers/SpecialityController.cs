using Blazor.Project.Application.Specialities.Commands.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Project.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SpecialityController(IRegisterSpecialityCommand registerSpecialityCommand) : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RegisterSpecialityInputModel inputModel)
    {
        registerSpecialityCommand.Execute(inputModel);
        return Created();
    }
}