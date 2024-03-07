using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Contracts;

public record PorscheCenterRequest(
    int Id,
    string Name,
    string Address,
    List<CarEntity>? Cars);