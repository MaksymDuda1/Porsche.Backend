using System.Threading.Channels;
using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;
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

    public async Task<CarEntity> GetCarById(int id)
    {
        return await carRepository.GetById(id);
    }

    public async Task<int> CreateCar(CarRequest request)
    {
        var car = new CarEntity()
        {
            IdentityCode = request.IdentityCode,
            Model = request.Model,
            YearOfEdition = request.YearOfEdition,
            BodyType = request.BodyType,
            Color = request.Color,
            Engine = request.Engine,
            FuelConsumption = request.FuelConsumption,
            IsAvailable = true,
            Price = request.Price
        };

        if (request.Photos != null)
        {
            var photos = request.Photos.Select(p => new CarPhotoEntity()
            {
                Path = p.Path,
                Car = car
            }).ToList();

            car.Photos = photos;
        }

        return await carRepository.Create(car);
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
            Engine = request.Engine,
            FuelConsumption = request.FuelConsumption,
            Price = request.Price,
            PorscheCenter = request.PorscheCenter,
            Photos = request.Photos,
        };

        return await carRepository.Update(car);
    }

    public async Task<int> DeleteCar(int id)
    {
        return await carRepository.Delete(id);
    }
}