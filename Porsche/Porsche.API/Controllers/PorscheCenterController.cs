using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;

namespace Porsche.API.Controllers;

[ApiController]
[Route("api/porscheCenter")]
public class PorscheCenterController: ControllerBase
{
    private readonly IPorscheCenterService porscheCenterService;

    public PorscheCenterController(IPorscheCenterService porscheCenterService)
    {
        this.porscheCenterService = porscheCenterService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<PorscheCenterResponse>>> GetAllPorscheCentres()
    {
        var porscheCentres = await porscheCenterService.GetAllPorscheCenters();

        var response = porscheCentres
            .Select(p => new PorscheCenterResponse(
                p.Id, p.Name, p.Address, p.Cars));

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreatePorscheCenter([FromBody] PorscheCenterRequest request)
    {
        var porscheCenter = new PorscheCenter()
        {
            Name = request.Name,
            Address = request.Address,
            Cars = request.Cars
        };

        if (porscheCenter == null)
        {
            return BadRequest();
        }

        var id = await porscheCenterService.CreatePorscheCenter(porscheCenter);

        return Ok(id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<int>> UpdatePorscheCenter(int id, [FromBody] PorscheCenterRequest request)
    {
        var porscheCenter = new PorscheCenter()
        {
            Id = id,
            Name = request.Name,
            Address = request.Address,
        };

        if (porscheCenter == null)
        {
            return BadRequest();
        }

        await porscheCenterService.UpdatePorscheCenter(porscheCenter);

        return Ok(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeletePorscheCenter(int id)
    {
        return await porscheCenterService.DeletePorscheCenter(id);
    }

}