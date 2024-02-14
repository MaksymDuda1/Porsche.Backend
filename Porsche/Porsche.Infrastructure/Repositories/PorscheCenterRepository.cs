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

    public async Task<List<PorscheCenter>> Get()
    {
        var porscheCenterEntities = await context.PorscheCenters
            .Include(p => p.Cars)
            .AsNoTracking()
            .ToListAsync();

        var porscheCenters = porscheCenterEntities
            .Select(p => new PorscheCenter()
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address,
                Cars = p.Cars.ToList()
            }).ToList();

        return porscheCenters;
    }

    public async Task<int> Create(PorscheCenter porscheCenter)
    {
        var porscheCenterEntity = new PorscheCenterEntity()
        {
            Id = porscheCenter.Id,
            Name = porscheCenter.Name,
            Address = porscheCenter.Address,
        };

        var cars = porscheCenter.Cars?
            .Select(c => new Car()
            {
                IdentityCode = c.IdentityCode, Model = c.Model, BodyType = c.BodyType,
                Engine = c.Engine
            }).ToList();

        porscheCenterEntity.Cars = cars;

        await context.AddAsync(porscheCenterEntity);
        await context.SaveChangesAsync();

        return porscheCenterEntity.Id;
    }

    public async Task<int> Update(PorscheCenter porscheCenter)
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