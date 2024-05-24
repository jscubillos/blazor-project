using Blazor.Project.Domain.Common;
using Dapper.Contrib.Extensions;

namespace Blazor.Project.Domain.Company;

[Table("Specialities")]
public class Speciality : Entity
{
    public required string Name { get; init; }
    
    [Computed]
    public virtual List<Doctor>? Doctors { get; init; }
}