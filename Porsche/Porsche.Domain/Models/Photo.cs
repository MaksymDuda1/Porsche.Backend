namespace Porsche.Domain.Models;

public class CarPhoto
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;
    
    public int CarId { get; set; }

    public Car? Car { get; set; }
}
