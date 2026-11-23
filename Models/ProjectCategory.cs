using System.ComponentModel.DataAnnotations;

namespace PersonalEngineeringPortfolio.Models;

/// <summary>Proje filtre kategorisi (en fazla 4 – service katmanında doğrulanacak).</summary>
public sealed class ProjectCategory : OrderedEntity
{
    [Required, MaxLength(50)]
    [Display(Name = "Kategori Adı")]
    public string Name { get; set; } = string.Empty;

    /// <summary>Filtre butonunda kullanılan kısa kod, örn. "gomulu".</summary>
    [Required, MaxLength(50)]
    [Display(Name = "Kısa Ad (slug)")]
    public string Slug { get; set; } = string.Empty;

    public ICollection<Project> Projects { get; set; } = new List<Project>();
}