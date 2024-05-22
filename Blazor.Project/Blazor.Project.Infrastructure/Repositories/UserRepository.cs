using Blazor.Project.Application.Interfaces;
using Blazor.Project.Domain.Users;

namespace Blazor.Project.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public void Add<T>(T entity) where T : class
    {
        throw new NotImplementedException();
    }

    public User GetByEmail(string userEmail)
    {
        throw new NotImplementedException();
    }
}