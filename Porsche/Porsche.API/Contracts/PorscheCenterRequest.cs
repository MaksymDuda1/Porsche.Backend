using Porsche.Domain.Models;

namespace Porsche.API.Contracts;

public record PorscheCenterRequest(
    int Id,
    string Name,
    string Address,
    List<Car>? Cars);