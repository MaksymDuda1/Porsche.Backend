using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Abstractions;

namespace Porsche.API.Controllers;

[ApiController]
public class UserImageController: ControllerBase
{
    private readonly IUserImageService userImageService;

    public UserImageController(IUserImageService userImageService)
    {
        this.userImageService = userImageService;
    }
    
    [HttpPost("api/userImages/{id:int}")]
    public async Task<IActionResult> UploadPhoto(int id, [FromForm(Name = "Data")] IFormFile file)
    {
        var response = await userImageService.UploadImage(id, file);
        
        return Ok(response);
    }
}