using Blazor.Project.Application.Interfaces;
using Microsoft.Data.Sqlite;

namespace Blazor.Project.Infrastructure.Repositories;

public class DatabaseRepository(SqliteConnection connection) : IDatabaseRepository
{
    public void Initialize()
    {
        connection.Open();
        
        CreateTableUsers();
        CreateTableSpecialities();
        CreateTableAddresses();
        CreateTableDoctors();
        CreateTableHospitals();
        CreateTableHospitalsDoctor();
    }

    private void CreateTableHospitalsDoctor()
    {
        using var command = connection.CreateCommand();
        command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS HospitalsDoctors (
                HospitalId INTEGER NOT NULL,
                DoctorId INTEGER NOT NULL,
                PRIMARY KEY (HospitalId, DoctorId),
                FOREIGN KEY (HospitalId) REFERENCES Hospitals(Id),
                FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)
            );
           """;
        command.ExecuteNonQuery();
    }

    private void CreateTableHospitals()
    {
        using var command = connection.CreateCommand();
        command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Hospitals (
                Id INTEGER PRIMARY KEY,
                Name TEXT NOT NULL,
                AddressId INTEGER NOT NULL,
                FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
            );
           """;
        command.ExecuteNonQuery();
    }

    private void CreateTableDoctors()
    {
        using var command = connection.CreateCommand();
        command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Doctors (
                Id INTEGER PRIMARY KEY,
                Name TEXT NOT NULL,
                SpecialityId INTEGER NOT NULL,
                AddressId INTEGER NOT NULL,
                FOREIGN KEY (SpecialityId) REFERENCES Specialities(Id),
                FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
            );
           """;
        command.ExecuteNonQuery();
    }

    private void CreateTableAddresses()
    {
        using var command = connection.CreateCommand();
        command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Addresses (
                Id INTEGER PRIMARY KEY,
                Street TEXT NOT NULL,
                City TEXT NOT NULL,
                State TEXT NOT NULL,
                ZipCode TEXT NOT NULL
            );
           """;
        command.ExecuteNonQuery();
    }

    private void CreateTableSpecialities()
    {
        using var command = connection.CreateCommand();
        command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Specialities (
                Id INTEGER PRIMARY KEY,
                Name TEXT NOT NULL
            );
           """;
        command.ExecuteNonQuery();
    }

    private void CreateTableUsers()
    {
        using var command = connection.CreateCommand();
        command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY,
                Name TEXT NOT NULL,
                Email TEXT NOT NULL,
                PasswordHash TEXT NOT NULL,
                PasswordSalt TEXT NOT NULL
            );
           """;
        command.ExecuteNonQuery();
    }
}