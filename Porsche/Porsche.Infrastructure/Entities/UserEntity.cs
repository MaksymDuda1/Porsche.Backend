using Microsoft.AspNetCore.Identity;
using Porsche.Domain.Enums;
using Porsche.Domain.Models;

namespace Porsche.Infrastructure.Entities;

public class UserEntity: IdentityUser<int>
{ 
    public string FirstName { get; set; } 
    public string SecondName { get; set; }
    
}