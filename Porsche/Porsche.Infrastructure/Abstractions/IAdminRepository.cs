using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure.Repositories;

public interface IAdminRepository
{
    Task<int> AddCar(CarEntity car);
    Task<int> UpdateCar(CarEntity car);
    Task<int> DeleteCar(int id);
    Task<int> CreateUser(RegisterModel user, string roleName);
    
    Task<int> UpdateUser(UserEntity user, string roleName);

    Task<int> DeleteUser(int id);

    Task<int> UpdateRole(UserEntity user, string roleName);
}