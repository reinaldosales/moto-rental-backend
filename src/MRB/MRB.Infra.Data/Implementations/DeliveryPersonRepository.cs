using MRB.Domain.Abstractions;
using MRB.Domain.Entities;
using MRB.Infra.Data.Contexts;

namespace MRB.Infra.Data.Implementations;

public class DeliveryPersonRepository(AppDbContext dbContext) : IDeliveryPersonRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    
    public async Task SaveAsync(DeliveryPerson entity)
    {
        await _dbContext.AddAsync(entity);
    }
}