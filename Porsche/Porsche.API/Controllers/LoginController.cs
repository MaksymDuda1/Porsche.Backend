using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Application.Abstractions;
using Porsche.Application.Services;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;

namespace Porsche.API.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly IAuthorizationUserService authorizationService;

    public LoginController(IAuthorizationUserService authorizationService)
    {
        this.authorizationService = authorizationService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> LoginUser([FromBody] LoginRequest request)
    {
        try
        {
            var token = await authorizationService.LoginUser(request);

            return Ok(token);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}