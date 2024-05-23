namespace Blazor.Project.Domain.Common;

public abstract class Dominio : IDomain
{
    public int Id { get; set; }

    public abstract void Validate();
}