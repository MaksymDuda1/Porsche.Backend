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
            .Include(c => c.Photos)
            .Select(p => new CarEntity()
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


    public async Task<int> Create(CarEntity car)
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

        if (car.PorscheCenter != null)
        {
            var porscheCenter = new PorscheCenterEntity()
            {
                Name = car.PorscheCenter.Name,
                Address = car.PorscheCenter.Address
            };

            carEntity.PorscheCenter = porscheCenter;
        }

        await context.Cars.AddAsync(carEntity);
        await context.SaveChangesAsync();

        return carEntity.Id;
    }

    public async Task<int> Update(CarEntity car)
    {
        var existingCar = await context.Cars
            .Include(c => c.PorscheCenter)
            .Include(c => c.Photos)
            .FirstOrDefaultAsync(p => p.Id == car.Id);

        if (existingCar == null)
        {
            throw new Exception("Car doesn't exist");
        }

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


    public async Task<int> Delete(int id)
    {
        await context.Cars
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

}