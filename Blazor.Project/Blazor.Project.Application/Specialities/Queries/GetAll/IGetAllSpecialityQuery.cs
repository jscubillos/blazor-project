using Blazor.Project.Application.Interfaces;
using Blazor.Project.Application.Specialities.Queries.Common;

namespace Blazor.Project.Application.Specialities.Queries.GetAll;

public interface IGetAllSpecialityQuery : IQueryWithoutParams<IEnumerable<GetSpecialityOutputModel>>;