using ExtraBonus.API.Security.Domain.Models;

namespace ExtraBonus.API.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    Task<User> FindByNameAsync(string name);
    Task<User> FindByEmailAsync(string email);
    Task<User> FindByEmailAndPasswordAsync(string email, string password);
    void Update(User user);
    void Remove(User user);
}