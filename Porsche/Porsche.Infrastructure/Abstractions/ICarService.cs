using Porsche.Domain.Models;

namespace Porsche.Domain.Abstractions;

public interface ICarService
{
    Task<List<Car>> GetAllCars();
    Task<int> CreateCar(Car car);
    Task<int> UpdateCar(Car car);
    Task<int> DeleteCar(int id);
}