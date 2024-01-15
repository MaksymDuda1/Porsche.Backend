using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Porsche.Domain.Models;

namespace Porsche.Infrastructure.Configurations;

public class PorscheCenterConfiguration : IEntityTypeConfiguration<PorscheCenter>
{
    public void Configure(EntityTypeBuilder<PorscheCenter> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Address)
            .IsRequired();

        builder.Property(c => c.Name)
            .IsRequired();
    }
}