using Blazor.Project.Application.Hospitals.Queries.Common;
using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Application.Hospitals.Queries.GetAll;

public interface IGetAllHospitalQuery : IQueryWithoutParams<IEnumerable<GetHospitalOutputModel>>;