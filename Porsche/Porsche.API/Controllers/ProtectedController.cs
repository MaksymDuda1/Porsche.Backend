using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Porsche.API.Controllers;
[Authorize]
[ApiController]
[Route("api/protected")]
public class ProtectedController: ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var sidClaim = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
        var id = int.Parse(sidClaim.Value);

        Console.WriteLine();
        
        var data = $"This is a big secret for {id}";

        return Ok(data);
    }
}