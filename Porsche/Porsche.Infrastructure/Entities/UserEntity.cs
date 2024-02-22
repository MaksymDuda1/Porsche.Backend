using Microsoft.AspNetCore.Identity;
using Porsche.Domain.Enums;
using Porsche.Domain.Models;

namespace Porsche.Infrastructure.Entities;

public class UserEntity: IdentityUser<int>
{
    public string FirstName { get; set; } = null!;
    public string SecondName { get; set; } = null!;
    
    public int PhotoId { get; set; }

    public UserPhotoEntity? Photos { get; set; } = new UserPhotoEntity();

}