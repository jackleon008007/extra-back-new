using ExtraBonus.API.BonusCenter.Domain.Models;

namespace ExtraBonus.API.BonusCenter.Domain.Repositories;

public interface IBondRepository
{
    
    Task<IEnumerable<Bond>> ListAsync();
    Task<IEnumerable<Bond>> ListByUserIdAsync(int userId);
    Task AddAsync(Bond bond);
    Task<Bond> FindByIdAsync(int id);
    void Update(Bond bond);
    void Remove(Bond bond);
}