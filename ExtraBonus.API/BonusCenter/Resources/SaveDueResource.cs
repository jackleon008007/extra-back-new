using System.ComponentModel.DataAnnotations;

namespace ExtraBonus.API.BonusCenter.Resources;

public class SaveDueResource
{
    [Required]
    public int Numero { get; set; }  
    [Required]
    public double Emisor { get; set; }
 
    [Required]
    public double Bonista { get; set; }  
    [Required]
    public double EmisorEscudo { get; set; } 
    [Required]
    public double Inflacion { get; set; } 
    [Required]
    public double InflacionPeriodo { get; set; } 
    [Required]
    public double Bono { get; set; } 
    [Required]
    public double Indexado { get; set; }  
    [Required]
    public double Cupon { get; set; }  
    [Required]
    public double Prima { get; set; }  
    [Required]
    public double Amortizacion { get; set; }  
    [Required]
    public double Escudo { get; set; }  
    [Required]
    public double Activo { get; set; }  
    [Required]
    public double Plazo { get; set; } 
    [Required]
    public double Convexidad { get; set; } 
    [Required]
    public int BondId { get; set; } 
}