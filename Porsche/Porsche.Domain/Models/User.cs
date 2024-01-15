using Porsche.Domain.Enums;

namespace Porsche.Domain.Models;

public class User
{
    public const int MaxLength = 100;

    public int Id { get; set; }

    public string FirstName { get; set; } 

    public string SecondName { get; set; } 

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public List<UserRole> UserRoles { get; set; }
}