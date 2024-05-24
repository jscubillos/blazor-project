using Blazor.Project.Application.Hospitals.Commands.Common;

namespace Blazor.Project.Application.Hospitals.Commands.Update;

public class UpdateHospitalInputModel : HospitalInputModel
{
    public required int Id { get; set; }
}