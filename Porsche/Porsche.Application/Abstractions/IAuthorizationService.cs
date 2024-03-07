using Porsche.API.Contracts;
using Porsche.Application.Contracts;
using Porsche.Domain.Models;

namespace Porsche.Application.Abstractions;

public interface IAuthorizationUserService
{
    Task<string> RegisterUser(RegisterRequest user);

    Task<string> LoginUser(LoginRequest user);
}