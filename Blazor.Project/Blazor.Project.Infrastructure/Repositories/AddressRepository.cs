using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class AddressRepository(SqliteConnection connection, IDatabaseRepository databaseRepository)
    : Repository<Address>(connection, databaseRepository), IAddressRepository
{
    private readonly SqliteConnection _connection = connection;
}