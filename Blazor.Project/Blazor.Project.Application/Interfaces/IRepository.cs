namespace Blazor.Project.Application.Interfaces;

public interface IRepository
{
    void Add<T>(T entity) where T : class;
}