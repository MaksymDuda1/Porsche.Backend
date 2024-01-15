using Porsche.Domain.Models;

namespace Porsche.Domain.Abstractions;

public interface IUserRepository
{
    Task<List<User>> Get();
    Task<int> Create(User user);
    Task<int> Update(User user);
    Task<int> Delete(int id);
}