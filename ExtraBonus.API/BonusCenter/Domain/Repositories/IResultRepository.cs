using ExtraBonus.API.BonusCenter.Domain.Models;

namespace ExtraBonus.API.BonusCenter.Domain.Repositories;

public interface IResultRepository
{
    Task<IEnumerable<Result>> ListAsync();
    Task<IEnumerable<Result>> ListByBondIdAsync(int bondId);
    Task AddAsync(Result result);
    Task<Result> FindByIdAsync(int id);
    void Update(Result result);
    void Remove(Result result);
}