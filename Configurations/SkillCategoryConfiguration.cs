using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Configurations;

public sealed class SkillCategoryConfiguration : IEntityTypeConfiguration<SkillCategory>
{
    public void Configure(EntityTypeBuilder<SkillCategory> builder)
    {
        builder.ToTable("SkillCategories");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.ChannelCode).IsRequired().HasMaxLength(10);

        builder.Property(p => p.WaveType)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasIndex(p => p.Name)
            .IsUnique()
            .HasFilter("\"IsDeleted\" = false");

        // Her osiloskop kanalı (CH1, CH2...) tek kategoriye ait olur
        builder.HasIndex(p => p.ChannelCode)
            .IsUnique()
            .HasFilter("\"IsDeleted\" = false");

        builder.HasIndex(p => p.DisplayOrder);

        // Kategoriye bağlı yetenek varken kategori fiziksel silinemez
        builder.HasMany(p => p.Skills)
            .WithOne(p => p.SkillCategory)
            .HasForeignKey(p => p.SkillCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
