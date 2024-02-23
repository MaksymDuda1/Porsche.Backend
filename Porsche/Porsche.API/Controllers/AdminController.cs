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
[Route("admin")]
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
            return await adminService.DeleteCar(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [Route("api/admin/users")]
    [HttpDelete("{id:int}")]
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