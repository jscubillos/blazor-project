using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class HospitalDoctorRepository(SqliteConnection connection, IDatabaseRepository databaseRepository)
    : Repository<HospitalDoctor>(connection, databaseRepository), IHospitalDoctorRepository
{
    private readonly SqliteConnection _connection = connection;
    public HospitalDoctor? GetByHospitalIdDoctorId(int hospitalId, int doctorId)
    {
        var sql = "SELECT * FROM HospitalsDoctors WHERE HospitalId = @HospitalId AND DoctorId = @DoctorId";
        return _connection.QueryFirstOrDefault<HospitalDoctor>(sql, new { HospitalId = hospitalId, DoctorId = doctorId });
    }

    public void DeleteByHospitalIdDoctorId(int hospitalId, int doctorId)
    {
        var sql = "DELETE FROM HospitalsDoctors WHERE HospitalId = @HospitalId AND DoctorId = @DoctorId";
        _connection.Execute(sql, new { HospitalId = hospitalId, DoctorId = doctorId });
    }
}