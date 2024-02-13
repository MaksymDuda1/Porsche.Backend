using Porsche.Domain.Models;

namespace Porsche.Domain.Abstractions;

public interface IPorscheCenterService
{
    Task<List<PorscheCenter>> GetAllPorscheCenters();
    Task<int> CreatePorscheCenter(PorscheCenter porscheCenter);
    Task<int> UpdatePorscheCenter(PorscheCenter porscheCenter);
    Task<int> DeletePorscheCenter(int id);
}