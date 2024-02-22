using Porsche.Domain.Enums;
using Porsche.Domain.Models;

namespace Porsche.API.Contracts;


//car response used against search response 
public record SearchRequest(
    string? Model,
    BodyType? BodyType,
    int? MinYearOfRelease,
    int? MaxYearOfRelease,
    string? Engine,
    string? PorscheCenter
    );