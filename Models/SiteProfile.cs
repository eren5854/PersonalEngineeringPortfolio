using System.ComponentModel.DataAnnotations;

namespace PersonalEngineeringPortfolio.Models;

/// <summary>
/// Sitenin tekil (tek satırlık) genel bilgileri: logo, ad, hakkımda yazısı,
/// fotoğraf, iletişim bilgileri ve footer metinleri.
/// </summary>
public sealed class SiteProfile : Entity
{
    [Required, MaxLength(150)]
    [Display(Name = "Site Başlığı")]
    public string SiteTitle { get; set; } = string.Empty;

    [Required, MaxLength(3)]
    [Display(Name = "Logo Harfi")]
    public string LogoText { get; set; } = "M";

    [MaxLength(300)]
    [Display(Name = "Logo Görseli")]
    public string? LogoImagePath { get; set; }

    [Required, MaxLength(100)]
    [Display(Name = "Ad Soyad")]
    public string FullName { get; set; } = string.Empty;

    [Required, MaxLength(1500)]
    [Display(Name = "Hakkımda Yazısı")]
    public string AboutText { get; set; } = string.Empty;

    [MaxLength(300)]
    [Display(Name = "Fotoğraf")]
    public string? PhotoPath { get; set; }

    [Required, MaxLength(150), EmailAddress]
    [Display(Name = "E-posta")]
    public string Email { get; set; } = string.Empty;

    [Required, MaxLength(30), Phone]
    [Display(Name = "Telefon")]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(200)]
    [Display(Name = "Adres")]
    public string? Address { get; set; }

    [MaxLength(300)]
    [Display(Name = "Footer Açıklaması")]
    public string? FooterDescription { get; set; }

    [MaxLength(150)]
    [Display(Name = "Footer Sloganı")]
    public string? FooterSlogan { get; set; }
}