using Blazor.Project.Application.Interfaces;

namespace Blazor.Project.Application.Users.Queries.Login;

public interface ILoginUserQuery : IQuery<LoginUserInputModel, LoginUserOutputModel>;