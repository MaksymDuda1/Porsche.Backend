
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<CarEntity>
{
    public void Configure(EntityTypeBuilder<CarEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.IdentityCode)
            .IsRequired();

        builder.Property(c => c.Model)
            .IsRequired();
        
        builder.Property(c => c.BodyType)
            .IsRequired();

        builder.Property(c => c.Engine)
            .IsRequired();

        builder.Property(c => c.YearOfEdition)
            .IsRequired();
    }
}