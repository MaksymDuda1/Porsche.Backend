using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Application.Services;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;

namespace Porsche.API.Controllers;

[ApiController]
[Route("api/photo")]
public class PhotoController: ControllerBase
{
    private readonly IPhotoService photoService;

    public PhotoController(IPhotoService photoService)
    {
        this.photoService = photoService;
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> AddPhoto(PhotoRequest request)
    {
        var photo = new Photo()
        {
            Address = request.Address,
            CarId = request.CarId
        };
        
        return await photoService.AddPhoto(photo);
    }
}