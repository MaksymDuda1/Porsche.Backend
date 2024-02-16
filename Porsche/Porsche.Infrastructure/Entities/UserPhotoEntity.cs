namespace Porsche.Infrastructure.Entities;

public class UserPhotoEntity
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;
    
    public int UserId { get; set; }

    public UserEntity? User { get; set; }
}