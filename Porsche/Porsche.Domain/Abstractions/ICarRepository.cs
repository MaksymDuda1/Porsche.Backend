using Porsche.Domain.Models;

namespace Porsche.Domain.Abstractions;

public interface ICarRepository
{
    Task<List<Car>> Get();
    Task<int> Create(Car car);
    Task<int> Update(Car car);
    Task<int> Delete(int id);
}