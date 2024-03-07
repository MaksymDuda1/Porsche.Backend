using Porsche.API.Contracts;
using Porsche.Application.Contracts;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Abstractions;

public interface ISearchService
{ 
    Task<List<CarEntity>> SearchCars(SearchRequest request);
}