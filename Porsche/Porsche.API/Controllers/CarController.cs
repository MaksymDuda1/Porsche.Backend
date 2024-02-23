using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.API.Controllers;


[ApiController]
[Route("api/car")]
public class CarController: ControllerBase
{
    private readonly ICarService carService;

    public CarController(ICarService carService)
    {
        this.carService = carService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CarResponse>>> GetAllCars()
    {
        var cars = await carService.GetAllCars();

        var response = cars
            .Select(c => new CarResponse(
                c.Id, c.IdentityCode, c.Model, c.YearOfEdition, c.BodyType,
                c.Engine, c.PorscheCenter, c.Photos)
            );
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateCar([FromBody] CarRequest request)
    {
        
        var id = await carService.CreateCar(request);

        return Ok(id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<int>> UpdateCar(int id, [FromBody] CarRequest request)
    {
        await carService.UpdateCar(request);

        return Ok(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeleteCar(int id)
    {
        return await carService.DeleteCar(id);
    }
}