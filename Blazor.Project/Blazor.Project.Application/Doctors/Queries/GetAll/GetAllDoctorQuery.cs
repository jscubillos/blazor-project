using Blazor.Project.Application.Doctors.Queries.Common;
using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Doctors.Queries.GetAll;

public class GetAllDoctorQuery(IMapperService mapperService, IDoctorRepository doctorRepository) : IGetAllDoctorQuery
{
    public IEnumerable<GetDoctorOutputModel> Execute()
    {
        var doctors = doctorRepository.GetAllFull();
        return mapperService.MapList<DoctorFull, GetDoctorOutputModel>(doctors);
    }
}