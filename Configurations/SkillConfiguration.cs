using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Configurations;

public sealed class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable("Skills");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.SkillCategoryId).IsRequired();

        builder.HasIndex(p => new { p.SkillCategoryId, p.DisplayOrder });

        // Aynı kategoride aynı yetenek iki kez eklenemez
        builder.HasIndex(p => new { p.SkillCategoryId, p.Name })
            .IsUnique()
            .HasFilter("\"IsDeleted\" = false");
    }
}
