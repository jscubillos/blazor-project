using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Application.Specialities.Commands.Update;

public class UpdateSpecialityCommand(ISpecialityRepository specialityRepository) : IUpdateSpecialityCommand
{
    public void Execute(UpdateSpecialityInputModel inputModel)
    {
        Validate(inputModel);
        var speciality = specialityRepository.GetById(inputModel.Id);
        if(speciality == null)
            throw new ApplicationException("Speciality not found");
        
        var sameNameSpeciality = specialityRepository.GetByName(inputModel.Name);
        if(sameNameSpeciality != null &&  sameNameSpeciality.Id != speciality.Id)
            throw new ApplicationException("Speciality with the same name already exists");
        
        speciality.Name = inputModel.Name;
        specialityRepository.Update(speciality);
    }

    public void Validate(UpdateSpecialityInputModel inputModel)
    {
        if (inputModel.Id <= 0)
            throw new ApplicationException("Id is required"); 
        
        if (string.IsNullOrWhiteSpace(inputModel.Name))
            throw new ApplicationException("Name is required");
    }
}