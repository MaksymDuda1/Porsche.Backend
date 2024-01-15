using Porsche.Domain.Enums;

namespace Porsche.Domain.Models;

public class Car
{
    public int Id { get; set; }

    public string IdentityCode { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int YearOfEdition { get; set; }

    public BodyType BodyType { get; set; }

    public string Engine { get; set; } = null!;

    public int? PorscheCenterId  { get; set; }

    public PorscheCenter? PorscheCenter { get; set; }

    public List<Photo>? Photos { get; set; } = new List<Photo>();

}