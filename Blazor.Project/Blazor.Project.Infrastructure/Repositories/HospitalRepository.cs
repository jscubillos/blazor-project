using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class HospitalRepository(SqliteConnection connection, IMapperService mapperService, IDatabaseRepository databaseRepository, IAddressRepository addressRepository)
    : Repository<Hospital>(connection, databaseRepository), IHospitalRepository
{
    private readonly SqliteConnection _connection = connection;
    public Hospital? GetByName(string name)
    {
        return _connection.QueryFirstOrDefault<Hospital>("SELECT * FROM Hospitals WHERE Name = @Name", new { Name = name });
    }

    public HospitalFull? GetFullById(int id)
    {
        var hospital = GetById(id);
        if(hospital == null)
            return null;

        var hospitalFull = mapperService.Map<Hospital, HospitalFull>(hospital);
        hospitalFull.Address = addressRepository.GetById(hospitalFull.AddressId)!;
        return hospitalFull;
    }

    public IEnumerable<HospitalFull> GetAllFull()
    {
        var listHospitalFull = new List<HospitalFull>();
        foreach (var hospital in GetAll())
        {
            var hospitalFull = mapperService.Map<Hospital, HospitalFull>(hospital);
            hospitalFull.Address = addressRepository.GetById(hospitalFull.AddressId)!;
            listHospitalFull.Add(hospitalFull);
        }
        
        return listHospitalFull;
    }
}