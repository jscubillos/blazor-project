using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class SpecialityRepository(SqliteConnection connection, IDatabaseRepository databaseRepository)
    : Repository<Speciality>(connection, databaseRepository), ISpecialityRepository
{
    public Speciality? GetByName(string name)
    {
        const string query = $"SELECT * FROM Specialities WHERE Name = @Name";
        return connection.QueryFirstOrDefault<Speciality>(query, new { Name = name });
    }
}