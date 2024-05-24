using Blazor.Project.Application.Interfaces;
using Blazor.Project.Application.Specialities.Queries.Common;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Specialities.Queries.Get;

public class GetSpecialityQuery(IMapperService mapperService, ISpecialityRepository specialityRepository) : IGetSpecialityQuery
{
    public GetSpecialityOutputModel Execute(GetSpecialityInputModel inputModel)
    {
        Validate(inputModel);
        var speciality = specialityRepository.GetById(inputModel.Id);
        return mapperService.Map<Speciality, GetSpecialityOutputModel>(speciality);
    }

    public void Validate(GetSpecialityInputModel inputModel)
    {
        if(inputModel.Id <= 0)
            throw new ApplicationException("Id is required");
    }
}