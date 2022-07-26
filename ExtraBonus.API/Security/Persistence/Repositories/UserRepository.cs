﻿using Microsoft.EntityFrameworkCore;
using ExtraBonus.API.Security.Domain.Models;
using ExtraBonus.API.Security.Domain.Repositories;
using ExtraBonus.API.Shared.Persistence.Context;
using ExtraBonus.API.Shared.Persistence.Repositories;



namespace ExtraBonus.API.Security.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync(); 
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> FindByNameAsync(string name)
    {
        return await _context.Users
            .FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(p => p.Email == email);
    }

    public async Task<User> FindByEmailAndPasswordAsync(string email, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(p => p.Email == email && p.Password == password); 
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }
}