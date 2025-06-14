using MRB.Domain.Entities;

namespace MRB.Domain.Abstractions;

public interface IRentalRepository
{
    public Task SaveAsync(Rental entity);
    public Task<Rental> GetById(long id);
    public Task<Rental> GetByIdentifier(string identifier);
}