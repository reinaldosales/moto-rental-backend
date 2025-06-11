using MRB.Domain.Abstractions;
using MRB.Domain.Entities;
using MRB.Infra.Data.Contexts;

namespace MRB.Infra.Data.Implementations;

public class RentalRepository(AppDbContext dbContext) : IRentalRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    
    public async Task SaveAsync(Rental entity)
    {
        await _dbContext.AddAsync(entity);
    }
}