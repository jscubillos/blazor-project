namespace Blazor.Project.Application.Hospitals.Queries.Common;

public class GetHospitalOutputModel
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
}