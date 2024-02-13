using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration configuration;
    private readonly PorscheDbContext context;

    public TokenService(IConfiguration configuration, PorscheDbContext context)
    {
        this.configuration = configuration;
        this.context = context;
    }
    
    public string CreateToken(IList<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecret = configuration["jwtSecret"]!;
        var key = Encoding.ASCII.GetBytes(jwtSecret);
        var identity = new ClaimsIdentity(claims);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = identity,
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public void AddRolesToClaims(List<Claim> claims, IList<string> roles)
    {
        foreach (var role in roles)
        {
            var roleClaim = new Claim(ClaimTypes.Role, role);
            claims.Add(roleClaim);
        }
    }
}