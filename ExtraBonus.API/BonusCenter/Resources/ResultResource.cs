namespace ExtraBonus.API.BonusCenter.Resources;

public class ResultResource
{
    
    public int Id { get; set; } 

    public int Frecuencia { get; set; }  
    public int Capitalizacion { get; set; }  
    public int Periodo { get; set; } 
    public int TotalPeriodo { get; set; }  
    public double EfectivaAnual { get; set; }  
    public double Efectiva { get; set; } 
    public double Cok { get; set; } 
    public double CostoEmisor { get; set; }  
    public double CostoInversor { get; set; }  
    public double Utilidad { get; set; } 
    public double Duracion { get; set; }  
    public double Convexidad { get; set; } 
    public double Total { get; set; } 
    public double DuracionModif { get; set; } 
    public double Precio { get; set; }
    public double TCEAemisor { get; set; }
    public double TCEAemisorEscudo { get; set; }
    
    public double TREAbonista { get; set; }
    public BondResource Bond { get; set; } 
}