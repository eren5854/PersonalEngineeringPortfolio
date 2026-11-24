using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Configurations;

public sealed class WorkExperienceConfiguration : IEntityTypeConfiguration<WorkExperience>
{
    public void Configure(EntityTypeBuilder<WorkExperience> builder)
    {
        builder.ToTable("WorkExperiences");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

        builder.Property(p => p.Title).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Organization).IsRequired().HasMaxLength(150);
        builder.Property(p => p.StartYear).IsRequired();
        builder.Property(p => p.EndYear);               // null ise "Günümüz"
        builder.Property(p => p.Description).HasMaxLength(500);

        builder.HasIndex(p => p.DisplayOrder);
    }
}
