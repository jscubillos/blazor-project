using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Company;

namespace Blazor.Project.Application.Specialities.Commands.Register;

public class RegisterSpecialityCommand(IMapperService mapperService, ISpecialityRepository specialityRepository) : IRegisterSpecialityCommand
{
    public void Execute(RegisterSpecialityInputModel inputModel)
    {
        Validate(inputModel);
        var speciality = mapperService.Map<RegisterSpecialityInputModel, Speciality>(inputModel);
        specialityRepository.Add(speciality);
    }

    public void Validate(RegisterSpecialityInputModel inputModel)
    {
        if(string.IsNullOrEmpty(inputModel.Name))
            throw new ApplicationException("Name is required");
        
        if(specialityRepository.GetByName(inputModel.Name) != null)
            throw new ApplicationException("Speciality already exists");
    }
}