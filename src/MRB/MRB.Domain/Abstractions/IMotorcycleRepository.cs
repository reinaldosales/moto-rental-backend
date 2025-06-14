using MRB.Domain.Entities;

namespace MRB.Domain.Abstractions;

public interface IMotorcycleRepository
{
    public Task Save(Motorcycle entity);
    public Task<IEnumerable<Motorcycle>> GetAll();
    public Task<Motorcycle> GetByLicensePlate(string licensePlate);
    public Task<Motorcycle> GetById(long id);
    public Task<Motorcycle> GetByIdentifier(string modelMotorcycleIdentifier);
}