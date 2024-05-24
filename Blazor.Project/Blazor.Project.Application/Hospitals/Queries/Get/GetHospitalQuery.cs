using Blazor.Project.Application.Hospitals.Queries.Common;
using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Hospitals.Queries.Get;

public class GetHospitalQuery(IMapperService mapperService, IHospitalRepository hospitalRepository) : IGetHospitalQuery
{
    public GetHospitalOutputModel Execute(GetHospitalInputModel inputModel)
    {
        Validate(inputModel);
        
        var doctor = hospitalRepository.GetFullById(inputModel.Id);
        if(doctor == null)
            throw new ApplicationException("Hospital not found");
        
        return mapperService.Map<HospitalFull, GetHospitalOutputModel>(doctor);
    }

    public void Validate(GetHospitalInputModel inputModel)
    {
        if(inputModel.Id <= 0)
            throw new ApplicationException("Id is required");
    }
}