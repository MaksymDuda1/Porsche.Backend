using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Abstractions;

namespace Porsche.Application.Services;

public class SearchService : ISearchService
{
    private readonly ICarService carService;
    private List<Car> cars;
    
    public SearchService(ICarService carService)
    {
        this.carService = carService;
    }

    public async Task GetAllCars()
    {
        this.cars =  await carService.GetAllCars();
    }

    public async Task<List<Car>> SearchCars(SearchModel searchModel)
    {
        cars = await carService.GetAllCars();

        var query = cars.AsQueryable(); 

        if (searchModel.Model != null)
            query = query.Where(c => c.Model == searchModel.Model);

        if (searchModel.BodyType != null) 
            query = query.Where(c => c.BodyType == searchModel.BodyType);
        
        if (searchModel.MinYearOfRelease != null) 
            query = query.Where(c => c.YearOfEdition >= searchModel.MinYearOfRelease);
        
        if (searchModel.MaxYearOfRelease != null) 
            query = query.Where(c => c.YearOfEdition <= searchModel.MaxYearOfRelease);
        
        if (searchModel.Engine != null) 
            query = query.Where(c => c.Engine == searchModel.Engine);
        
        if (searchModel.PorscheCenter != null) 
            query = query.Where(c => c.PorscheCenter == searchModel.PorscheCenter);
        
        return query.ToList();
    }
}