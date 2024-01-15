using Microsoft.AspNetCore.Mvc;
using Porsche.API.Contracts;
using Porsche.Domain.Abstractions;
using Porsche.Domain.Models;

namespace Porsche.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponse>>> GetUsers()
    {
        var users = await userService.GetAllUsers();

        var response = users
            .Select(u => new UserResponse(u.Id, u.FirstName, u.SecondName,
                u.Email, u.Password));

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CrateUser([FromBody] UserRequest request)
    {
        var user = new User()
        {
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            Email = request.Email,
            Password = request.Password,
        };

        if (user == null)
        {
            return BadRequest();
        }

        var id = await userService.CreateUser(user);

        return Ok(id);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<int>> UpdateUser(int id, [FromBody] UserRequest request)
    {
        var user = new User()
        {
            Id = id,
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            Email = request.Email,
            Password = request.Password,
        };

        if (user == null)
        {
            return BadRequest();
        }
        
        await userService.UpdateUser(user);

        return Ok(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> DeleteUser(int id)
    {
        return Ok(await userService.DeleteUser(id));
    }
}