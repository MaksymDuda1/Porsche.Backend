using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Domain.Abstractions;

public interface IUserRepository
{
    Task<List<UserEntity>> Get();
    Task<int> Create(RegisterModel user);
    Task<int> Update(UserEntity user);
    Task<int> Delete(int id);
}