using System.ComponentModel.DataAnnotations;

namespace ExtraBonus.API.BonusCenter.Resources;

public class SaveBondResource
{
    [Required]
    public double Nominal{ get; set; } 
    [Required]
    public double Comercial { get; set; } 
    [Required]
    public int Anos { get; set; }
    [Required]
    public int Frecuencia { get; set; }  
    [Required]
    public int Dias { get; set; }  
    [Required]
    public string Tasa { get; set; }  
    [Required]
    public int Capitalizacion { get; set; }  
    [Required]
    public double Interes { get; set; }  
    [Required]
    public double Descuento { get; set; } 
    [Required]
    public double Renta { get; set; }  
    [Required]
    public DateTime Fecha { get; set; }  
    [Required]
    public double Prima { get; set; }  
    [Required]
    public double Estructuracion { get; set; }  
    [Required]
    public double Colocacion { get; set; }  
    [Required]
    public double Flotacion { get; set; } 
    [Required]
    public double Cavali { get; set; } 
    [Required]
    public int UserId{ get; set; } 
}