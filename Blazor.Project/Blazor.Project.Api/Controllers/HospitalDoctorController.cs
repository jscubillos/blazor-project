using Blazor.Project.Application.HospitalsDoctors.Commands.Delete;
using Blazor.Project.Application.HospitalsDoctors.Commands.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Project.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class HospitalDoctorController(
    IRegisterHospitalDoctorCommand registerHospitalDoctorCommand,
    IDeleteHospitalDoctorCommand deleteHospitalDoctorCommand) : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RegisterHospitalDoctorInputModel inputModel)
    {
        registerHospitalDoctorCommand.Execute(inputModel);
        return Created();
    }
    
    [HttpDelete]
    public IActionResult Delete([FromBody] DeleteHospitalDoctorInputModel inputModel)
    {
        deleteHospitalDoctorCommand.Execute(inputModel);
        return NoContent();
    }
}