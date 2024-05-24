namespace Blazor.Project.Application.Interfaces;

public interface IRepository<T> where T : class
{
    int Add(T entity) ;
    void Update(T entity);
    void Delete(T entity);
    IEnumerable<T> GetAll();
    T? GetById(int id);
    T? GetById(T entity);
}