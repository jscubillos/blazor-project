namespace Blazor.Project.Application.Interfaces;

public interface IQuery<in TInput, out TOutput>
{
    TOutput Execute(TInput inputModel);
    
    void Validate(TInput inputModel);
}