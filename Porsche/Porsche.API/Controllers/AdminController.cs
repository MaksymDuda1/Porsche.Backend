using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;
using Porsche.Infrastructure.Repositories;

namespace Porsche.API.Controllers;


[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController: ControllerBase
{
    private readonly IAdminService adminService;

    public AdminController(IAdminService adminService)
    {
        this.adminService = adminService;
    }
    
    [HttpPost]
    [Route("api/admin/cars")]
    public async Task<ActionResult<int>> CreateCar(CarRequest request)
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
        
        var id = await adminService.AddCar(car);

        return Ok(id);
    }
    
    [HttpPut]
    [Route("api/admin/cars")]
    public async Task<ActionResult<int>> UpdateCar([FromBody] CarRequest request)
    {
        var car = new Car()
        {
            Id = request.Id,
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

        await adminService.UpdateCar(car);

        return Ok(car.Id);
    }
    
    [Route("api/admin/cars")]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeleteCar(int id)
    {
        return await adminService.DeleteCar(id);
    }
    
    [Route("api/admin/users")]
    [HttpPost]
    public async Task<ActionResult<int>> CrateUser([FromBody] UserRequest request)
    {
        var user = new RegisterModel()
        {
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            Email = request.Email,
            Password = request.Password,
        };

        if (user == null)
        {
            return BadRequest();
        }

        var id = await adminService.CreateUser(user, request.Role );

        return Ok(id);
    }
    
    [Route("api/admin/users")]
    [HttpPut("{id:int}")]
    public async Task<ActionResult<int>> UpdateUser(int id, [FromBody] UserRequest request)
    {
        var user = new UserEntity()
        {
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            Email = request.Email,
            PasswordHash = request.Password,
        };

        if (user == null)
        {
            return BadRequest();
        }
        
        await adminService.UpdateUser(user, request.Role);

        return Ok(id);
    }
    
    [Route("api/admin/users")]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeleteUser(int id)
    {
        return Ok(await adminService.DeleteUser(id));
    }
}