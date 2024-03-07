using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;

namespace Porsche.Application.Abstractions;

public interface IUserImageService
{
    Task<int> UploadImage(int id, IFormFile file);
}