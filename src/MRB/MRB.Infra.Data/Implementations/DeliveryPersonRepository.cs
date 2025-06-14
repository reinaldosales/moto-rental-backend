using Microsoft.EntityFrameworkCore;
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

    public async Task<DeliveryPerson> GetById(long id)
    {
        return await _dbContext.DeliveryPeople.FindAsync(id);
    }

    public async Task<DeliveryPerson> GetByIdentifier(string modelDeliveryPersonIdentifier)
    {
        return await _dbContext.DeliveryPeople.FirstOrDefaultAsync(x => x.Identifier == modelDeliveryPersonIdentifier);
    }
}