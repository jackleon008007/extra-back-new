
using ExtraBonus.API.BonusCenter.Domain.Models;

namespace ExtraBonus.API.Security.Domain.Models;

public class User
{ 
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string Ruc { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public IList<Bond> Bonds { get; set; } = new List<Bond>();
}