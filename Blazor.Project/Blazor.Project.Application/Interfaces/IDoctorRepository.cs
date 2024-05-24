using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Interfaces;

public interface IDoctorRepository : IRepository<Doctor>
{
    Doctor? GetByName(string name);
    DoctorFull? GetFullById(int id);
    IEnumerable<DoctorFull> GetAllFull();
}