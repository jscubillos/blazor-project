using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Users;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class UserRepository(SqliteConnection connection, IDatabaseRepository databaseRepository)
    : Repository(connection, databaseRepository)
        , IUserRepository
{
    public User? GetByEmail(string email)
    {
        return null;
    }
}