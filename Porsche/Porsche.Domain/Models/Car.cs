using Porsche.Domain.Enums;

namespace Porsche.Domain.Models;

public class Car
{
    public int Id { get; set; }

    public string IdentityCode { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int YearOfEdition { get; set; }

    public BodyType BodyType { get; set; }

    public string Engine { get; set; } = null!;//винести в окерму таблицю
    
    public int? PorscheCenterId  { get; set; }

    public PorscheCenter? PorscheCenter { get; set; }

    public List<CarPhoto>? Photos { get; set; } = new List<CarPhoto>();

}