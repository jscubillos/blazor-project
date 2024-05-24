using Blazor.Project.Application.Doctors.Commands.Common;
using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Doctors.Commands.Update;

public class UpdateDoctorCommand(IAddressRepository addressRepository, IMapperService mapperService,  IDoctorRepository doctorRepository) : IUpdateDoctorCommand
{
    public void Execute(UpdateDoctorInputModel inputModel)
    {
        Validate(inputModel);
        var doctor = doctorRepository.GetById(inputModel.Id);
        if(doctor == null)
            throw new ApplicationException("Doctor not found");
        
        var sameNameDoctor = doctorRepository.GetByName(inputModel.Name);
        if(sameNameDoctor != null &&  sameNameDoctor.Id != doctor.Id)
            throw new ApplicationException("Doctor with the same name already exists");
        
        var address = mapperService.Map<DoctorInputModel, Address>(inputModel);
        address.Id = doctor.AddressId;
        
        doctor = mapperService.Map<DoctorInputModel, Doctor>(inputModel);
        doctor.AddressId = address.Id;
        
        doctorRepository.Update(doctor);
        addressRepository.Update(address);
    }

    public void Validate(UpdateDoctorInputModel inputModel)
    {
        if (inputModel.Id <= 0)
            throw new ApplicationException("Id is required"); 
        
        if (string.IsNullOrWhiteSpace(inputModel.Name))
            throw new ApplicationException("Name is required");
    }
}