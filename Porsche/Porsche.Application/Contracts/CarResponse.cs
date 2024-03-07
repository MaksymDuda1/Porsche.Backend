using Porsche.Domain.Enums;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Contracts;

public record CarResponse(
    int Id,
    string IdentityCode,
    string Model,
    int YearOfEdition,
    BodyType BodyType,
    Color Color,
    string Engine,
    float FuelConsumption,
    float Price,
    bool IsAvailable,
    int? PorscheCenterId,
    List<CarPhotoEntity>? Photos);