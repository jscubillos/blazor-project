using Blazor.Project.Application.Doctors.Queries.Common;
using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Application.Doctors.Queries.Get;

public interface IGetDoctorQuery : IQuery<GetDoctorInputModel, GetDoctorOutputModel>;