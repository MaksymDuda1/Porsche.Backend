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
        var id = await adminService.AddCar(request);

        return Ok(id);
    }
    
    [HttpPut]
    [Route("api/admin/cars")]
    public async Task<ActionResult<int>> UpdateCar([FromBody] CarRequest request)
    {

        var id =await adminService.UpdateCar(request);

        return Ok(id);
    }
    
    [Route("api/admin/cars")]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeleteCar(int id)
    {
        return await adminService.DeleteCar(id);
    }
    
    
    
    [Route("api/admin/users")]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeleteUser(int id)
    {
        return Ok(await adminService.DeleteUser(id));
    }
}