using Blazor.Project.WebApp.Doctor.Models;

namespace Blazor.Project.WebApp.Doctor.Services;

public interface IDoctorService
{
    Task<List<GetDoctorOutputModel>?> GetAll();
}