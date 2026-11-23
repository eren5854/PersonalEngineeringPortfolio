using System.ComponentModel.DataAnnotations;

namespace PersonalEngineeringPortfolio.Models;

/// <summary>Ana sayfa monitöründe yazılarak değişen unvanlar.</summary>
public sealed class HeroRole : OrderedEntity
{
    [Required, MaxLength(100)]
    [Display(Name = "Unvan")]
    public string Title { get; set; } = string.Empty;
}