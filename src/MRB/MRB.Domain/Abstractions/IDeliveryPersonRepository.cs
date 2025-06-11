using MRB.Domain.Entities;

namespace MRB.Domain.Abstractions;

public interface IDeliveryPersonRepository
{
    public Task SaveAsync(DeliveryPerson entity);
}