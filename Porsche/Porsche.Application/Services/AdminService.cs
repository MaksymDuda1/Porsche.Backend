using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;
using Porsche.Infrastructure.Repositories;

namespace Porsche.Application.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        this.adminRepository = adminRepository;
    }
    
    public Task<int> AddCar(Car car)
    {
        return adminRepository.AddCar(car);
    }

    public Task<int> UpdateCar(Car car)
    {
        return adminRepository.UpdateCar(car);
    }

    public Task<int> DeleteCar(int id)
    {
        return adminRepository.DeleteCar(id);
    }

    public Task<int> CreateUser(RegisterModel user, string roleName)
    {
        return adminRepository.CreateUser(user, roleName);
    }
    
    public Task<int> UpdateUser(UserEntity user, string roleName)
    {
        return adminRepository.UpdateUser(user, roleName);
    }

    public Task<int> DeleteUser(int id)
    {
        return adminRepository.DeleteUser(id);
    }
    
}