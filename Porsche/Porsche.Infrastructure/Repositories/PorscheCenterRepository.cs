using System.Globalization;
using System.Runtime.InteropServices;
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
                Cars = p.Cars
            }).ToList();

        return porscheCenters;
    }

    public async Task<PorscheCenterEntity> GetById(int id)
    {
        var porscheCenter = await context.PorscheCenters.FindAsync(id);

        if (porscheCenter == null)
        {
            throw new Exception("Porsche Center doesn't exist");
        }

        return porscheCenter;
    }

    public async Task<int> Create(PorscheCenterEntity porscheCenter)
    {
        
        await context.AddAsync(porscheCenter);
        await context.SaveChangesAsync();

        return porscheCenter.Id;
    }

    public async Task<int> AddCar(AddingCarToPorscheCenter carAdding)
    {
        var existingPorscheCenter = await context.PorscheCenters.FindAsync(carAdding.PorscheCenterId);

        if (existingPorscheCenter == null)
            throw new Exception("Porsche center don't exists");
        
        var car = await context.Cars.FindAsync(carAdding.CarId);
        
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