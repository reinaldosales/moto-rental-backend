using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<Motorcycle>> GetAll()
    {
        return await _dbContext.Motorcycles
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Motorcycle> GetByLicensePlate(string licensePlate)
    {
        return await _dbContext.Motorcycles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.LicensePlate == licensePlate);
    }
}