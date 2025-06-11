using MRB.Domain.Entities;

namespace MRB.Domain.Abstractions;

public interface IMotorcycleRepository
{
    public Task Save(Motorcycle entity);
}