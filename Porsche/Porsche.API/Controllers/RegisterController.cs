
using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Abstractions;
using Porsche.Application.Contracts;


namespace Porsche.API.Controllers;

[ApiController]
[Route("api/register")]
public class RegisterController : ControllerBase
{
    private readonly IAuthorizationUserService authorizationService;

    public RegisterController(IAuthorizationUserService authorizationService)
    {
        this.authorizationService = authorizationService;
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterUser(RegisterRequest request)
    {
        try
        {
            var token = await authorizationService.RegisterUser(request);

            return Ok(token);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}