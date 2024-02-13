using Porsche.Domain.Enums;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.API.Contracts;

public record CarRequest(
    int Id,
    string IdentityCode,
    string Model,
    int YearOfEdition,
    BodyType BodyType,
    string Engine,
    PorscheCenter? PorscheCenter,
    List<CarPhoto>? Photos);