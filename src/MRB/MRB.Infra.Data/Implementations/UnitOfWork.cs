using MRB.Infra.Data.Abstractions;
using MRB.Infra.Data.Contexts;

namespace MRB.Infra.Data.Implementations;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}