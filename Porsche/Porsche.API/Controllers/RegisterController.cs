using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;

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
    public async Task<IActionResult> RegisterUser(UserRequest request)
    {
        var user = new User()
        {
            Id = request.Id,
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            Email = request.Email,
            Password = request.Password
        };
            
        var token = await authorizationService.RegisterUser(user);

        return Ok(token);
    }
}