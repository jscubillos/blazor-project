using Blazor.Project.Application.Doctors.Queries.Common;
using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Application.Doctors.Queries.GetAll;

public interface IGetAllDoctorQuery : IQueryWithoutParams<IEnumerable<GetDoctorOutputModel>>;