using AutoMapper;
using Blazor.Project.Application.Hospitals.Commands.Register;
using Blazor.Project.Application.Hospitals.Commands.Update;
using Blazor.Project.Application.Hospitals.Queries.Common;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Infrastructure.Profiles;

public class HospitalProfile : Profile
{
    public HospitalProfile()
    {
        CreateMap<Hospital, HospitalFull>();
        
        CreateMap<RegisterHospitalInputModel, Hospital>();
        CreateMap<RegisterHospitalInputModel, Address>();
        
        CreateMap<UpdateHospitalInputModel, Hospital>();
        CreateMap<UpdateHospitalInputModel, Address>();

        CreateMap<HospitalFull, GetHospitalOutputModel>()
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode));

    }
}