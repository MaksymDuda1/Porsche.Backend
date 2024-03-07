using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponse>>> GetUsers()
    {
        try
        {
            var users = await userService.GetAllUsers();

            var response = users
                .Select(u => new UserResponse(u.Id, u.FirstName, u.SecondName,
                    u.Email, u.PasswordHash, u.Photo));

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("savedCars")]
    public async Task<ActionResult> AddCarToSaved(AddCarToSavedRequest request)
    {
        try
        {
            await userService.AddCarToSaved(request);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("savedCars/{id:int}")]
    public async Task<ActionResult<List<CarResponse>>>  GetSavedCars(int id)
    {
        try
        {
            var cars = await userService.GetSavedCars(id);

            var response = cars
                .Select(c => new CarResponse(
                    c.Id, c.IdentityCode, c.Model, c.YearOfEdition, c.BodyType,
                    c.Color, c.Engine, c.FuelConsumption, c.Price, c.IsAvailable
                    ,c.PorscheCenterId, c.Photos)
                ).ToList();
            
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}