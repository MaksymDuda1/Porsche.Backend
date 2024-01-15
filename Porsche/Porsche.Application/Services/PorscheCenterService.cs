using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;

namespace Porsche.Application.Services;

public class PorscheCenterService : IPorscheCenterService
{
    private readonly IPorscheCenterRepository porscheCenterRepository;

    public PorscheCenterService(IPorscheCenterRepository porscheCenterRepository)
    {
        this.porscheCenterRepository = porscheCenterRepository;
    }

    public async Task<List<PorscheCenter>> GetAllPorscheCenters()
    {
        return await porscheCenterRepository.Get();
    }

    public async Task<int> CreatePorscheCenter(PorscheCenter porscheCenter)
    {
        return await porscheCenterRepository.Create(porscheCenter);
    }

    public async Task<int> UpdatePorscheCenter(PorscheCenter porscheCenter)
    {
        return await porscheCenterRepository.Update(porscheCenter);
    }

    public async Task<int> DeletePorscheCenter(int id)
    {
        return await porscheCenterRepository.Delete(id);
    }

}