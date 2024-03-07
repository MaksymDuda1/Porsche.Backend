using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.API.Controllers;

[ApiController]
[Route("api/porscheCenter")]
public class PorscheCenterController : ControllerBase
{
    private readonly IPorscheCenterService porscheCenterService;

    public PorscheCenterController(IPorscheCenterService porscheCenterService)
    {
        this.porscheCenterService = porscheCenterService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PorscheCenterResponse>>> GetAllPorscheCenters()
    {
        try
        {
            var porscheCentres = await porscheCenterService.GetAllPorscheCenters();

            var response = porscheCentres
                .Select(p => new PorscheCenterResponse(
                    p.Id, p.Name, p.Address, p.Cars));

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    } 
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PorscheCenterResponse>> GetPorscheCenterById (int id)
    {
        try
        {
            var porscheCenter = await porscheCenterService.GetPorscheCenterById(id);

            var response = new PorscheCenterResponse(porscheCenter.Id, porscheCenter.Name,
                porscheCenter.Address, porscheCenter.Cars);

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreatePorscheCenter([FromBody] PorscheCenterRequest request)
    {
        try
        {
            var id = await porscheCenterService.CreatePorscheCenter(request);

            return Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<int>> UpdatePorscheCenter(int id, [FromBody] PorscheCenterRequest request)
    {
        try
        {
            await porscheCenterService.UpdatePorscheCenter(request);

            return Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeletePorscheCenter(int id)
    {
        try
        {
            return await porscheCenterService.DeletePorscheCenter(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("AddToCenter")]
    public async Task<ActionResult<int>> AddCarToPorscheCenter([FromBody] AddingCarToThePorscheCenterRequest request)
    {
        try
        {
            return await porscheCenterService.AddCarToPorscheCenter(request);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}