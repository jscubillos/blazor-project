using Blazor.Project.Application.Interfaces;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
        private readonly SqliteConnection _connection;

        public Repository(SqliteConnection connection, IDatabaseRepository databaseRepository)
        {
            _connection = connection;
            databaseRepository.Initialize();
        }

    public virtual int Add(T entity)
    {
        return (int)_connection.Insert(entity);
    }
    
    public virtual void Update(T entity)
    {
        _connection.Update(entity);
    }
    
    public virtual void Delete(T entity)
    {
        _connection.Delete(entity);
    }
    
    public virtual IEnumerable<T> GetAll()
    {
        return _connection.GetAll<T>();
    }
    
    public virtual T GetById(int id)
    {
        return _connection.Get<T>(id);
    }
}