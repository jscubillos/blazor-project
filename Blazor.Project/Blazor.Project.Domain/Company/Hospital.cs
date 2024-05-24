using Blazor.Project.Domain.Common;

namespace Blazor.Project.Domain.Company;

public class Hospital : Entity
{
    public required string Name { get; set; }
    public required Address Address { get; set; }
    
    public virtual List<Doctor>? Doctors { get; set; }
}
