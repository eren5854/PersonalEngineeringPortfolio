using System.ComponentModel.DataAnnotations;

namespace PersonalEngineeringPortfolio.Models;

/// <summary>Navbar butonları (Ana Sayfa, Hakkımda, ...).</summary>
public sealed class MenuItem : OrderedEntity
{
    [Required, MaxLength(50)]
    [Display(Name = "Başlık")]
    public string Title { get; set; } = string.Empty;

    /// <summary>Hedef bölümün id değeri, örn. "hakkimda".</summary>
    [Required, MaxLength(50)]
    [Display(Name = "Bölüm Kimliği (anchor)")]
    public string Anchor { get; set; } = string.Empty;
}