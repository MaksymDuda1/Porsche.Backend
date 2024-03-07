using Porsche.Application.Contracts;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Abstractions;

public interface IAdminService
{
    Task<int> AddCar(CarRequest car);
    Task<int> UpdateCar(CarRequest car);
    Task<int> DeleteCar(int id);
    Task<int> DeleteUser(int id);
}