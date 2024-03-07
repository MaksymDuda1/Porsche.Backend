using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Domain.Abstractions;

public interface IUserRepository
{
    Task<List<UserEntity>> Get();
    Task<UserEntity> GetById(int id); 
    Task<bool> AddCarToSaved(AddingCarToSaved usersCars);
    Task<List<CarEntity>> GetSavedCars(int id);

    Task<int> AddPhoto(int userId, UserPhotoEntity photo);

}