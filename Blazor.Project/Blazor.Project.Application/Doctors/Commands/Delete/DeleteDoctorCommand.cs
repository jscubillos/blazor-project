using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Application.Doctors.Commands.Delete;

public class DeleteDoctorCommand(IAddressRepository addressRepository, IDoctorRepository doctorRepository) : IDeleteDoctorCommand
{
    public void Execute(int inputModel)
    {
        Validate(inputModel);
        
        var doctor = doctorRepository.GetById(inputModel);
        if(doctor == null)
            throw new ApplicationException("Doctor not found");
        
        doctorRepository.Delete(doctor);

        var address = addressRepository.GetById(doctor.AddressId);
        if (address != null)
            addressRepository.Delete(address);
    }

    public void Validate(int inputModel)
    {
        if(inputModel <= 0)
            throw new ApplicationException("Id is required");
    }
}