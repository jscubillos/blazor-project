using Blazor.Project.Domain.Common;
using Dapper.Contrib.Extensions;

namespace Blazor.Project.Domain.Company;

public class Doctor : Entity
{
    public required string Name { get; set; }
    public required int SpecialityId { get; set; }
    public required int AddressId { get; set; }
    
    [Computed]
    public virtual required Speciality Speciality { get; set; }
    [Computed]
    public virtual required Address Address { get; set; }
    [Computed]
    public virtual List<Hospital>? Hospitals { get; set; }
}