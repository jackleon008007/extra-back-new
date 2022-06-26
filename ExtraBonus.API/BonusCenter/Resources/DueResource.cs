using ExtraBonus.API.BonusCenter.Domain.Models;

namespace ExtraBonus.API.BonusCenter.Resources;

public class DueResource
{
    
    public int Id { get; set; } 
  

    public int Numero { get; set; }  
    public double Emisor { get; set; }  
    public double Bonista { get; set; }  
    public double EmisorEscudo { get; set; } 
    public double Inflacion { get; set; } 
    public double InflacionPeriodo { get; set; } 
    public double Bono { get; set; } 
    public double Indexado { get; set; }  
    public double Cupon { get; set; }  
    public double Prima { get; set; }  
    public double Amortizacion { get; set; }  
    public double Escudo { get; set; }  
    public double Activo { get; set; }  
    public double Plazo { get; set; } 
    public double Convexidad { get; set; } 
    public BondResource Bond { get; set; } 
}