using Porsche.Domain.Models;

namespace Porsche.Infrastructure.Entities;

public class PorscheCenterEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public List<Car>? Cars { get; set; } = new List<Car>();
}