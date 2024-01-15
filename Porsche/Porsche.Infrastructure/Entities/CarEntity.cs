using Porsche.Domain.Enums;
using Porsche.Domain.Models;

namespace Porsche.Infrastructure.Entities;

public class CarEntity
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
    
    public Car ToCar()
    {
        return new Car()
        {
            Id = this.Id,
            IdentityCode = this.IdentityCode,
            Model = this.Model,
            YearOfEdition = this.YearOfEdition,
            BodyType = this.BodyType,
            Engine = this.Engine
        };
    }
    
}