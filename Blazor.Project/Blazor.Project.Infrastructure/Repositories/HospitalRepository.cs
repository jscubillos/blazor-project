using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class HospitalRepository(SqliteConnection connection, IDatabaseRepository databaseRepository)
    : Repository<Hospital>(connection, databaseRepository), IHospitalRepository
{
    private readonly SqliteConnection _connection = connection;
}