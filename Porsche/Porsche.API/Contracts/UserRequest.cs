using Porsche.Domain.Enums;

namespace Porsche.API.Contracts;

public record UserRequest(
    int Id,
    string FirstName,
    string SecondName,
    string Email,
    string Password);