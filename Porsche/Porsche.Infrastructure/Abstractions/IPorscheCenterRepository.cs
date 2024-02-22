using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Domain.Abstractions;

public interface IPorscheCenterRepository
{
    Task<List<PorscheCenterEntity>> Get();
    Task<int> Create(PorscheCenterEntity porscheCenter);
    Task<int> Update(PorscheCenterEntity porscheCenter);
    Task<int> Delete(int id);
}