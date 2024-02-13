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

    public async Task<List<UserEntity>> Get()
    {
        var userEntities = await context.Users
            .AsNoTracking()
            .ToListAsync();
        
        return userEntities;
    }
    public async Task<int> Create(RegisterModel user)
    {
        var userEntity = new UserEntity
        {
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            Email = user.Email,
            PasswordHash = user.Password,
        };

        await context.Users.AddAsync(userEntity);
        await context.SaveChangesAsync();

        return userEntity.Id;
    }
    public async Task<int> Update(UserEntity user)
    {
        await context.Users
            .Where(p => p.Id == user.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Id, p => user.Id)
                .SetProperty(p => p.FirstName, p => user.FirstName)
                .SetProperty(p => p.SecondName, p => user.SecondName)
                .SetProperty(p => p.Email, p => user.Email)
                .SetProperty(p => p.PasswordHash, p => user.PasswordHash));

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
    
    /*public async Task<int> AddPhoto(int id, Photo photo)
    {
        var existingUser = await context.Users.FindAsync(id);

        if (existingUser == null)
        {
            throw new Exception("Car do not exist");
        }

        var newPhoto = new Photo()
        {
            Address = photo.Address,
        };

        /*if (existingCar.Photos == null)
        {
            existingCar.Photos = new List<Photo>();
        }#1#
        
        existingUser..Add(newPhoto);
        await context.SaveChangesAsync();
        
        return existingUser.Id;
    }*/
}