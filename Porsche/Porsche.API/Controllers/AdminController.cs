using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;
using Porsche.Infrastructure.Repositories;

namespace Porsche.API.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
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
        var id = await adminService.AddCar(request);

        return Ok(id);
    }

    [HttpPut]
    [Route("api/admin/cars")]
    public async Task<ActionResult<int>> UpdateCar([FromBody] CarRequest request)
    {
        try
        {
            var id = await adminService.UpdateCar(request);

            return Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("api/admin/cars")]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeleteCar(int id)
    {
        try
        {
            return Ok(await adminService.DeleteCar(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("api/admin/users")]
    [HttpPut]
    public async Task<ActionResult<int>> UpdateUserRole(RoleUpdateRequest request)
    {
        try
        {
            Console.WriteLine("Hello");
            return Ok(await adminService.UpdateRole(request));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("api/admin/users/{id:int}")]
    public async Task<ActionResult<int>> DeleteUser(int id)
    {
        try
        {
            return Ok(await adminService.DeleteUser(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}