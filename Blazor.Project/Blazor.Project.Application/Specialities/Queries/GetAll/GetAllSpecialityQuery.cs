using Blazor.Project.Application.Interfaces;
using Blazor.Project.Application.Specialities.Queries.Common;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Specialities.Queries.GetAll;

public class GetAllSpecialityQuery(IMapperService mapperService, ISpecialityRepository specialityRepository) : IGetAllSpecialityQuery
{
    public IEnumerable<GetSpecialityOutputModel> Execute()
    {
        var specialities = specialityRepository.GetAll();
        return mapperService.MapList<Speciality, GetSpecialityOutputModel>(specialities);
    }
}