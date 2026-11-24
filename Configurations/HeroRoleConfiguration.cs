using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Configurations;

public sealed class HeroRoleConfiguration : IEntityTypeConfiguration<HeroRole>
{
    public void Configure(EntityTypeBuilder<HeroRole> builder)
    {
        builder.ToTable("HeroRoles");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);

        builder.HasIndex(p => p.DisplayOrder);
    }
}
