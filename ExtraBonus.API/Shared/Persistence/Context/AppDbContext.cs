using ExtraBonus.API.Security.Domain.Models;
using ExtraBonus.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;


namespace ExtraBonus.API.Shared.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }


    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p => p.Age).IsRequired();
        builder.Entity<User>().Property(p => p.Image).IsRequired();
        builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(200);
        builder.Entity<User>().Property(p => p.Specialist).IsRequired().HasMaxLength(70);
        builder.Entity<User>().Property(p => p.Recommendation).IsRequired();
        builder.Entity<User>().Property(p => p.WorkPlace).IsRequired();
        builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(80);
        builder.Entity<User>().Property(p => p.Biography).IsRequired();
        
        // Relationships
        /*builder.Entity<User>()
            .HasMany(p => p.Forums)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        builder.Entity<User>()
            .HasMany(p => p.Chats)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        builder.Entity<User>()
            .HasMany(p => p.Comments)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);*/
        
      

        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}