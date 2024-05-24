using System.ComponentModel.DataAnnotations.Schema;
using Blazor.Project.Domain.Common;

namespace Blazor.Project.Domain.Company;

[Table("Specialities")]
public class Speciality : Entity
{
    public required string Name { get; set; }
}