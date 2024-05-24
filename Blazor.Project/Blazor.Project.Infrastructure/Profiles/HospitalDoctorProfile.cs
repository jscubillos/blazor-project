using AutoMapper;
using Blazor.Project.Application.HospitalsDoctors.Commands.Common;
using Blazor.Project.Application.HospitalsDoctors.Commands.Delete;
using Blazor.Project.Application.HospitalsDoctors.Commands.Register;
using Blazor.Project.Application.Specialities.Commands.Register;
using Blazor.Project.Application.Specialities.Commands.Update;
using Blazor.Project.Application.Specialities.Queries.Common;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Infrastructure.Profiles;

public class HospitalDoctorProfile : Profile
{
    public HospitalDoctorProfile()
    {
        CreateMap<RegisterHospitalDoctorInputModel, HospitalDoctor>();
        CreateMap<DeleteHospitalDoctorInputModel, HospitalDoctor>();
    }
}