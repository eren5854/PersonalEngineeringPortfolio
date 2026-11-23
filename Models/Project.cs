using System.ComponentModel.DataAnnotations;

namespace PersonalEngineeringPortfolio.Models;

/// <summary>Projeler bölümündeki kart: görsel, isim ve link.</summary>
public sealed class Project : OrderedEntity
{
    [Required, MaxLength(100)]
    [Display(Name = "Proje Adı")]
    public string Title { get; set; } = string.Empty;

    [MaxLength(300)]
    [Display(Name = "Proje Görseli")]
    public string? ImagePath { get; set; }

    [Required, MaxLength(300), Url]
    [Display(Name = "Proje Linki")]
    public string Url { get; set; } = string.Empty;

    [Display(Name = "Kategori")]
    public int ProjectCategoryId { get; set; }

    public ProjectCategory? ProjectCategory { get; set; }
}
