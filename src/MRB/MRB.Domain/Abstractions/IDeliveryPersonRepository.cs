using MRB.Domain.Entities;

namespace MRB.Domain.Abstractions;

public interface IDeliveryPersonRepository
{
    public Task SaveAsync(DeliveryPerson entity);
    public Task<DeliveryPerson> GetById(long id);
    public Task<DeliveryPerson> GetByIdentifier(string modelDeliveryPersonIdentifier);
}