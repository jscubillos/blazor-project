using Blazor.Project.Application.Doctors.Commands.Common;

namespace Blazor.Project.Application.Doctors.Commands.Update;

public class UpdateDoctorInputModel : DoctorInputModel
{
    public required int Id { get; set; }
}