using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Application.Services;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Abstractions;

namespace Porsche.API.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController: ControllerBase
{
    private readonly ISearchService searchService;

    public SearchController(ISearchService searchService)
    {
        this.searchService = searchService;
    }
    
    [HttpPost]
    public async Task<List<CarResponse>> SearchCars([FromBody]SearchRequest request)
    {
        var parameters = new SearchModel()
        {
            Model = request.Model,
            BodyType = request.BodyType,
            MinYearOfRelease = request.MinYearOfRelease,
            MaxYearOfRelease = request.MaxYearOfRelease,
            Engine = request.Engine,
            PorscheCenter = request.PorscheCenter
        };

        var suitableCars = await searchService.SearchCars(parameters);

        var response = suitableCars.Select(c => new CarResponse(c.Id, c.IdentityCode, c.Model,
            c.YearOfEdition, c.BodyType, c.Engine,c.PorscheCenter, c.Photos)).ToList();

        if (response.Count == 0)
        {
            throw new Exception("Cannot find car by your parameters");
        }        
        return response;
    }
}