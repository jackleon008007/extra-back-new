using System.ComponentModel.DataAnnotations;

namespace ExtraBonus.API.Security.Resources;

public class SaveUserResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Email { get; set; }

    [Required]
    [MaxLength(80)]
    public string Password { get; set; }
    [Required]
    [MaxLength(80)]
    public string Ruc { get; set; }
}