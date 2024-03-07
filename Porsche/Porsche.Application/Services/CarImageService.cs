using System.Threading.Channels;
using Microsoft.AspNetCore.Http;
using Porsche.Application.Abstractions;
using Porsche.Domain.Abstractions;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Services;

public class CarImageService : ICarImageService
{
    private readonly ICarRepository carRepository;

    public CarImageService(ICarRepository carRepository)
    {
        this.carRepository = carRepository;
    }

    public async Task<int> UploadImage(int id, IFormFile file)
    {
        if (file == null || file.Length <= 0)
        {
            throw new ArgumentException("File is empty or null.");
        }

        string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string directoryPath = 
            Path.Combine(homeDirectory, "Studying/Porsche/Porsche.Frontend/Porsche/src/assets/images/carImages");
        string fileName = file.FileName;
        string filePath = Path.Combine(directoryPath, fileName);
        
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
    
        
        var photo = new CarPhotoEntity()
        {
            Path = filePath,
            FileName = fileName
        };

        Console.WriteLine(photo.Path);

        return await carRepository.AddPhoto(id, photo);
    }


    public async Task DeleteImage(int id)
    {
        var filePath = await carRepository.DeletePhoto(id);

        File.Delete(filePath);
    }
}