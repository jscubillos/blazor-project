using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.HospitalsDoctors.Queries.GetAll;

public class GetAllHospitalQuery(IMapperService mapperService, IHospitalRepository doctorRepository) : IGetAllHospitalQuery
{
    public IEnumerable<GetHospitalOutputModel> Execute()
    {
        var doctors = doctorRepository.GetAllFull();
        return mapperService.MapList<HospitalFull, GetHospitalOutputModel>(doctors);
    }
}