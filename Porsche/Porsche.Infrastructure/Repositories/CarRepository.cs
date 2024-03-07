using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    private readonly PorscheDbContext context;

    public CarRepository(PorscheDbContext context)
    {
        this.context = context;
    }

    public async Task<List<CarEntity>> Get()
    {
        var cars = await context.Cars
            .Include(c => c.PorscheCenter)
            .Include(c => c.Photos)
            .Where(c => c.IsAvailable == true).ToListAsync();

        return cars;
    }
    
    public async Task<CarEntity> GetById(int id)
    {
        var car = await context.Cars
            .Include(c => c.PorscheCenter)
            .Include(c => c.Photos)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (car == null)
            throw new Exception("Car doesn't exist");
        
        return car;
    }

    public async Task<int> Create(CarEntity car)
    {
        await context.Cars.AddAsync(car);
        await context.SaveChangesAsync();

        return car.Id;
    }

    public async Task<int> Update(CarEntity car)
    {
        await context.SaveChangesAsync();
        return car.Id;
    }


    public async Task<int> Delete(int id)
    {
        var carToDelete = await context.Cars
            .Include(p => p.Photos)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (carToDelete != null)
        {
            context.CarPhotos.RemoveRange(carToDelete.Photos);
            context.Cars.Remove(carToDelete);
            
            await context.SaveChangesAsync();
        }

        return id;
    }

    public async Task<int> AddPhoto(int carId, CarPhotoEntity photo)
    {
        var car = await context.Cars.FindAsync(carId);

        if (car == null)
            throw new Exception("User does not exist");

        if(car.Photos == null)
            car.Photos = new List<CarPhotoEntity>();
        
        car.Photos.Add(photo);
        await context.SaveChangesAsync();

        return car.Id;
    }

    public async Task<string> DeletePhoto(int id)
    {
        var photo = await context.CarPhotos.FindAsync(id);

        if (photo == null)
            throw new Exception("Photo doesn't exist");
        
        var path = photo.Path;
        
        context.CarPhotos.Remove(photo);
        await context.SaveChangesAsync();

        return path;
    }
}