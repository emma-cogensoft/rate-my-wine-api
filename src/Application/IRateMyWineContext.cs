using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application;

public interface IRateMyWineContext
{
    DbSet<Review> Reviews { get; }
    DbSet<Beverage> Beverages { get; }
    DbSet<Manufacturer> Manufacturers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}