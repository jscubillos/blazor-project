using Blazor.Project.Application.Doctors.Commands.Delete;
using Blazor.Project.Application.Doctors.Commands.Register;
using Blazor.Project.Application.Doctors.Commands.Update;
using Blazor.Project.Application.Doctors.Queries.Get;
using Blazor.Project.Application.Doctors.Queries.GetAll;
using Blazor.Project.Application.Hospitals.Commands.Delete;
using Blazor.Project.Application.Hospitals.Commands.Register;
using Blazor.Project.Application.Hospitals.Commands.Update;
using Blazor.Project.Application.Hospitals.Queries.Get;
using Blazor.Project.Application.Hospitals.Queries.GetAll;
using Blazor.Project.Application.HospitalsDoctors.Commands.Delete;
using Blazor.Project.Application.HospitalsDoctors.Commands.Register;
using Blazor.Project.Application.Interfaces;
using Blazor.Project.Application.Specialities.Commands.Delete;
using Blazor.Project.Application.Specialities.Commands.Register;
using Blazor.Project.Application.Specialities.Commands.Update;
using Blazor.Project.Application.Specialities.Queries.Get;
using Blazor.Project.Application.Specialities.Queries.GetAll;
using Blazor.Project.Application.Users.Commands.Register;
using Blazor.Project.Application.Users.Queries.Login;
using Blazor.Project.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Project.Infrastructure.DependencyInjection;

public static class IocDependencyInjection
{
    public static void AddIoCLibrary(this IServiceCollection services)
    {   
        /*TODO: tentar substituir pelo Lamar ou StructureMap*/
        
        //Services
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IMapperService, MapperService>();
        services.AddScoped<IPasswordService, PasswordService>();
        
        //Application
        services.AddScoped<IRegisterUserCommand, RegisterUserCommand>();
        services.AddScoped<ILoginUserQuery, LoginUserQuery>();
        services.AddScoped<IRegisterSpecialityCommand, RegisterSpecialityCommand>();
        services.AddScoped<IUpdateSpecialityCommand, UpdateSpecialityCommand>();
        services.AddScoped<IDeleteSpecialityCommand, DeleteSpecialityCommand>();
        services.AddScoped<IGetSpecialityQuery, GetSpecialityQuery>();
        services.AddScoped<IGetAllSpecialityQuery, GetAllSpecialityQuery>();
        services.AddScoped<IRegisterDoctorCommand, RegisterDoctorCommand>();
        services.AddScoped<IUpdateDoctorCommand, UpdateDoctorCommand>();
        services.AddScoped<IDeleteDoctorCommand, DeleteDoctorCommand>();
        services.AddScoped<IGetDoctorQuery, GetDoctorQuery>();
        services.AddScoped<IGetAllDoctorQuery, GetAllDoctorQuery>();
        services.AddScoped<IRegisterHospitalCommand, RegisterHospitalCommand>();
        services.AddScoped<IUpdateHospitalCommand, UpdateHospitalCommand>();
        services.AddScoped<IDeleteHospitalCommand, DeleteHospitalCommand>();
        services.AddScoped<IGetHospitalQuery, GetHospitalQuery>();
        services.AddScoped<IGetAllHospitalQuery, GetAllHospitalQuery>();
        services.AddScoped<IRegisterHospitalDoctorCommand, RegisterHospitalDoctorCommand>();
        services.AddScoped<IDeleteHospitalDoctorCommand, DeleteHospitalDoctorCommand>();
    }
}