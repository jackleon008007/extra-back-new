using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Services.Comunication;

namespace ExtraBonus.API.BonusCenter.Domain.Services;

public interface IDueService
{
    Task<IEnumerable<Due>> ListAsync();
    Task<IEnumerable<Due>> ListByBondIdAsync(int bondId);
    Task<Due> FindByIdAsync(int id);
    Task<DueResponse> SaveAsync(Due due);
    Task<DueResponse> UpdateAsync(int id, Due due);
    Task<DueResponse> DeleteAsync(int id);
}