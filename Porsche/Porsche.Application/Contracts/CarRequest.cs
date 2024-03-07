using Porsche.Domain.Enums;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Contracts;

public record CarRequest(
    string IdentityCode,
    string Model,
    int YearOfEdition,
    BodyType BodyType,
    Color Color,
    string Engine,
    float FuelConsumption,
    float Price,
    PorscheCenterEntity? PorscheCenter,
    List<CarPhotoEntity>? Photos
    );