

using ExtraBonus.API.Security.Domain.Models;
using ExtraBonus.API.Security.Domain.Repositories;
using ExtraBonus.API.Security.Domain.Services;
using ExtraBonus.API.Security.Domain.Services.Communication;
using ExtraBonus.API.Shared.Domain.Repositories;

namespace SocialMed.API.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await  _userRepository.ListAsync();
    }

    public async Task<User> FindByIdAsync(int id)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);
        if (existingUser == null)
        {
            return new User();
        }
        return existingUser;
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        var existingUser = await _userRepository.FindByEmailAsync(email);
        if (existingUser == null)
        {
            return new User();
        }
        return existingUser;
    }

    public async Task<User> FindByEmailAndPasswordAsync(string email, string password)
    {
        return await _userRepository.FindByEmailAndPasswordAsync(email,password);
    }


    public async Task<UserResponse> SaveAsync(User user)
    {
        
        var existingUser = await _userRepository.FindByEmailAsync(user.Email);
        
        
        try
        {
            // Add Tutorial
            await _userRepository.AddAsync(user);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new UserResponse(user);

        }
        catch (Exception e)
        {
            // Error Handling
            return new UserResponse($"An error occurred while saving the new user: {e.Message}");
        }
    }

    public async Task<UserResponse> UpdateAsync(int id, User user)
    {
        
        var existingUser = await _userRepository.FindByIdAsync(id);
        if (existingUser==null)
            return new UserResponse("Invalid User not exist");
        

        // Modify Fields

        existingUser.Name = user.Name;  // revisar que funcione bien- check fields after action update
        existingUser.Email = user.Email;
        existingUser.Ruc = user.Ruc;

        try
        {
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(existingUser);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new UserResponse($"An error occurred while updating the User: {e.Message}");
        }
    }

    public async Task<UserResponse> DeleteAsync(int id)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);
        
        // Validate chat

        if (existingUser== null)
            return new UserResponse("User not found.");
        
        try
        {
            _userRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(existingUser);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new UserResponse($"An error occurred while deleting the User: {e.Message}");
        }
    }
}