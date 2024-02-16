using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly PorscheDbContext context;
    private readonly UserManager<UserEntity> userManager;
    private readonly IAuthorizationUserService authorizationUserService;

    public AdminRepository(PorscheDbContext context, UserManager<UserEntity> userManager )
    {
        this.context = context;
        this.userManager = userManager;
    }

    public async Task<int> AddCar(Car car)
    {
        var carEntity = new CarEntity()
        {
            IdentityCode = car.IdentityCode,
            Model = car.Model,
            BodyType = car.BodyType,
            YearOfEdition = car.YearOfEdition,
            Engine = car.Engine,
            Photos = car.Photos
        };

        var porscheCenter = new PorscheCenter
        {
            Name = car.PorscheCenter.Name,
            Address = car.PorscheCenter.Address
        };

        carEntity.PorscheCenter = porscheCenter;
        
        if (car == null)
        {
            throw new Exception("Wrong input");
        }

        await context.Cars.AddAsync(carEntity);
        await context.SaveChangesAsync();

        return carEntity.Id;
    }

    public async Task<int> UpdateCar(Car car)
    {

        Console.WriteLine(car.Id);
        var existingCar = await context.Cars
            .Include(c => c.PorscheCenter)
            .Include(c => c.Photos)
            .FirstOrDefaultAsync(p => p.Id == car.Id);

        if (existingCar != null)
        {
            existingCar.IdentityCode = car.IdentityCode;
            existingCar.Model = car.Model;
            existingCar.BodyType = car.BodyType;
            existingCar.Engine = car.Engine;

            if (existingCar.PorscheCenter != null && car.PorscheCenter != null)
            {
                existingCar.PorscheCenter.Name = car.PorscheCenter.Name;
                existingCar.PorscheCenter.Address = car.PorscheCenter.Address;
            }
        }

        var photos = car.Photos?
            .Select(p => new CarPhoto() {Path  = p.Path, Car = car }).ToList();
    
        existingCar.Photos = photos;
  
        
        await context.SaveChangesAsync();

        return existingCar.Id;
    }

    public async Task<int> DeleteCar(int id)
    {
        await context.Cars
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<int> CreateUser(RegisterModel user, string roleName)
    {
        var userEntity = new UserEntity
        {
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            Email = user.Email,
            PasswordHash = user.Password,
        };

        await userManager.AddToRoleAsync(userEntity, roleName);

        await context.Users.AddAsync(userEntity);
        await context.SaveChangesAsync();

        return userEntity.Id;
    }
    
    public async Task<int> UpdateUser(UserEntity user, string roleName)
    {
        await context.Users
            .Where(p => p.Id == user.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Id, p => user.Id)
                .SetProperty(p => p.FirstName, p => user.FirstName)
                .SetProperty(p => p.SecondName, p => user.SecondName)
                .SetProperty(p => p.Email, p => user.Email)
                .SetProperty(p => p.PasswordHash, p => user.PasswordHash));

        await userManager.AddToRoleAsync(user, roleName);
        await context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<int> DeleteUser(int id)
    {
        await context.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<int> UpdateRole(UserEntity user, string roleName)
    {
        await userManager.AddToRoleAsync(user, roleName);

        return user.Id;
    }
}