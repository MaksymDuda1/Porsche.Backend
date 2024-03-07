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
            .Include(u => u.Photo)
            .AsNoTracking()
            .ToListAsync();
        
        return userEntities;
    }

    public async Task<UserEntity> GetById(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null)
            throw new Exception("User not found");

        return user;

    }

    public async Task<int> AddPhoto(int userId, UserPhotoEntity photo)
    {
        var user = await context.Users.FindAsync(userId);

        if (user == null)
            throw new Exception("User does not exist");

        if (user.Photo == null)
            user.Photo = new UserPhotoEntity();
        
        user.Photo = photo;

        await context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<bool> AddCarToSaved(AddingCarToSaved addingCarToSaved)
    {
        var car = await context.Cars.FindAsync(addingCarToSaved.CarId);
        var user = await context.Users.FindAsync(addingCarToSaved.UserId);

        if (car == null)
            throw new Exception("Wrong car id");
        
        if (user == null)
            throw new Exception("Wrong user id");

        if (user.SavedCars == null)
            user.SavedCars = new List<CarEntity>();
        
        if (car.Users == null)
            car.Users = new List<UserEntity>();
        
        user.SavedCars.Add(car);
        car.Users.Add(user);
        
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<List<CarEntity>> GetSavedCars(int id)
    {
        var cars = await context.Cars
            .Where(c => c.Users.Any(u => u.Id == id)).ToListAsync();

        if (cars == null)
            throw new Exception("You have no saved cars");
        
        return cars;
    }
}