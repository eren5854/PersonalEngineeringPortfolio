using System.ComponentModel.DataAnnotations;

namespace PersonalEngineeringPortfolio.Models;

/// <summary>Eğitim ve çalışma geçmişinin ortak alanları (kronolojik kablo çizgisi).</summary>
public abstract class TimelineEntityBase : OrderedEntity
{
    [Required, MaxLength(150)]
    [Display(Name = "Başlık")]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(150)]
    [Display(Name = "Kurum / Şirket")]
    public string Organization { get; set; } = string.Empty;

    [Display(Name = "Başlangıç Yılı")]
    public int StartYear { get; set; }

    /// <summary>Null ise "Günümüz" olarak gösterilir.</summary>
    [Display(Name = "Bitiş Yılı")]
    public int? EndYear { get; set; }

    [MaxLength(500)]
    [Display(Name = "Açıklama")]
    public string? Description { get; set; }
}