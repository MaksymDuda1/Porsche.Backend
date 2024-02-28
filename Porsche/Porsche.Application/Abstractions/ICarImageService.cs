using Microsoft.AspNetCore.Http;

namespace Porsche.Application.Services;

public interface ICarImageService
{
    Task<int> UploadImage(int id, IFormFile file);
}