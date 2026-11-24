using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Configurations;

public sealed class ExpertiseConfiguration : IEntityTypeConfiguration<Expertise>
{
    public void Configure(EntityTypeBuilder<Expertise> builder)
    {
        builder.ToTable("Expertises");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);

        builder.HasIndex(p => p.DisplayOrder);
    }
}
