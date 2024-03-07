using Porsche.API.Contracts;
using Porsche.Application.Contracts;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Application.Abstractions;

public interface IPorscheCenterService
{
    Task<List<PorscheCenterEntity>> GetAllPorscheCenters();
    Task<PorscheCenterEntity> GetPorscheCenterById(int id);
    Task<int> CreatePorscheCenter(PorscheCenterRequest porscheCenter);
    Task<int> UpdatePorscheCenter(PorscheCenterRequest porscheCenter);
    Task<int> DeletePorscheCenter(int id);
    Task<int> AddCarToPorscheCenter(AddingCarToThePorscheCenterRequest request);

}