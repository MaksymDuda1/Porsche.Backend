using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Domain.Abstractions;

public interface IUserService
{
    Task<List<UserEntity>> GetAllUsers();
    Task<int> CreateUser(RegisterModel user);
    Task<int> UpdateUser(UserEntity user);
    Task<int> DeleteUser(int id);
}