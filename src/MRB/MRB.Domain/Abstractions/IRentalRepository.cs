using MRB.Domain.Entities;

namespace MRB.Domain.Abstractions;

public interface IRentalRepository
{
    public Task SaveAsync(Rental entity);
}