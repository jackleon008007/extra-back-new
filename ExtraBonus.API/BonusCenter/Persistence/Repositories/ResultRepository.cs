using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Repositories;
using ExtraBonus.API.Shared.Persistence.Context;
using ExtraBonus.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExtraBonus.API.BonusCenter.Persistence.Repositories;

public class ResultRepository  : BaseRepository, IResultRepository
{
    public ResultRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Result>> ListAsync()
    {
        return await _context.Results.ToListAsync(); 
    }

    public async Task<IEnumerable<Result>> ListByBondIdAsync(int bondId)
    {
        return await _context.Results
            .Where(p => p.BondId == bondId)
            .ToListAsync();
    }

    public async Task AddAsync(Result result)
    {
        await _context.Results.AddAsync(result);
    }

    public async Task<Result> FindByIdAsync(int id)
    {
        return await _context.Results.FindAsync(id);
    }

    public void Update(Result result)
    {
        _context.Results.Update(result);
    }

    public void Remove(Result result)
    {
        _context.Results.Remove(result);
    }
}