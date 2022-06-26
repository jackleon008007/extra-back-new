using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Services.Comunication;

namespace ExtraBonus.API.BonusCenter.Domain.Services;

public interface IResultService
{
    
    Task<IEnumerable<Result>> ListAsync();
    Task<IEnumerable<Result>> ListByBondIdAsync(int bondId);
    Task<Result> FindByIdAsync(int id);
    Task<ResultResponse> SaveAsync(Result result);
    Task<ResultResponse> UpdateAsync(int id, Result result);
    Task<ResultResponse> DeleteAsync(int id);
}