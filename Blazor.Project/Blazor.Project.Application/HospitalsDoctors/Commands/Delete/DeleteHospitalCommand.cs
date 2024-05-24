using Blazor.Project.Application.Hospitals.Commands.Common;
using Blazor.Project.Application.HospitalsDoctors.Commands.Common;
using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.HospitalsDoctors.Commands.Delete;

public class DeleteHospitalDoctorCommand(IDoctorRepository doctorRepository, IHospitalRepository hospitalRepository, IHospitalDoctorRepository hospitalDoctorRepository) : IDeleteHospitalDoctorCommand
{
    public void Execute(HospitalDoctorInputModel inputModel)
    {
        Validate(inputModel);
        
        var hospital = hospitalRepository.GetById(inputModel.HospitalId);
        if(hospital == null)
            throw new ApplicationException("Hospital not found");

        var doctor = doctorRepository.GetById(inputModel.DoctorId);
        if(doctor == null)
            throw new ApplicationException("Doctor not found");
        
        var hospitalDoctor = hospitalDoctorRepository.GetByHospitalIdDoctorId(inputModel.HospitalId, inputModel.DoctorId);
        if(hospitalDoctor == null)
            throw new ApplicationException("Association's Hospital and Doctor not found");
        
        hospitalDoctorRepository.DeleteByHospitalIdDoctorId(hospitalDoctor.HospitalId, hospitalDoctor.DoctorId);
    }

    public void Validate(HospitalDoctorInputModel inputModel)
    {
        if(inputModel.HospitalId <= 0)
            throw new ApplicationException("HospitalId is required");
        
        if(inputModel.DoctorId <= 0)
            throw new ApplicationException("DoctorId is required");
    }
}