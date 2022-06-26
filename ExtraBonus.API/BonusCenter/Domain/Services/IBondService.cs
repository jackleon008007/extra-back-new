using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Services.Comunication;

namespace ExtraBonus.API.BonusCenter.Domain.Services;

public interface IBondService
{
    Task<IEnumerable<Bond>> ListAsync();
    Task<IEnumerable<Bond>> ListByUserIdAsync(int userId);
    Task<Bond> FindByIdAsync(int id);
    Task<BondResponse> SaveAsync(Bond bond);
    Task<BondResponse> UpdateAsync(int id, Bond bond);
    Task<BondResponse> DeleteAsync(int id);
}