using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Configurations;

public sealed class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("MenuItems");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

        builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Anchor).IsRequired().HasMaxLength(50);

        // Silinmiş kayıtlar benzersizlik kuralının dışında kalır
        builder.HasIndex(p => p.Anchor)
            .IsUnique()
            .HasFilter("\"IsDeleted\" = false");

        builder.HasIndex(p => p.DisplayOrder);
    }
}
