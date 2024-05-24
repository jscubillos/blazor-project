using Blazor.Project.Application.HospitalsDoctors.Commands.Common;
using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Application.HospitalsDoctors.Commands.Delete;

public interface IDeleteHospitalDoctorCommand : ICommand<HospitalDoctorInputModel>;