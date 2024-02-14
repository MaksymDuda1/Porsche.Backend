using Porsche.Domain.Models;

namespace Porsche.Infrastructure.Abstractions;

public interface ISearchService
{
    Task GetAllCars();
    Task<List<Car>> SearchCars(SearchModel searchModel);
}