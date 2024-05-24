namespace Blazor.Project.Application.Interfaces;

public interface IQuery<in TInput, out TOutput> where TInput : class where TOutput : class
{
    TOutput Execute(TInput inputModel);
    
    void Validate(TInput inputModel);
}