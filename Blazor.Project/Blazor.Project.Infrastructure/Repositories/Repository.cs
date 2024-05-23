using Blazor.Project.Application.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class Repository : IRepository
{
        private readonly SqliteConnection _connection;

        public Repository(SqliteConnection connection, IDatabaseRepository databaseRepository)
        {
            _connection = connection;
            databaseRepository.Initialize();
        }

    public void Add<T>(T entity) where T : class
    {
        // using var connection = new SqliteConnection(_connectionString);
        // connection.Open();
        // connection.Execute(entity);

        // var sql = $"INSERT INTO {typeof(T).Name}s VALUES (@Entity)";
        // _connection.Execute(sql, new { Entity = entity });

        _connection.Insert(entity);
    }
}