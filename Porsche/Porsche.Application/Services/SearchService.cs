using Microsoft.IdentityModel.Tokens;
using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Services;

public class SearchService : ISearchService
{
    private readonly ICarService carService;
    private List<CarEntity> cars;
    
    public SearchService(ICarService carService)
    {
        this.carService = carService;
    }
    
    public async Task<List<CarEntity>> SearchCars(SearchRequest request)
    {
        var parameters = new SearchModel()
        {
            Model = request.Model,
            BodyType = request.BodyType,
            Colors = request.Color,
            MinYearOfRelease = request.MinYearOfRelease,
            MaxYearOfRelease = request.MaxYearOfRelease,
            Engine = request.Engine,
            MinPrice = request.MinPrice,
            MaxPrice = request.MaxPrice,
            PorscheCenter = request.PorscheCenter
        };

        Console.WriteLine(parameters.Model);
        
        cars = await carService.GetAllCars();

        var query = cars.AsQueryable(); 

        if (!parameters.Model.IsNullOrEmpty())
            query = query.Where(c => c.Model == parameters.Model);
        
        if (parameters.BodyType.Length != 0) 
            query = query.Where(c => parameters.BodyType.Contains(c.BodyType));
    
        if (parameters.Colors.Length != 0) 
            query = query.Where(c => parameters.Colors.Contains(c.Color));
        
        if (parameters.MinYearOfRelease != 0) 
            query = query.Where(c => c.YearOfEdition >= parameters.MinYearOfRelease);
        
        if (parameters.MaxYearOfRelease != 0) 
            query = query.Where(c => c.YearOfEdition <= parameters.MaxYearOfRelease);
        
        if (parameters.MinPrice != 0) 
            query = query.Where(c => c.Price >= parameters.MinPrice);
        
        if (parameters.MaxPrice != 0) 
            query = query.Where(c => c.Price <= parameters.MaxPrice);
        
        if (parameters.Engine.Length != 0) 
            query = query.Where(c => parameters.Engine.Contains(c.Engine));
        
        if (parameters.PorscheCenter.Length != 0) 
            query = query.Where(c => parameters.PorscheCenter.Contains(c.PorscheCenter.Name));

        return query.ToList();
    }
}