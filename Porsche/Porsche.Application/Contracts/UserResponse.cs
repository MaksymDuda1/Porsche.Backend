using Porsche.Domain.Enums;

namespace Porsche.API.Contracts;

public record UserResponse(
    int Id,
    string FirstName,
    string SecondName,
    string Email,
    string Password);