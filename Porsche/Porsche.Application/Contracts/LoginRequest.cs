namespace Porsche.API.Contracts;

public record LoginRequest(
    int Id, 
    string Email,
    string Password);