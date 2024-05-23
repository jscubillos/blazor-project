using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Users;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class UserRepository(SqliteConnection connection, IDatabaseRepository databaseRepository)
    : Repository<User>(connection, databaseRepository), IUserRepository
{
    private readonly SqliteConnection _connection = connection;

    public User? GetByEmail(string email)
    {
        return _connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Email = @Email", new { Email = email });
    }
}