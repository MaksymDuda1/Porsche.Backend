using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Domain.Abstractions;

public interface ICarRepository
{
    Task<List<CarEntity>> Get();
    Task<int> Create(CarEntity car);
    Task<int> Update(CarEntity car);
    Task<int> Delete(int id);
}