using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Repositories;
using ExtraBonus.API.Shared.Persistence.Context;
using ExtraBonus.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExtraBonus.API.BonusCenter.Persistence.Repositories;

public class DueRepository  : BaseRepository, IDueRepository
{
    public DueRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Due>> ListAsync()
    {
        return await _context.Dues.ToListAsync(); 
    }

    public async Task<IEnumerable<Due>> ListByBondIdAsync(int bondId)
    {
        return await _context.Dues
            .Where(p => p.BondId == bondId)
            .ToListAsync();
    }

    public async Task AddAsync(Due due)
    {
        await _context.Dues.AddAsync(due);
    }

    public async Task<Due> FindByIdAsync(int id)
    {
        return await _context.Dues.FindAsync(id);
    }

    public void Update(Due due)
    {
        _context.Dues.Update(due);
    }

    public void Remove(Due due)
    {
        _context.Dues.Remove(due);
    }
}