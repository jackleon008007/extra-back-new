using System.Threading.Tasks;
using ExtraBonus.API.Shared.Domain.Repositories;
using ExtraBonus.API.Shared.Persistence.Context;

namespace ExtraBonus.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}