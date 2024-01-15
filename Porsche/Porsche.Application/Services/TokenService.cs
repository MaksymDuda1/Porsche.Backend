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
    
    public string CreateToken(User entity)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecret = configuration["jwtSecret"]!;
        var key = Encoding.ASCII.GetBytes(jwtSecret);

        var userRoles = context.UserRoles
            .Include(p => p.Role)
            .Where(p => p.UserId == entity.Id)
            .ToList();

        var roles = userRoles
            .Select(p => p.Role).ToList();
            
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Sid, entity.Id.ToString()),
            new Claim(ClaimTypes.Email, entity.Email)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }
        
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
}