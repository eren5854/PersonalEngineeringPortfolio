using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Configurations;

public sealed class ProjectCategoryConfiguration : IEntityTypeConfiguration<ProjectCategory>
{
    public void Configure(EntityTypeBuilder<ProjectCategory> builder)
    {
        builder.ToTable("ProjectCategories");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Slug).IsRequired().HasMaxLength(50);

        builder.HasIndex(p => p.Slug)
            .IsUnique()
            .HasFilter("\"IsDeleted\" = false");

        builder.HasIndex(p => p.DisplayOrder);

        // Kategoriye bağlı proje varken kategori fiziksel silinemez
        builder.HasMany(p => p.Projects)
            .WithOne(p => p.ProjectCategory)
            .HasForeignKey(p => p.ProjectCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
