using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRB.Domain.Entities;

namespace MRB.Infra.Data.ContextMappers;

public class RentalMap : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("rentals");
        
        builder.HasKey(x => x.Id);
    }
}