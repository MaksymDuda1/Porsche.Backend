namespace Porsche.Application.Contracts;

public record RegisterRequest(
    string FirstName,
    string SecondName,
    string Email,
    string Password);