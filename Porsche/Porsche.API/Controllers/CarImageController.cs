using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Abstractions;

namespace Porsche.API.Controllers;

[ApiController]
public class CarImageController: ControllerBase
{
    private readonly ICarImageService carImageService;

    public CarImageController(ICarImageService carImageService)
    {
        this.carImageService = carImageService;
    }

    [HttpPost("api/carImages/{id:int}")]
    public async Task<IActionResult> UploadPhoto(int id, [FromForm(Name = "Data")] IFormFile file)
    {
        var response = await carImageService.UploadImage(id, file);
        
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePhoto(int id)
    {
        await carImageService.DeleteImage(id);

        return Ok();
    }
}