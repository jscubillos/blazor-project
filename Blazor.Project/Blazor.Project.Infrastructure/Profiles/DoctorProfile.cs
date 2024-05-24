using AutoMapper;
using Blazor.Project.Application.Doctors.Commands.Register;
using Blazor.Project.Application.Doctors.Commands.Update;
using Blazor.Project.Application.Doctors.Queries.Common;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Infrastructure.Profiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<Doctor, DoctorFull>();
        
        CreateMap<RegisterDoctorInputModel, Doctor>();
        CreateMap<RegisterDoctorInputModel, Address>();
        
        CreateMap<UpdateDoctorInputModel, Doctor>();
        CreateMap<UpdateDoctorInputModel, Address>();

        CreateMap<DoctorFull, GetDoctorOutputModel>()
            .ForMember(dest => dest.Speciality, opt => opt.MapFrom(src => src.Speciality.Name))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode));

    }
}