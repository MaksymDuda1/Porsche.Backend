using Microsoft.AspNetCore.Mvc;
using Porsche.Application.Contracts;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Abstractions;

public interface IUserService
{
    Task<List<UserEntity>> GetAllUsers();
    Task<bool> AddCarToSaved(AddCarToSavedRequest request);
    Task<List<CarEntity>> GetSavedCars(int id);


}