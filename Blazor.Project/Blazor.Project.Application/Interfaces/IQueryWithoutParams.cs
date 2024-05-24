namespace Blazor.Project.Application.Interfaces;

public interface IQueryWithoutParams<out TOutput> where TOutput : class
{
    TOutput Execute();
}