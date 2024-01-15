using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Services;

public class PhotoService : IPhotoService
{
    private readonly PorscheDbContext context;

    public PhotoService(PorscheDbContext context)
    {
        this.context = context;
    }

    public async Task<int> AddPhoto(Photo photo)
    {
        var existingCar = await context.Cars.FirstOrDefaultAsync(c => c.Id == photo.CarId);

        if (existingCar == null)
        {
            throw new Exception("Car do not exist");
        }

        var newPhoto = new Photo()
        {
            Address = photo.Address,
            Car = existingCar.ToCar()
        };

        /*if (existingCar.Photos == null)
        {
            existingCar.Photos = new List<Photo>();
        }*/
        
        existingCar.Photos.Add(newPhoto);
        await context.SaveChangesAsync();
        
        return existingCar.Id;
    }
}