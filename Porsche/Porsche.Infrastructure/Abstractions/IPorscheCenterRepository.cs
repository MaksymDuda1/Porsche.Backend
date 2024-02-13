using Porsche.Domain.Models;

namespace Porsche.Domain.Abstractions;

public interface IPorscheCenterRepository
{
    Task<List<PorscheCenter>> Get();
    Task<int> Create(PorscheCenter porscheCenter);
    Task<int> Update(PorscheCenter porscheCenter);
    Task<int> Delete(int id);
}