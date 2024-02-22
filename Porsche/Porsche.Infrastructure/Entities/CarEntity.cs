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

    public PorscheCenterEntity? PorscheCenter { get; set; }

    public List<CarPhotoEntity>? Photos { get; set; } = new List<CarPhotoEntity>();    
}