namespace Blazor.Project.Application.Interfaces;

public interface ICommand<in T>
{
    void Execute(T inputModel);
    
    void Validate(T inputModel);
}