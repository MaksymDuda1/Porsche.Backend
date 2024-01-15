namespace Porsche.Domain.Models;

public class Photo
{
    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public int CarId { get; set; }

    public Car? Car { get; set; }
}