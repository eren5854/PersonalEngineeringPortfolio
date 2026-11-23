using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace PersonalEngineeringPortfolio.Models;

/// <summary>Osiloskop kanalı = yetenek kategorisi (en fazla 4 – service katmanında doğrulanacak).</summary>
public sealed class SkillCategory : OrderedEntity
{
    [Required, MaxLength(50)]
    [Display(Name = "Kategori Adı")]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(10)]
    [Display(Name = "Kanal Kodu")]
    public string ChannelCode { get; set; } = "CH1";

    [Display(Name = "Dalga Şekli")]
    public WaveType WaveType { get; set; } = WaveType.Sine;

    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
}