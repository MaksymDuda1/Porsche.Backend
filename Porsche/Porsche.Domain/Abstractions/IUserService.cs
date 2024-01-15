using Porsche.Domain.Models;

namespace Porsche.Domain.Abstractions;

public interface IUserService
{
    Task<List<User>> GetAllUsers();
    Task<int> CreateUser(User user);
    Task<int> UpdateUser(User user);
    Task<int> DeleteUser(int id);
}