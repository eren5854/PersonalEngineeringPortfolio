using System.ComponentModel.DataAnnotations;

namespace PersonalEngineeringPortfolio.Models;

/// <summary>İletişim terminalinden gelen mesajlar (admin panelde okunacak).</summary>
public sealed class ContactMessage : Entity
{
    [Required, MaxLength(100)]
    [Display(Name = "İsim")]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(150), EmailAddress]
    [Display(Name = "E-posta")]
    public string Email { get; set; } = string.Empty;

    [Required, MaxLength(2000)]
    [Display(Name = "Mesaj")]
    public string Message { get; set; } = string.Empty;

    [Display(Name = "Okundu")]
    public bool IsRead { get; set; }
}