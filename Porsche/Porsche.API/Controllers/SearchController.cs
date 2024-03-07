using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;
using Porsche.Domain.Models;

namespace Porsche.API.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    private readonly ISearchService searchService;

    public SearchController(ISearchService searchService)
    {
        this.searchService = searchService;
    }

    [HttpPost]
    public async Task<ActionResult<List<CarResponse>>> SearchCars([FromBody] SearchRequest request)
    {
        try
        {
            var suitableCars = await searchService.SearchCars(request);
            
            var response = suitableCars
                .Select(c => new CarResponse(c.Id, c.IdentityCode, c.Model, c.YearOfEdition,
                    c.BodyType, c.Color, c.Engine,  c.FuelConsumption, c.Price,
                    c.IsAvailable, c.PorscheCenterId, c.Photos)).ToList();

            if (response.Count == 0)
            {
                throw new Exception("Cannot find car by your parameters");
            }

            return response;
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
}