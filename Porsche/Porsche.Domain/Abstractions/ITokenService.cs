using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;

namespace Porsche.Domain.Abstractions;

public interface ITokenService
{
    string CreateToken(User entity);
}