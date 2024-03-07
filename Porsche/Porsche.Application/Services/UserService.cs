using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;
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

    public async Task<bool> AddCarToSaved(AddCarToSavedRequest request)
    {
        var entity = new AddingCarToSaved()
        {
            CarId = request.CarId,
            UserId = request.UserId
        };

        return await userRepository.AddCarToSaved(entity);
    }

    public async Task<List<CarEntity>> GetSavedCars(int id)
    {
        return await userRepository.GetSavedCars(id);
    }
}