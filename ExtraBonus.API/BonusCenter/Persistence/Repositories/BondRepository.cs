using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Repositories;
using ExtraBonus.API.Shared.Persistence.Context;
using ExtraBonus.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExtraBonus.API.BonusCenter.Persistence.Repositories;

public class BondRepository  : BaseRepository, IBondRepository
{
    public BondRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Bond>> ListAsync()
    {
        return await _context.Bonds.Include(p => p.User).ToListAsync(); 
    }

    public async Task<IEnumerable<Bond>> ListByUserIdAsync(int userId)
    {
        return await _context.Bonds
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(Bond bond)
    {
        await _context.Bonds.AddAsync(bond);
    }

    public async Task<Bond> FindByIdAsync(int id)
    {
        return await _context.Bonds.FindAsync(id);
    }

    public void Update(Bond bond)
    {
        _context.Bonds.Update(bond);
    }

    public void Remove(Bond bond)
    {
        _context.Bonds.Remove(bond);
    }
}