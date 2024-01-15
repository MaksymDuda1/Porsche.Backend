using Porsche.Domain.Enums;
using Porsche.Domain.Models;

namespace Porsche.API.Contracts;

public record CarRequest(
    int Id,
    string IdentityCode,
    string Model,
    int YearOfEdition,
    BodyType BodyType,
    string Engine,
    PorscheCenter? PorscheCenter,
    List<Photo>? Photos);