using ExtraBonus.API.BonusCenter.Domain.Models;

namespace ExtraBonus.API.BonusCenter.Domain.Repositories;

public interface IDueRepository
{
     
    Task<IEnumerable<Due>> ListAsync();
    Task<IEnumerable<Due>> ListByBondIdAsync(int bondId);
    Task AddAsync(Due due);
    Task<Due> FindByIdAsync(int id);
    void Update(Due due);
    void Remove(Due due);
}