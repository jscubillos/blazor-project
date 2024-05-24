using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Interfaces;

public interface ISpecialityRepository: IRepository<Speciality>
{
    Speciality? GetByName(string name);
}