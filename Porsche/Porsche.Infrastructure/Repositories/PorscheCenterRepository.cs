using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure.Repositories;

public class PorscheCenterRepository : IPorscheCenterRepository
{
    private readonly PorscheDbContext context;

    public PorscheCenterRepository(PorscheDbContext context)
    {
        this.context = context;
    }

    public async Task<List<PorscheCenterEntity>> Get()
    {
        var porscheCenterEntities = await context.PorscheCenters
            .Include(p => p.Cars)
            .AsNoTracking()
            .ToListAsync();

        var porscheCenters = porscheCenterEntities
            .Select(p => new PorscheCenterEntity()
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address,
                Cars = p.Cars.ToList()
            }).ToList();

        return porscheCenters;
    }

    public async Task<int> Create(PorscheCenterEntity porscheCenter)
    {
        var porscheCenterEntity = new PorscheCenterEntity()
        {
            Id = porscheCenter.Id,
            Name = porscheCenter.Name,
            Address = porscheCenter.Address,
        };

        var cars = porscheCenter.Cars?
            .Select(c => new CarEntity()
            {
                IdentityCode = c.IdentityCode, Model = c.Model, BodyType = c.BodyType,
                Engine = c.Engine, Photos = c.Photos, PorscheCenter = porscheCenterEntity
            }).ToList();
                
        porscheCenterEntity.Cars = cars;

        await context.AddAsync(porscheCenterEntity);
        await context.SaveChangesAsync();

        return porscheCenterEntity.Id;
    }

    public async Task<int> AddCar(int porscheCenterId, CarEntity car)
    {
        var existingPorscheCenter = await context.PorscheCenters.FindAsync(porscheCenterId);

        if (existingPorscheCenter == null)
            throw new Exception("Porsche center don't exists");


        if (car == null)
            throw new Exception("Wrong input");

        existingPorscheCenter.Cars.Add(car);
        await context.SaveChangesAsync();

        return car.Id;
    }

    public async Task<int> Update(PorscheCenterEntity porscheCenter)
    {
        var existingCenter = await context.PorscheCenters
            .Include(с => с.Cars)
            .FirstOrDefaultAsync(p => p.Id == porscheCenter.Id);
        
        if (existingCenter != null)
        {
            existingCenter.Name = porscheCenter.Name;
            existingCenter.Address = porscheCenter.Address;

            await context.SaveChangesAsync();
            return existingCenter.Id;
        }

        throw new Exception("User doesn't exist");
    }

    public async Task<int> Delete(int id)
    {
        await context.PorscheCenters
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}