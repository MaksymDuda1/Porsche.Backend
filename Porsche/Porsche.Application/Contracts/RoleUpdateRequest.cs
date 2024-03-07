namespace Porsche.Application.Contracts;

public record RoleUpdateRequest(
    int UserId,
    string Role
    );