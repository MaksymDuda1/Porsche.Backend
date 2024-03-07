using Porsche.Domain.Enums;
using Porsche.Infrastructure.Entities;

namespace Porsche.API.Contracts;

public record UserResponse(
    int Id,
    string FirstName,
    string SecondName,
    string Email,
    string Password,
    UserPhotoEntity? Photo
    );