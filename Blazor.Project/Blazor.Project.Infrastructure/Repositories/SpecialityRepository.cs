using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class SpecialityRepository(SqliteConnection connection, IDatabaseRepository databaseRepository)
    : Repository<Speciality>(connection, databaseRepository), ISpecialityRepository
{
}