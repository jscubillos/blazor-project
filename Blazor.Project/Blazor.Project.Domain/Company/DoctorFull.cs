namespace Blazor.Project.Domain.Company;

public class DoctorFull : Doctor
{
    public required Speciality Speciality { get; set; }
    public required Address Address { get; set; }
}