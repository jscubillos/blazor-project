using System.ComponentModel.DataAnnotations.Schema;
using Blazor.Project.Domain.Common;

namespace Blazor.Project.Domain.Company;

[Table("Addresses")]
public class Address : Entity
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
}