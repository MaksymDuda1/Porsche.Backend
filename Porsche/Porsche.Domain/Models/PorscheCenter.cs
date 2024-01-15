namespace Porsche.Domain.Models;

public class PorscheCenter
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public List<Car>? Cars { get; set; }
}