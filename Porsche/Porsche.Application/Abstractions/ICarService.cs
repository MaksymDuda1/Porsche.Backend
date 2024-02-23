using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Domain.Abstractions;

public interface ICarService
{
    Task<List<CarEntity>> GetAllCars();
    Task<int> CreateCar(CarRequest car);
    Task<int> UpdateCar(CarEntity car);
    Task<int> DeleteCar(int id);
}