using Porsche.Domain.Enums;
using Porsche.Domain.Models;

namespace Porsche.Infrastructure.Entities;

public class UserEntity
{ 
    public int Id { get; set; }
    public string FirstName { get; set; } 

    public string SecondName { get; set; } 

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public List<UserRole> Roles { get; set; } = new List<UserRole>();
    
    public User ToUser()
    {
        return new User
        {
            Id = this.Id,
            FirstName = this.FirstName,
            SecondName = this.SecondName,
            Email = this.Email,
            Password = this.Password
        };
    }
}