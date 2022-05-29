using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence;

public class BeverageConfiguration : IEntityTypeConfiguration<Beverage>
{
    public void Configure(EntityTypeBuilder<Beverage> builder)
    {
        builder.HasOne(e => e.Manufacturer);
    }
}
