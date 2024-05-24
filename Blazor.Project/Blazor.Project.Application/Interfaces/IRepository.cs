namespace Blazor.Project.Application.Interfaces;

public interface IRepository<T> where T : class
{
    void Add(T entity) ;
    void Update(T entity);
    IEnumerable<T> GetAll();
    T GetById(int id);
}