using MRB.Application.DTOs;
using MRB.Application.Models.Create;
using MRB.Domain.Entities;

namespace MRB.Application.Abstractions;

public interface IMotorcycleService
{
    public Task CreateMotorCycle(CreateMotorcycleModel model);
    public Task<IEnumerable<MotorcycleDto>> GetAll();
    public Task<MotorcycleDto> GetByLicensePlate(string licensePlate);
    public Task<bool> UpdateLicensePlate(string identifier, string newLicensePlate);
    public Task<MotorcycleDto> GetById(long id);
    public Task<bool> Delete(string id);
    Task<MotorcycleDto> GetByIdentifier(string identifier);
}