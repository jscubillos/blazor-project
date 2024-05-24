using Blazor.Project.Application.Specialities.Commands.Register;
using Blazor.Project.Application.Specialities.Commands.Update;
using Blazor.Project.Application.Specialities.Queries.Get;
using Blazor.Project.Application.Specialities.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Project.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SpecialityController(IRegisterSpecialityCommand registerSpecialityCommand, IUpdateSpecialityCommand updateSpecialityCommand, IGetSpecialityQuery getSpecialityQuery,  IGetAllSpecialityQuery getAllSpecialityQuery) : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RegisterSpecialityInputModel inputModel)
    {
        registerSpecialityCommand.Execute(inputModel);
        return Created();
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] UpdateSpecialityInputModel inputModel)
    {
        updateSpecialityCommand.Execute(inputModel);
        return NoContent();
    }
    
    [HttpGet]
    public IActionResult Get([FromQuery] GetSpecialityInputModel inputModel)
    {
        return Ok(getSpecialityQuery.Execute(inputModel));
    }
    
    [HttpGet("all")]
    public IActionResult GetAll()
    {
        return Ok(getAllSpecialityQuery.Execute());
    }
}