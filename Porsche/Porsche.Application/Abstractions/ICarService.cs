using Porsche.Application.Contracts;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Abstractions;

public interface ICarService
{
    Task<List<CarEntity>> GetAllCars();
    Task<CarEntity> GetCarById(int id);
    Task<int> CreateCar(CarRequest car);
    Task<int> UpdateCar(CarRequest car);
    Task<int> DeleteCar(int id);
}