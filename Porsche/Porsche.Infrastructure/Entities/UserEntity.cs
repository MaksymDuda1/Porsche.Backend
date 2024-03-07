using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Porsche.Infrastructure.Entities;

public class UserEntity: IdentityUser<int>
{
    public string FirstName { get; set; } = null!;
    public string SecondName { get; set; } = null!;
    [JsonIgnore] 
    public UserPhotoEntity? Photo { get; set; }
    public List<CarEntity>? SavedCars { get; set; }

}