using Blazor.Project.WebApp.Hospital.Models;

namespace Blazor.Project.WebApp.Hospital.Services;

public interface IHospitalService
{
    Task<List<GetHospitalOutputModel>?> GetAll();

     Task Register(HospitalInputModel inputModel);
     Task Delete(int id);
     Task<GetHospitalOutputModel?> GetById(int id);
     Task Update(HospitalInputModel inputModel);
}