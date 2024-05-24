using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.HospitalsDoctors.Queries.Get;

public class GetHospitalDoctorQuery(IMapperService mapperService, IHospitalRepository hospitalRepository) : IGetHospitalDoctorQuery
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