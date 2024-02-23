using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure.Abstractions;

public interface ISearchService
{
    Task GetAllCars();
    Task<List<CarEntity>> SearchCars(SearchModel searchModel);
}