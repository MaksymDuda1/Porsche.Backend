using Porsche.Domain.Models;

namespace Porsche.Domain.Abstractions;

public interface IAuthorizationUserService
{
    Task<string> RegisterUser(User user);

    Task<string> LoginUser(User user);
}