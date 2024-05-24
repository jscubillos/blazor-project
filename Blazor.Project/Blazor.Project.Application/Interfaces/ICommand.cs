namespace Blazor.Project.Application.Interfaces;

public interface ICommand<in T> where T : class
{
    void Execute(T inputModel);
    
    void Validate(T inputModel);
}