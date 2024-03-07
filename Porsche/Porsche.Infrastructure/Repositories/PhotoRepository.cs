/*using Microsoft.EntityFrameworkCore;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure.Repositories;

public class PhotoRepository
{
    private readonly PorscheDbContext context;

    public PhotoRepository(PorscheDbContext context)
    {
        this.context = context;
    }
    
    public async Task<int> AddPhoto(int id, CarPhotoEntity photo)
    {
        var existingCar = await context.Cars
            .Include(c => c.Photos)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (existingCar == null)
        {
            throw new Exception("Car do not exist");
        }

        var newPhoto = new CarPhotoEntity()
        {
            Path = photo.Path,
            Car = existingCar
        };

        existingCar.Photos.Add(newPhoto);
        await context.SaveChangesAsync();

        return existingCar.Id;
    }
    
    public async Task<int> AddPhoto(int id, UserPhotoEntity photo)
    {
        var existingUser = await context.Users
            .FirstOrDefaultAsync(c => c.Id == id);

        if (existingUser == null)
        {
            throw new Exception("Car do not exist");
        }

        var newPhoto = new UserPhotoEntity()
        {
            Path = photo.Path,
            User = photo.User
        };

        existingUser.Photos = newPhoto;
        await context.SaveChangesAsync();

        return existingUser.Id;
    }
}*/