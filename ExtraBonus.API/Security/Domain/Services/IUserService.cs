
using ExtraBonus.API.Security.Domain.Models;
using ExtraBonus.API.Security.Domain.Services.Communication;

namespace ExtraBonus.API.Security.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> FindByIdAsync(int id);
    Task<User> FindByEmailAsync(string email);
    Task<User> FindByEmailAndPasswordAsync(string email, string password);
    Task<UserResponse> SaveAsync(User user);
    Task<UserResponse> UpdateAsync(int id, User user);
    Task<UserResponse> DeleteAsync(int id);
}