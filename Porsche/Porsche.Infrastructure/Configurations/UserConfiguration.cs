using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(p => p.Id);

        /*builder.Property(u => u.FirstName)
            .HasMaxLength(RegisterModel.MaxLength);

        builder.Property(u => u.SecondName)
            .HasMaxLength(RegisterModel.MaxLength);*/

    }
}