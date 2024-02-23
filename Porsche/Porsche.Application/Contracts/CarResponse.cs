using Porsche.Domain.Enums;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.API.Contracts;

public record CarResponse(
    int Id,
    string IdentityCode,
    string Model,
    int YearOfEdition,
    BodyType BodyType,
    EngineEntity Engine,
    PorscheCenterEntity? PorscheCenter,
    List<CarPhotoEntity>? Photos);