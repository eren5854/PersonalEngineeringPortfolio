using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Configurations;

public sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Property(p => p.ImagePath).HasMaxLength(300);
        builder.Property(p => p.Url).IsRequired().HasMaxLength(300);
        builder.Property(p => p.ProjectCategoryId).IsRequired();

        builder.HasIndex(p => new { p.ProjectCategoryId, p.DisplayOrder });
    }
}
