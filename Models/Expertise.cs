using System.ComponentModel.DataAnnotations;

namespace PersonalEngineeringPortfolio.Models;

/// <summary>Footer'daki "Uzmanlık" listesi maddeleri.</summary>
public sealed class Expertise : OrderedEntity
{
    [Required, MaxLength(100)]
    [Display(Name = "Uzmanlık Alanı")]
    public string Title { get; set; } = string.Empty;
}
