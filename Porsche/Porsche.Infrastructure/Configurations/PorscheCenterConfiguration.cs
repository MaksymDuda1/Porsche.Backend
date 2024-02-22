using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure.Configurations;

public class PorscheCenterConfiguration : IEntityTypeConfiguration<PorscheCenterEntity>
{
    public void Configure(EntityTypeBuilder<PorscheCenterEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Address)
            .IsRequired();

        builder.Property(c => c.Name)
            .IsRequired();
    }
}