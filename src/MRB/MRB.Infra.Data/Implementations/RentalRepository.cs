using Microsoft.EntityFrameworkCore;
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

    public async Task<Rental> GetById(long id)
    {
        return await _dbContext.Rentals
            .Include(x => x.Motorcycle)
            .Include(x => x.DeliveryPerson)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Rental> GetByIdentifier(string identifier)
    {
        return await _dbContext.Rentals
            .Include(x => x.Motorcycle)
            .Include(x => x.DeliveryPerson)
            .FirstOrDefaultAsync(x => x.Identifier == identifier);
    }
}