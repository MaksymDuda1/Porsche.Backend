using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<List<UserEntity>> GetAllUsers()
    {
        return await userRepository.Get();
    }

    public async Task<int> CreateUser(RegisterModel user)
    {
        return await userRepository.Create(user);
    }

    public async Task<int> UpdateUser(UserEntity user)
    {
        return await userRepository.Update(user);
    }

    public async Task<int> DeleteUser(int id)
    {
        return await userRepository.Delete(id);
    }
}