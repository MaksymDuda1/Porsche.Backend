namespace Porsche.Application.Contracts;

public record AddingCarToThePorscheCenterRequest(
    int PorscheCenterId,
    int CarId
);
