using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;
using Blazor.Project.Domain.Users;
using Blazor.Project.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace Blazor.Project.Infrastructure.DependencyInjection;

public static class RepositoryDependencyInjection
{
    public static void AddIoCRepository(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        //Database
        services.AddSingleton(new SqliteConnection(configurationManager.GetConnectionString("DefaultConnection")));
        services.AddTransient<IDatabaseRepository, DatabaseRepository>();
        services.AddTransient<IRepository<User>, Repository<User>>();
        services.AddTransient<IRepository<Speciality>, Repository<Speciality>>();
        
        //Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISpecialityRepository, SpecialityRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IHospitalRepository, HospitalRepository>();
    }
}