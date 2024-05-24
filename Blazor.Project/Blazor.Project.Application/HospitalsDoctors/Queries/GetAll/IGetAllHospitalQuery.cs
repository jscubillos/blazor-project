using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Application.HospitalsDoctors.Queries.GetAll;

public interface IGetAllHospitalQuery : IQueryWithoutParams<IEnumerable<GetHospitalOutputModel>>;