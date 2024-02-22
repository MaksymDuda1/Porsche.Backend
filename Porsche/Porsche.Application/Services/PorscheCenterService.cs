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

    public async Task<int> CreatePorscheCenter(PorscheCenterEntity porscheCenter)
    {
        return await porscheCenterRepository.Create(porscheCenter);
    }

    public async Task<int> UpdatePorscheCenter(PorscheCenterEntity porscheCenter)
    {
        return await porscheCenterRepository.Update(porscheCenter);
    }

    public async Task<int> DeletePorscheCenter(int id)
    {
        return await porscheCenterRepository.Delete(id);
    }

}