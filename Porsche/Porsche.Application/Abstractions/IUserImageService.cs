using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;

namespace Porsche.Application.Services;

public interface IUserImageService
{
    Task<PutObjectResponse> UploadImage(int id, IFormFile file);
}