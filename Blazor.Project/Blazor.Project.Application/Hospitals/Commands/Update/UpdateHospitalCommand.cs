using Blazor.Project.Application.Hospitals.Commands.Common;
using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Hospitals.Commands.Update;

public class UpdateHospitalCommand(IAddressRepository addressRepository, IMapperService mapperService,  IHospitalRepository hospitalRepository) : IUpdateHospitalCommand
{
    public void Execute(UpdateHospitalInputModel inputModel)
    {
        Validate(inputModel);
        var doctor = hospitalRepository.GetById(inputModel.Id);
        if(doctor == null)
            throw new ApplicationException("Hospital not found");
        
        var sameNameHospital = hospitalRepository.GetByName(inputModel.Name);
        if(sameNameHospital != null &&  sameNameHospital.Id != doctor.Id)
            throw new ApplicationException("Hospital with the same name already exists");
        
        var address = mapperService.Map<HospitalInputModel, Address>(inputModel);
        address.Id = doctor.AddressId;
        
        doctor = mapperService.Map<HospitalInputModel, Hospital>(inputModel);
        doctor.AddressId = address.Id;
        
        hospitalRepository.Update(doctor);
        addressRepository.Update(address);
    }

    public void Validate(UpdateHospitalInputModel inputModel)
    {
        if (inputModel.Id <= 0)
            throw new ApplicationException("Id is required"); 
        
        if (string.IsNullOrWhiteSpace(inputModel.Name))
            throw new ApplicationException("Name is required");
    }
}