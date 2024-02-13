using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure;

public class PorscheDbContext : IdentityDbContext<UserEntity, RoleEntity, int>
{
    public PorscheDbContext(DbContextOptions<PorscheDbContext> options)
    :base(options)
    {
        
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CarEntity> Cars { get; set; }
    
    public DbSet<CarPhotoEntity> CarPhotos { get; set; }
    public DbSet<UserPhotoEntity> UserPhotos { get; set; }
    public DbSet<PorscheCenterEntity> PorscheCenters { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RoleEntity>()
            .HasData(
                new RoleEntity()
                {
                    Id = 1,
                    Name = "User",
                    NormalizedName = "USER"
                },
                new RoleEntity()
                {
                    Id = 2,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
    }
}