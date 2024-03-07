using System.Security.Claims;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Abstractions;

public interface ITokenService
{
    string CreateToken(IList<Claim> claims);
    public void AddRolesToClaims(List<Claim> claims, IList<string> roles);

}