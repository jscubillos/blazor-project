using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class DoctorRepository(SqliteConnection connection, IMapperService mapperService, IDatabaseRepository databaseRepository, ISpecialityRepository specialityRepository, IAddressRepository addressRepository)
    : Repository<Doctor>(connection, databaseRepository), IDoctorRepository
{
    private readonly SqliteConnection _connection = connection;
    public Doctor? GetByName(string name)
    {
        return _connection.QueryFirstOrDefault<Doctor>("SELECT * FROM Doctors WHERE Name = @Name", new { Name = name });
    }
    
    public DoctorFull? GetFullById(int id)
    {
        var doctor = GetById(id);
        if(doctor == null)
            return null;

        var doctorFull = mapperService.Map<Doctor, DoctorFull>(doctor);
        doctorFull.Speciality = specialityRepository.GetById(doctorFull.SpecialityId)!;
        doctorFull.Address = addressRepository.GetById(doctorFull.AddressId)!;
        return doctorFull;
    }
    
    public IEnumerable<DoctorFull> GetAllFull()
    {
        var listDoctorFull = new List<DoctorFull>();
        foreach (var doctor in GetAll())
        {
            var doctorFull = mapperService.Map<Doctor, DoctorFull>(doctor);
            doctorFull.Speciality = specialityRepository.GetById(doctorFull.SpecialityId)!;
            doctorFull.Address = addressRepository.GetById(doctorFull.AddressId)!;
            listDoctorFull.Add(doctorFull);
        }
        
        return listDoctorFull;
    }
}