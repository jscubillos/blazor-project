using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Application.Specialities.Commands.Delete;

public class DeleteSpecialityCommand(ISpecialityRepository specialityRepository) : IDeleteSpecialityCommand
{
    public void Execute(int inputModel)
    {
        Validate(inputModel);
        
        var speciality = specialityRepository.GetById(inputModel);
        if(speciality == null)
            throw new ApplicationException("Speciality not found");
        
        specialityRepository.Delete(speciality);
    }

    public void Validate(int inputModel)
    {
        if(inputModel <= 0)
            throw new ApplicationException("Id is required");
    }
}