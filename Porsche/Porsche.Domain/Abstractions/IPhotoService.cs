using Porsche.Domain.Models;

namespace Porsche.Domain.Abstractions;

public interface IPhotoService
{
    Task<int> AddPhoto(Photo photo);
}