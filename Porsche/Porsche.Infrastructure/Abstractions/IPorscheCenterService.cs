using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Domain.Abstractions;

public interface IPorscheCenterService
{
    Task<List<PorscheCenterEntity>> GetAllPorscheCenters();
    Task<int> CreatePorscheCenter(PorscheCenterEntity porscheCenter);
    Task<int> UpdatePorscheCenter(PorscheCenterEntity porscheCenter);
    Task<int> DeletePorscheCenter(int id);
}