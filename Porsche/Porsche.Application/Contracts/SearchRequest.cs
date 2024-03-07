using Porsche.Domain.Enums;
using Porsche.Domain.Models;

namespace Porsche.Application.Contracts;


//car response used against search response 
public record SearchRequest(
    string? Model,
    BodyType[]? BodyType,
    Color[]? Color,
    int? MinYearOfRelease,
    int? MaxYearOfRelease,
    float? MinPrice,
    float MaxPrice,
    string[]? Engine, 
    string[]? PorscheCenter
    );