
using ExtraBonus.API.Security.Domain.Models;
using ExtraBonus.API.Security.Resources;

namespace ExtraBonus.API.BonusCenter.Resources;

public class BondResource
{
    
    public int Id{ get; set; } 
    public double Nominal{ get; set; } 
    public double Comercial { get; set; } 
    public int Anos { get; set; } 
    public int Frecuencia { get; set; }  
    public int Dias { get; set; }  
    public string Tasa { get; set; }  
    public int Capitalizacion { get; set; }  
    public double Interes { get; set; }  
    public double Descuento { get; set; } 
    public double Renta { get; set; }  
    public DateTime Fecha { get; set; }  
    public double Prima { get; set; }  
    public double Estructuracion { get; set; }  
    public double Colocacion { get; set; }  
    public double Flotacion { get; set; } 
    public double Cavali { get; set; } 
    
    public UserResource User { get; set; } 

}