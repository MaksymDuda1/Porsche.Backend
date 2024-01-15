using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;

namespace Porsche.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await userRepository.Get();
    }

    public async Task<int> CreateUser(User user)
    {
        return await userRepository.Create(user);
    }

    public async Task<int> UpdateUser(User user)
    {
        return await userRepository.Update(user);
    }

    public async Task<int> DeleteUser(int id)
    {
        return await userRepository.Delete(id);
    }
}