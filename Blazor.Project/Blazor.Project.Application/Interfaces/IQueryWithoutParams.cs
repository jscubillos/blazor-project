namespace Blazor.Project.Application.Interfaces;

public interface IQueryWithoutParams<out TOutput>
{
    TOutput Execute();
}