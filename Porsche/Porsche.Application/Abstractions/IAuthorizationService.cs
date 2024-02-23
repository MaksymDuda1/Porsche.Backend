using Porsche.Domain.Models;

namespace Porsche.Domain.Abstractions;

public interface IAuthorizationUserService
{
    Task<string> RegisterUser(RegisterModel user);

    Task<string> LoginUser(LoginModel user);
}