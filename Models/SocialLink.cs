using System.ComponentModel.DataAnnotations;

namespace PersonalEngineeringPortfolio.Models;

/// <summary>Sosyal medya hesapları (monitör altı ve footer).</summary>
public sealed class SocialLink : OrderedEntity
{
    [Display(Name = "Platform")]
    public SocialPlatform Platform { get; set; }

    [Required, MaxLength(300), Url]
    [Display(Name = "Adres (URL)")]
    public string Url { get; set; } = string.Empty;

    [Display(Name = "Ana sayfada göster")]
    public bool ShowInHero { get; set; } = true;

    [Display(Name = "Footer'da göster")]
    public bool ShowInFooter { get; set; } = true;
}