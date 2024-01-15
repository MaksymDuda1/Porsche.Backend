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
        
        var photos = car.Photos?
            .Select(p => new Photo() { Address = p.Address, Car = car }).ToList();

        carEntity.Photos = photos;
  
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

        return 0; 
    }


    public async Task<int> Delete(int id)
    {
        await context.Cars
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}