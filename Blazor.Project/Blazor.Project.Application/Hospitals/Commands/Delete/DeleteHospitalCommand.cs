using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Application.Hospitals.Commands.Delete;

public class DeleteHospitalCommand(IAddressRepository addressRepository, IHospitalRepository hospitalRepository) : IDeleteHospitalCommand
{
    public void Execute(int inputModel)
    {
        Validate(inputModel);
        
        var hospital = hospitalRepository.GetById(inputModel);
        if(hospital == null)
            throw new ApplicationException("Hospital not found");
        
        hospitalRepository.Delete(hospital);

        var address = addressRepository.GetById(hospital.AddressId);
        if (address != null)
            addressRepository.Delete(address);
    }

    public void Validate(int inputModel)
    {
        if(inputModel <= 0)
            throw new ApplicationException("Id is required");
    }
}