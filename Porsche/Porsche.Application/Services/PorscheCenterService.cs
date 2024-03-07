using Porsche.API.Contracts;
using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Services;

public class PorscheCenterService : IPorscheCenterService
{
    private readonly IPorscheCenterRepository porscheCenterRepository;

    public PorscheCenterService(IPorscheCenterRepository porscheCenterRepository)
    {
        this.porscheCenterRepository = porscheCenterRepository;
    }

    public async Task<List<PorscheCenterEntity>> GetAllPorscheCenters()
    {
        return await porscheCenterRepository.Get();
    }

    public async Task<PorscheCenterEntity> GetPorscheCenterById(int id)
    {
        return await porscheCenterRepository.GetById(id);
    }

    public async Task<int> CreatePorscheCenter(PorscheCenterRequest request)
    {
        var porscheCenter = new PorscheCenterEntity()
        {
            Name = request.Name,
            Address = request.Address,
            Cars = request.Cars
        };
        
        return await porscheCenterRepository.Create(porscheCenter);
    }

    public async Task<int> UpdatePorscheCenter(PorscheCenterRequest request)
    {
        var porscheCenter = new PorscheCenterEntity()
        {
            Name = request.Name,
            Address = request.Address
        };
        
        return await porscheCenterRepository.Update(porscheCenter);
    }

    public async Task<int> DeletePorscheCenter(int id)
    {
        return await porscheCenterRepository.Delete(id);
    }

    public async Task<int> AddCarToPorscheCenter(AddingCarToThePorscheCenterRequest request)
    {
        var carAdding = new AddingCarToPorscheCenter()
        {
            PorscheCenterId = request.PorscheCenterId,
            CarId = request.CarId
        };

        return await porscheCenterRepository.AddCar(carAdding);
    }

}