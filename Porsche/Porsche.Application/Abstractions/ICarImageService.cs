using Microsoft.AspNetCore.Http;

namespace Porsche.Application.Abstractions;

public interface ICarImageService
{
    Task<int> UploadImage(int id, IFormFile file);
    Task DeleteImage(int id);

}