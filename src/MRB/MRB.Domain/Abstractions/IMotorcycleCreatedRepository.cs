using MRB.Domain.Entities;

namespace MRB.Domain.Abstractions;

public interface IMotorcycleCreatedRepository
{
    public Task Save(MotorcycleCreated entity);
}