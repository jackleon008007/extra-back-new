using ExtraBonus.API.Security.Domain.Models;

namespace ExtraBonus.API.BonusCenter.Domain.Models;

public class Bond
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
    
    public int UserId{ get; set; } 
    public User User{ get; set; } 
    
    public IList<Due> Dues { get; set; } = new List<Due>();
    
    public Result Result { get; set; }

}