using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Domain.Abstractions;

public interface ICarRepository
{
    Task<List<CarEntity>> Get();
    Task<CarEntity> GetById(int id);
    Task<int> Create(CarEntity car);
    Task<int> Update(CarEntity car);
    Task<int> Delete(int id);
    Task<int> AddPhoto(int carId, CarPhotoEntity photo);
     Task<string> DeletePhoto(int id);
}