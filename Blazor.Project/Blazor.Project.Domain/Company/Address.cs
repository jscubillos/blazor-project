using Blazor.Project.Domain.Common;

namespace Blazor.Project.Domain.Company;

public class Address : Entity
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
    
    public virtual List<Doctor>? Doctors { get; set; }
    public virtual List<Hospital>? Hospitals { get; set; }
}