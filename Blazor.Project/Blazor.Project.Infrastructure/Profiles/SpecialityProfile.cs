using AutoMapper;
using Blazor.Project.Application.Specialities.Commands.Register;
using Blazor.Project.Application.Specialities.Queries.Common;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Infrastructure.Profiles;

public class SpecialityProfile : Profile
{
    public SpecialityProfile()
    {
        CreateMap<RegisterSpecialityInputModel, Speciality>();
        CreateMap<Speciality, GetSpecialityOutputModel>();
    }
}