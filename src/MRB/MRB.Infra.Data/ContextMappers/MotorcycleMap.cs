using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRB.Domain.Entities;

namespace MRB.Infra.Data.ContextMappers;

public class MotorcycleMap : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.ToTable("motorcycle");
        
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.LicensePlate)
            .IsUnique();
        
        builder
            .HasQueryFilter(t => t.DeletedAt == null);
    }
}