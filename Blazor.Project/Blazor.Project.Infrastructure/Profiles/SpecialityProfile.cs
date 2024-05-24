using AutoMapper;
using Blazor.Project.Application.Specialities.Commands.Register;
using Blazor.Project.Application.Users.Commands.Register;
using Blazor.Project.Application.Users.Queries.Login;
using Blazor.Project.Domain.Company;
using Blazor.Project.Domain.Users;

namespace Blazor.Project.Infrastructure.Profiles;

public class SpecialityProfile : Profile
{
    public SpecialityProfile()
    {
        CreateMap<RegisterSpecialityInputModel, Speciality>();
    }
}