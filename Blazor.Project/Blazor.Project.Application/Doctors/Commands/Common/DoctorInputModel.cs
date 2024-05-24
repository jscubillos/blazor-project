namespace Blazor.Project.Application.Doctors.Commands.Common;

public class DoctorInputModel
{
      public required string Name { get; set; }
      public required int SpecialityId { get; set; }
      public required string Street { get; set; }
      public required string City { get; set; }
      public required string State { get; set; }
      public required string ZipCode { get; set; }
 }