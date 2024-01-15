using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;

namespace Porsche.Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository carRepository;

    public CarService(ICarRepository carRepository)
    {
        this.carRepository = carRepository;
    }

    public async Task<List<Car>> GetAllCars()
    {
        return await carRepository.Get();
    }

    public async Task<int> CreateCar(Car car)
    {        
        return await carRepository.Create(car);
    }

    public async Task<int> UpdateCar(Car car)
    {
        return await carRepository.Update(car);
    }

    public async Task<int> DeleteCar(int id)
    {
        return await carRepository.Delete(id);
    }
}