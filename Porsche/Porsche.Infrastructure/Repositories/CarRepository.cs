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

    public async Task<List<Car>> Get()
    {
        var cars = await context.Cars
            .Include(c => c.Photos)
            .Select(p => new Car()
            {
                Id = p.Id,
                IdentityCode = p.IdentityCode,
                Model = p.Model,
                YearOfEdition = p.YearOfEdition,
                BodyType = p.BodyType,
                Engine = p.Engine,
                PorscheCenterId = p.PorscheCenterId,
                Photos = p.Photos.ToList()
            })
            .ToListAsync();

        return cars;
    }


    public async Task<int> Create(Car car)
    {
        var carEntity = new CarEntity()
        {
            Id = car.Id,
            IdentityCode = car.IdentityCode,
            Model = car.Model,
            YearOfEdition = car.YearOfEdition,
            BodyType = car.BodyType,
            Engine = car.Engine,
        };

        var porscheCenter = new PorscheCenter()
        {
            Name = car.PorscheCenter.Name,
            Address = car.PorscheCenter.Address,
        };

        carEntity.PorscheCenter = porscheCenter;
        
        await context.AddAsync(carEntity);
        await context.SaveChangesAsync();

        return carEntity.Id;
    }

    public async Task<int> Update(Car car)
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

            if (existingCar.PorscheCenter != null && car.PorscheCenter != null)
            {
                existingCar.PorscheCenter.Name = car.PorscheCenter.Name;
                existingCar.PorscheCenter.Address = car.PorscheCenter.Address;
            }
            
            await context.SaveChangesAsync();
            return existingCar.Id;
        }

        throw new Exception("Car doesn't exist");
    }


    public async Task<int> Delete(int id)
    {
        await context.Cars
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<int> AddPhoto(int id, CarPhotoEntity photo)
    {
        var existingCar = await context.Cars.FirstOrDefaultAsync(c => c.Id == id);

        if (existingCar == null)
        {
            throw new Exception("Car do not exist");
        }

        var newPhoto = new CarPhoto()
        {
            Path = photo.Path,
            Car = existingCar.ToCar()
        };
        
        existingCar.Photos.Add(newPhoto);
        await context.SaveChangesAsync();
        
        return existingCar.Id;
    }
}