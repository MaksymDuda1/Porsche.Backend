using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Application.Abstractions;
using Porsche.Domain.Models;

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
     
        var suitableCars = await searchService.SearchCars(request);

        var response = suitableCars.Select(c => new CarResponse(c.Id, c.IdentityCode, c.Model,
            c.YearOfEdition, c.BodyType, c.Engine,c.PorscheCenter, c.Photos)).ToList();

        if (response.Count == 0)
        {
            throw new Exception("Cannot find car by your parameters");
        }        
        return response;
    }
}