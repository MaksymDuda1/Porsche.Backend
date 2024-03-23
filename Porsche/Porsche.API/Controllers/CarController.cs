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
public class CarController : ControllerBase
{
    private readonly ICarService carService;

    public CarController(ICarService carService)
    {
        this.carService = carService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CarResponse>>> GetAllCars()
    {
        try
        {
            var cars = await carService.GetAllCars();

            var response = cars
                .Select(c => new CarResponse(
                    c.Id, c.IdentityCode, c.Model, c.YearOfEdition, c.BodyType,
                    c.Color, c.Engine, c.FuelConsumption ,c.Price,c.IsAvailable, c.PorscheCenterId, c.Photos)
                );
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CarResponse>> GetCarById(int id)
    {
        try
        {
            var car = await carService.GetCarById(id);

            var response = new CarResponse(
                car.Id, car.IdentityCode, car.Model, car.YearOfEdition, car.BodyType,
                car.Color, car.Engine, car.FuelConsumption,car.Price,
                car.IsAvailable,car.PorscheCenterId, car.Photos);
            
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateCar([FromBody] CarRequest request)
    {
        try
        {
            var id = await carService.CreateCar(request);

            return Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<int>> UpdateCar(int id, [FromBody] CarRequest request)
    {
        try
        {
            await carService.UpdateCar(request);

            return Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeleteCar(int id)
    {
        try
        {
            return await carService.DeleteCar(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}