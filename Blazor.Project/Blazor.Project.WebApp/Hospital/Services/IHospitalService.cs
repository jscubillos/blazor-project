using Blazor.Project.WebApp.Hospital.Models;

namespace Blazor.Project.WebApp.Hospital.Services;

public interface IHospitalService
{
    Task<List<GetHospitalOutputModel>?> GetAll();
}