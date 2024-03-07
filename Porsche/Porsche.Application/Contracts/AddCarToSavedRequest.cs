namespace Porsche.Application.Contracts;

public record AddCarToSavedRequest(
    int CarId,
    int UserId);