using System.ComponentModel.DataAnnotations;

namespace PersonalEngineeringPortfolio.Models;

/// <summary>Osiloskop ekranında görünen tek bir yetenek adı.</summary>
public sealed class Skill : OrderedEntity
{
    [Required, MaxLength(50)]
    [Display(Name = "Yetenek")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Kategori")]
    public Guid? SkillCategoryId { get; set; }

    public SkillCategory? SkillCategory { get; set; }
}