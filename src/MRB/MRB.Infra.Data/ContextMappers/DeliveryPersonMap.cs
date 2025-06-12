using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRB.Domain.Entities;

namespace MRB.Infra.Data.ContextMappers;

public class DeliveryPersonMap : IEntityTypeConfiguration<DeliveryPerson>
{
    public void Configure(EntityTypeBuilder<DeliveryPerson> builder)
    {
        builder.ToTable("delivery_person");
        
        builder.HasKey(x => x.Id);
        
        builder
            .HasIndex(x => new { x.TaxId, x.DriverLicenseNumber})
            .IsUnique();
    }
}