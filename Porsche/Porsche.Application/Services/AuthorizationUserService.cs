using Microsoft.EntityFrameworkCore;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure;
using Porsche.Infrastructure.DTOs;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Services;

public class AuthorizationUserService : IAuthorizationUserService
{
    private readonly ITokenService tokenService;
    private readonly PorscheDbContext context;

    public AuthorizationUserService(ITokenService tokenService, PorscheDbContext context )
    {
        this.tokenService = tokenService;
        this.context = context;
    }

    public async Task<string> RegisterUser(User user)
    {
        var existingUser = await context.Users
            .FirstOrDefaultAsync(p => p.Email == user.Email);

        if (existingUser != null)
        {
             throw new Exception("User already exist");
        }

        var entity = new UserEntity()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            Email = user.Email,
            Password = user.Password,
        };
    
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
        
        var token = tokenService.CreateToken(entity.ToUser());
        
        return token;
    }

    public async Task<string> LoginUser(User user)
    {
        var userEntity = new UserEntity()
        {
            Id = user.Id,
            Email = user.Email,
            Password = user.Password
        };  
        
        var existingUser = await context.Users
            .FirstOrDefaultAsync(p => p.Email == userEntity.Email && p.Password == userEntity.Password);

        if (existingUser == null)
        {
            throw new Exception("User not exists");
        }

        var token = tokenService.CreateToken(existingUser.ToUser());

        return token;
    }
}