using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Porsche.Domain.Models;

public class RoleUpdate
{
    public int UserId { get; set; }
    public string Role { get; set; }
}