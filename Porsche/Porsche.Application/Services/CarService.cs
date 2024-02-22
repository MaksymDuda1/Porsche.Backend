using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository carRepository;

    public CarService(ICarRepository carRepository)
    {
        this.carRepository = carRepository;
    }

    public async Task<List<CarEntity>> GetAllCars()
    {
        return await carRepository.Get();
    }

    public async Task<int> CreateCar(CarEntity car)
    {        
        return await carRepository.Create(car);
    }

    public async Task<int> UpdateCar(CarEntity car)
    {
        return await carRepository.Update(car);
    }

    public async Task<int> DeleteCar(int id)
    {
        return await carRepository.Delete(id);
    }
}