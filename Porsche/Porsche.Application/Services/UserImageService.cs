
using Microsoft.AspNetCore.Http;
using Porsche.Application.Abstractions;
using Porsche.Domain.Abstractions;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Services;

public class UserImageService : IUserImageService
{
    private readonly IUserRepository userRepository;

    public UserImageService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<int> UploadImage(int id, IFormFile file)
    {
        if (file == null)
            throw new Exception("Error while loading file");
        
        var filePath = Path.Combine(Directory.GetCurrentDirectory(),
           "images","UserImages", file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var photo = new UserPhotoEntity()
        {
            Path = filePath,
        };
        
        return await userRepository.AddPhoto(id, photo);
    }
}