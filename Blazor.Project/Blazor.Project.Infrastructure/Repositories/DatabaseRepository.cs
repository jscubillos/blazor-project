using Blazor.Project.Application.Interfaces;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class DatabaseRepository(SqliteConnection connection) : IDatabaseRepository
{
    private readonly SqliteConnection _connection = connection;

    public void Initialize()
    {
        _connection.Open();

        using var command = _connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY,
                Name TEXT NOT NULL,
                Email TEXT NOT NULL,
                Password TEXT NOT NULL
            );
        ";
        command.ExecuteNonQuery();
    }
}