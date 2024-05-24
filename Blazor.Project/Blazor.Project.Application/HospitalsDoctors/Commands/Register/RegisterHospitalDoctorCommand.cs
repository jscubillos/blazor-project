using Blazor.Project.Application.HospitalsDoctors.Commands.Common;
using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.HospitalsDoctors.Commands.Register;

public class RegisterHospitalDoctorCommand(IDoctorRepository doctorRepository, IMapperService mapperService, IHospitalRepository hospitalRepository, IHospitalDoctorRepository hospitalDoctorRepository) : IRegisterHospitalDoctorCommand
{
    public void Execute(RegisterHospitalDoctorInputModel inputModel)
    {
        Validate(inputModel);
        
        var hospital = hospitalRepository.GetById(inputModel.HospitalId);
        if(hospital == null)
            throw new ApplicationException("Hospital not found");

        var doctor = doctorRepository.GetById(inputModel.DoctorId);
        if(doctor == null)
            throw new ApplicationException("Doctor not found");
        
        var hospitalDoctor = mapperService.Map<RegisterHospitalDoctorInputModel, HospitalDoctor>(inputModel);
        hospitalDoctorRepository.Add(hospitalDoctor);
    }

    public void Validate(RegisterHospitalDoctorInputModel inputModel)
    {
        if(inputModel.HospitalId <= 0)
            throw new ApplicationException("HospitalId is required");
        
        if(inputModel.DoctorId <= 0)
            throw new ApplicationException("DoctorId is required");
    }
}