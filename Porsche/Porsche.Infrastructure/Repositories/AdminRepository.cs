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

    public AdminRepository(PorscheDbContext context, UserManager<UserEntity> userManager )
    {
        this.context = context;
        this.userManager = userManager;
    }

    public async Task<int> AddCar(CarEntity car)
    {
        if (car == null)
            throw new Exception();

        await context.Cars.AddAsync(car);
        await context.SaveChangesAsync();

        return car.Id;
    }

    public async Task<int> UpdateCar(CarEntity car)
    {
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
            existingCar.FuelConsumption = car.FuelConsumption;

            if (existingCar.PorscheCenter != null && car.PorscheCenter != null)
            {
                existingCar.PorscheCenter.Name = car.PorscheCenter.Name;
                existingCar.PorscheCenter.Address = car.PorscheCenter.Address;
            }
        }

        var photos = car.Photos?
            .Select(p => new CarPhotoEntity() {Path  = p.Path, Car = existingCar }).ToList();
    
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
    
    public async Task<int> DeleteUser(int id)
    {
        await context.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<int> UpdateRole(RoleUpdate roleUpdate)
    {
        var user = await context.Users.FindAsync(roleUpdate.UserId);

        if (user == null)
            throw new Exception();
        
        await userManager.AddToRoleAsync(user, roleUpdate.Role);

        return roleUpdate.UserId;
    }
}