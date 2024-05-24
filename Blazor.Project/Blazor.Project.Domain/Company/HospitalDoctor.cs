using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Project.Domain.Company;

[Table("HospitalsDoctors")]
public class HospitalDoctor
{
    public required int HospitalId { get; set; }
    public required int DoctorId { get; set; }
}