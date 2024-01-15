namespace Porsche.Domain.Models;

public class UserRole
{
    public int Id { get; set; }
    
    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;

    public int UserId { get; set; }

    public User User { get; set; } = null!;
}