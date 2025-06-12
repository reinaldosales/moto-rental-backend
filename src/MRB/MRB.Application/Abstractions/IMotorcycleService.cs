using MRB.Application.Models.Create;
using MRB.Domain.Entities;
using MRB.Domain.Models.Create;

namespace MRB.Application.Abstractions;

public interface IMotorcycleService
{
    public Task Save(CreateMotorcycleModel model);
    public Task<IEnumerable<Motorcycle>> GetAll();
    public Task<Motorcycle> GetByLicensePlate(string licensePlate);
}