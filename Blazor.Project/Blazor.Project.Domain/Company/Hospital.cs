using Blazor.Project.Domain.Common;

namespace Blazor.Project.Domain.Company;

public class Hospital : Entity
{
    public required string Name { get; set; }
    public required int AddressId { get; set; }
}
