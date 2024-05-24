namespace Blazor.Project.Application.Doctors.Queries.Common;

public class GetDoctorOutputModel
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int SpecialityId { get; set; }
    public required string Speciality { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
}