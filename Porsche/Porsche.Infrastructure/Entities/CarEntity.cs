using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Porsche.Domain.Enums;
using Porsche.Domain.Models;

namespace Porsche.Infrastructure.Entities;

public class CarEntity
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string IdentityCode { get; set; } = null!;
    
    [MaxLength(100)]
    public string Model { get; set; } = null!;
    
    public int YearOfEdition { get; set; }
    
    public BodyType BodyType { get; set; }
    
    public Color Color { get; set; }
    
    [MaxLength(100)]
    public string Engine { get; set; } = null!;
    
    public float FuelConsumption { get; set; }
    
    public float Price { get; set; }
    
    public string Description { get; set; } = null!;

    public bool IsAvailable { get; set; }
    
    [JsonIgnore] 
    public int? PorscheCenterId  { get; set; }
    
    [JsonIgnore] 
    public PorscheCenterEntity? PorscheCenter { get; set; }

    [JsonIgnore] 
    public List<CarPhotoEntity>? Photos { get; set; } = new List<CarPhotoEntity>();

    [JsonIgnore] 
    public List<UserEntity>? Users { get; set; } = new List<UserEntity>();

}