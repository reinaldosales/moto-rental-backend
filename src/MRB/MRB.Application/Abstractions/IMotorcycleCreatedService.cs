using MRB.Domain.Entities;

namespace MRB.Application.Abstractions;

public interface IMotorcycleCreatedService
{
    public Task MotorcycleCreated(MotorcycleCreated motorcycleCreated);
}