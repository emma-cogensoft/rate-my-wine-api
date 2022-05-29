using System.Reflection;
using Application;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class RateMyWineContext : DbContext, IRateMyWineContext
{
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Beverage> Beverages => Set<Beverage>();
    public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();

    public RateMyWineContext(DbContextOptions<RateMyWineContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
         return base.SaveChangesAsync(cancellationToken);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=RateMyIWine;Trusted_Connection=True");
    }
}