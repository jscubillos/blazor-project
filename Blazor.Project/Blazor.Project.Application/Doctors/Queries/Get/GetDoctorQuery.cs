using Blazor.Project.Application.Doctors.Queries.Common;
using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Doctors.Queries.Get;

public class GetDoctorQuery(IMapperService mapperService, IDoctorRepository doctorRepository) : IGetDoctorQuery
{
    public GetDoctorOutputModel Execute(GetDoctorInputModel inputModel)
    {
        Validate(inputModel);
        
        var doctor = doctorRepository.GetFullById(inputModel.Id);
        if(doctor == null)
            throw new ApplicationException("Doctor not found");
        
        return mapperService.Map<DoctorFull, GetDoctorOutputModel>(doctor);
    }

    public void Validate(GetDoctorInputModel inputModel)
    {
        if(inputModel.Id <= 0)
            throw new ApplicationException("Id is required");
    }
}