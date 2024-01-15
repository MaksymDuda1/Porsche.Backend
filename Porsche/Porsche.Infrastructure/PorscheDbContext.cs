using Microsoft.EntityFrameworkCore;
using Porsche.Domain.Models;
using Porsche.Infrastructure.Entities;

namespace Porsche.Infrastructure;

public class PorscheDbContext : DbContext
{
    public PorscheDbContext(DbContextOptions<PorscheDbContext> options)
    :base(options)
    {
        
    }

    public DbSet<UserEntity> Users { get; set; }
    
    public DbSet<CarEntity> Cars { get; set; }
    
    public DbSet<Photo> Photos { get; set; }
    public DbSet<PorscheCenterEntity> PorscheCenters { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }
}