using Blazor.Project.Domain.Users;

namespace Blazor.Project.Application.Interfaces;

public interface IUserRepository : IRepository<User>
{
    User? GetByEmail(string email);
}