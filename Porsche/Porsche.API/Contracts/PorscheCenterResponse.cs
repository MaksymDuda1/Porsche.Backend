using Porsche.Domain.Models;

namespace Porsche.API.Contracts;

public record PorscheCenterResponse(
    int Id,
    string Name,
    string Address,
    List<Car>? Cars);