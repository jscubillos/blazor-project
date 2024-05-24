using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Interfaces;

public interface IHospitalDoctorRepository : IRepository<HospitalDoctor>
{
    HospitalDoctor? GetByHospitalIdDoctorId(int hospitalId, int doctorId);
    void DeleteByHospitalIdDoctorId(int hospitalId, int doctorId);
}