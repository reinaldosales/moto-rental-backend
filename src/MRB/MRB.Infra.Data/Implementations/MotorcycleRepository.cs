using MRB.Domain.Abstractions;
using MRB.Domain.Entities;
using MRB.Infra.Data.Contexts;

namespace MRB.Infra.Data.Implementations;

public class MotorcycleRepository(AppDbContext dbContext) : IMotorcycleRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    
    public async Task Save(Motorcycle entity)
    {
        await _dbContext.AddAsync(entity);
    }
}