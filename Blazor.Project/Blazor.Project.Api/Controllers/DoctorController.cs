using Blazor.Project.Application.Doctors.Commands.Delete;
using Blazor.Project.Application.Doctors.Commands.Register;
using Blazor.Project.Application.Doctors.Commands.Update;
using Blazor.Project.Application.Doctors.Queries.Get;
using Blazor.Project.Application.Doctors.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Project.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class DoctorController(
    IRegisterDoctorCommand registerDoctorCommand,
    IUpdateDoctorCommand updateDoctorCommand,
    IDeleteDoctorCommand deleteDoctorCommand,
    IGetDoctorQuery getDoctorQuery, 
    IGetAllDoctorQuery getAllDoctorQuery) : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RegisterDoctorInputModel inputModel)
    {
        registerDoctorCommand.Execute(inputModel);
        return Created();
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] UpdateDoctorInputModel inputModel)
    {
        updateDoctorCommand.Execute(inputModel);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        deleteDoctorCommand.Execute(id);
        return NoContent();
    }
    
    [HttpGet]
    public IActionResult Get([FromQuery] GetDoctorInputModel inputModel)
    {
        return Ok(getDoctorQuery.Execute(inputModel));
    }
    
    [HttpGet("all")]
    public IActionResult GetAll()
    {
        return Ok(getAllDoctorQuery.Execute());
    }
}