using MRB.Domain.Abstractions;
using MRB.Domain.Entities;
using MRB.Infra.Data.Contexts;

namespace MRB.Infra.Data.Implementations;

public class MotorcycleCreatedRepository(AppDbContext appDbContext) : IMotorcycleCreatedRepository
{
    readonly AppDbContext _appDbContext = appDbContext;
    
    public async Task Save(MotorcycleCreated entity)
    {
        await appDbContext.MotorcycleCreateds.AddAsync(entity);
    }
}