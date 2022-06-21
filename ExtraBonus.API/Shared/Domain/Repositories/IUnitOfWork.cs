using System.Threading.Tasks;

namespace ExtraBonus.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}