using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Hospitals.Commands.Register;

public class RegisterHospitalCommand(IAddressRepository addressRepository, IMapperService mapperService, IHospitalRepository hospitalRepository) : IRegisterHospitalCommand
{
    public void Execute(RegisterHospitalInputModel inputModel)
    {
        Validate(inputModel);
        var doctor = mapperService.Map<RegisterHospitalInputModel, Hospital>(inputModel);
        var address = mapperService.Map<RegisterHospitalInputModel, Address>(inputModel);
        
        doctor.AddressId =  addressRepository.Add(address);
        hospitalRepository.Add(doctor);
    }

    public void Validate(RegisterHospitalInputModel inputModel)
    {
        if(string.IsNullOrEmpty(inputModel.Name))
            throw new ApplicationException("Name is required");
        
        if(hospitalRepository.GetByName(inputModel.Name) != null)
            throw new ApplicationException("Hospital already exists");
        
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