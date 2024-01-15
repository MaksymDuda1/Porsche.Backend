using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;

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
        var car = new Car()
        {
            IdentityCode = request.IdentityCode,
            Model = request.Model,
            YearOfEdition = request.YearOfEdition,
            BodyType = request.BodyType,
            Engine = request.Engine,
            PorscheCenter = request.PorscheCenter,
            Photos = request.Photos
        };
        
        if (car == null)
        {
            return BadRequest();
        }
        
        var id = await carService.CreateCar(car);

        return Ok(id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<int>> UpdateCar(int id, [FromBody] CarRequest request)
    {
        var car = new Car()
        {
            Id = id,
            IdentityCode = request.IdentityCode,
            Model = request.Model,
            YearOfEdition = request.YearOfEdition,
            BodyType = request.BodyType,
            Engine = request.Engine,
            PorscheCenter = request.PorscheCenter,
            Photos = request.Photos
        };

        Console.WriteLine(new string('_',30) + car.Photos[0].Address);
        
        if (car == null)
        {
            return BadRequest();
        }

        await carService.UpdateCar(car);

        return Ok(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeleteCar(int id)
    {
        return await carService.DeleteCar(id);
    }
}