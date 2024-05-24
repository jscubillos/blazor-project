using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Doctors.Commands.Register;

public class RegisterDoctorCommand(IAddressRepository addressRepository, IMapperService mapperService, IDoctorRepository doctorRepository) : IRegisterDoctorCommand
{
    public void Execute(RegisterDoctorInputModel inputModel)
    {
        Validate(inputModel);
        var doctor = mapperService.Map<RegisterDoctorInputModel, Doctor>(inputModel);
        var address = mapperService.Map<RegisterDoctorInputModel, Address>(inputModel);
        
        doctor.AddressId =  addressRepository.Add(address);
        doctorRepository.Add(doctor);
    }

    public void Validate(RegisterDoctorInputModel inputModel)
    {
        if(string.IsNullOrEmpty(inputModel.Name))
            throw new ApplicationException("Name is required");
        
        if(doctorRepository.GetByName(inputModel.Name) != null)
            throw new ApplicationException("Doctor already exists");
        
        if(inputModel.SpecialityId <= 0)
            throw new ApplicationException("Speciality is required");
        
        if(string.IsNullOrEmpty(inputModel.Street))
            throw new ApplicationException("Street is required");  
        
        if(string.IsNullOrEmpty(inputModel.City))
            throw new ApplicationException("City is required");
        
        if(string.IsNullOrEmpty(inputModel.State))
            throw new ApplicationException("State is required");

        if(string.IsNullOrEmpty(inputModel.ZipCode))
            throw new ApplicationException("ZipCode is required");
    }
}