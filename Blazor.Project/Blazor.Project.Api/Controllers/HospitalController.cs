using Blazor.Project.Application.Hospitals.Commands.Delete;
using Blazor.Project.Application.Hospitals.Commands.Register;
using Blazor.Project.Application.Hospitals.Commands.Update;
using Blazor.Project.Application.Hospitals.Queries.Get;
using Blazor.Project.Application.Hospitals.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Project.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class HospitalController(
    IRegisterHospitalCommand registerHospitalCommand,
    IUpdateHospitalCommand updateHospitalCommand,
    IDeleteHospitalCommand deleteHospitalCommand,
    IGetHospitalQuery getHospitalQuery, 
    IGetAllHospitalQuery getAllHospitalQuery) : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RegisterHospitalInputModel inputModel)
    {
        registerHospitalCommand.Execute(inputModel);
        return Created();
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] UpdateHospitalInputModel inputModel)
    {
        updateHospitalCommand.Execute(inputModel);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        deleteHospitalCommand.Execute(id);
        return NoContent();
    }
    
    [HttpGet]
    public IActionResult Get([FromQuery] GetHospitalInputModel inputModel)
    {
        return Ok(getHospitalQuery.Execute(inputModel));
    }
    
    [HttpGet("all")]
    public IActionResult GetAll()
    {
        return Ok(getAllHospitalQuery.Execute());
    }
}