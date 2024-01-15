using System.Net;
using Microsoft.EntityFrameworkCore;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PorscheDbContext context;

    public UserRepository(PorscheDbContext context)
    {
        this.context = context;
    }

    public async Task<List<User>> Get()
    {
        var userEntities = await context.Users
            .AsNoTracking()
            .ToListAsync();
        
        var users = userEntities
            .Select(p => new User()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                SecondName = p.SecondName,
                Email = p.Email,
                Password = p.Password,
            }).ToList();
        
        return users;
    }

    public async Task<int> Create(User user)
    {
        var userEntity = new UserEntity
        {
            Id = user.Id,
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            Email = user.Email,
            Password = user.Password,
        };

        await context.Users.AddAsync(userEntity);
        await context.SaveChangesAsync();

        return userEntity.Id;
    }

    public async Task<int> Update(User user)
    {
        await context.Users
            .Where(p => p.Id == user.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Id, p => user.Id)
                .SetProperty(p => p.FirstName, p => user.FirstName)
                .SetProperty(p => p.SecondName, p => user.SecondName)
                .SetProperty(p => p.Email, p => user.Email)
                .SetProperty(p => p.Password, p => user.Password));

        await context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<int> Delete(int id)
    {
        await context.Users
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}