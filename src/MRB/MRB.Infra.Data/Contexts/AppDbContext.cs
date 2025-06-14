using Microsoft.EntityFrameworkCore;
using MRB.Domain.Entities;

namespace MRB.Infra.Data.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<DeliveryPerson> DeliveryPeople { get; set; }
    public DbSet<Motorcycle> Motorcycles { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<MotorcycleCreated> MotorcycleCreateds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}