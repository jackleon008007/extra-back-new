using System.ComponentModel.DataAnnotations;

namespace ExtraBonus.API.BonusCenter.Resources;

public class SaveResultResource
{
    [Required]
    public int Frecuencia { get; set; }  
    [Required]
    public int Capitalizacion { get; set; }  
    [Required]
    public int Periodo { get; set; } 
    [Required]
    public int TotalPeriodo { get; set; }  
    [Required]
    public double EfectivaAnual { get; set; }  
    [Required]
    public double Efectiva { get; set; } 
    [Required]
    public double Cok { get; set; } 
    [Required]
    public double CostoEmisor { get; set; }  
    [Required]
    public double CostoInversor { get; set; }  
    [Required]
    public double Utilidad { get; set; } 
    [Required]
    public double Duracion { get; set; }  
    [Required]
    public double Convexidad { get; set; } 
    [Required]
    public double Total { get; set; } 
    [Required]
    public double DuracionModif { get; set; }
    [Required]
    public double Precio { get; set; }
    [Required]
    public double TCEAemisor { get; set; }
    [Required]
    public double TCEAemisorEscudo { get; set; }
    [Required]
    public double TREAbonista { get; set; }
    [Required]
    public int BondId { get; set; }
}