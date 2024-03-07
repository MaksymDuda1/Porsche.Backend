using Porsche.API.Contracts;
using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;
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
    
    public async Task<int> AddCar(CarRequest request)
    {
        var car = new CarEntity()
        {
            IdentityCode = request.IdentityCode,
            Model = request.Model,
            YearOfEdition = request.YearOfEdition,
            BodyType = request.BodyType,
            Color = request.Color,
            Engine = request.Engine
        };
        

        var photos = request.Photos.Select(p => new CarPhotoEntity()
        {
            Path = p.Path,
            Car = car
        });

        car.Photos = photos.ToList();

        return await adminRepository.AddCar(car);
    }

    public async Task<int> UpdateCar(CarRequest request)
    {
        var car = new CarEntity()
        {
            IdentityCode = request.IdentityCode,
            Model = request.Model,
            YearOfEdition = request.YearOfEdition,
            BodyType = request.BodyType,
            Color = request.Color,
            Engine = request.Engine
        };

        var photos = request.Photos.Select(p => new CarPhotoEntity()
        {
            Path = p.Path,
            Car = car
        });

        car.Photos = photos.ToList();
        
        return await adminRepository.UpdateCar(car);
    }

    public async Task<int> DeleteCar(int id)
    {
        return await adminRepository.DeleteCar(id);
    }
    
    public Task<int> DeleteUser(int id)
    {
        return adminRepository.DeleteUser(id);
    }

    public async Task<int> UpdateRole(RoleUpdateRequest request)
    {
        var roleUpdateModel = new RoleUpdate()
        {
            UserId = request.UserId,
            Role = request.Role
        };

        return await adminRepository.UpdateRole(roleUpdateModel);
    }

}