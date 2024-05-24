using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Interfaces;

public interface IHospitalRepository : IRepository<Hospital>
{
    Hospital? GetByName(string name);
    HospitalFull? GetFullById(int id);
    IEnumerable<HospitalFull> GetAllFull();
}