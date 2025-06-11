using MRB.Domain.Entities;

namespace MRB.Domain.Abstractions;

public interface IRentalRepository
{
    public Task Save(Rental entity);
}