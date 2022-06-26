using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.Security.Domain.Models;
using ExtraBonus.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;


namespace ExtraBonus.API.Shared.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Bond> Bonds { get; set; }
    public DbSet<Due> Dues { get; set; }
    public DbSet<Result> Results { get; set; }
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
 
        builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(200);

        builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(80);
        builder.Entity<User>().Property(p => p.Ruc).IsRequired().HasMaxLength(80);

        builder.Entity<User>()
            .HasMany(p => p.Bonds)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
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
        
      /////////////////////////////////////////////
      builder.Entity<Bond>().ToTable("Bonds");
      builder.Entity<Bond>().HasKey(p => p.Id);
      builder.Entity<Bond>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Bond>().Property(p => p.Capitalizacion).IsRequired();
      builder.Entity<Bond>().Property(p => p.Anos).IsRequired();
      builder.Entity<Bond>().Property(p => p.Cavali).IsRequired();
      builder.Entity<Bond>().Property(p => p.Colocacion).IsRequired();
      builder.Entity<Bond>().Property(p => p.Comercial).IsRequired();
      builder.Entity<Bond>().Property(p => p.Descuento).IsRequired();
      builder.Entity<Bond>().Property(p => p.Dias).IsRequired();
      builder.Entity<Bond>().Property(p => p.Estructuracion).IsRequired();
      builder.Entity<Bond>().Property(p => p.Fecha).IsRequired();
      builder.Entity<Bond>().Property(p => p.Flotacion).IsRequired();
      builder.Entity<Bond>().Property(p => p.Frecuencia).IsRequired();
      builder.Entity<Bond>().Property(p => p.Interes).IsRequired();
      builder.Entity<Bond>().Property(p => p.Nominal).IsRequired();
      builder.Entity<Bond>().Property(p => p.Prima).IsRequired();
      builder.Entity<Bond>().Property(p => p.Renta).IsRequired();
      builder.Entity<Bond>().Property(p => p.Tasa).IsRequired();
      builder.Entity<Bond>().Property(p => p.UserId).IsRequired();
      
      builder.Entity<Bond>()
          .HasMany(p => p.Dues)
          .WithOne(p => p.Bond)
          .HasForeignKey(p => p.BondId);
      
      builder.Entity<Bond>()
          .HasOne(p => p.Result)
          .WithOne(p => p.Bond)
          .HasForeignKey<Result>(p => p.BondId);
        // Apply Snake Case Naming Conventio
        
        
        
    /////////////////////////////////////////
    builder.Entity<Due>().ToTable("Dues");
    builder.Entity<Due>().HasKey(p => p.Id);
    builder.Entity<Due>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Due>().Property(p => p.Activo).IsRequired();
    
    builder.Entity<Due>().Property(p => p.Amortizacion).IsRequired();
    builder.Entity<Due>().Property(p => p.Bonista).IsRequired();
    builder.Entity<Due>().Property(p => p.Bono).IsRequired();
    builder.Entity<Due>().Property(p => p.Convexidad).IsRequired();
    builder.Entity<Due>().Property(p => p.Cupon).IsRequired();
    builder.Entity<Due>().Property(p => p.Emisor).IsRequired();
    builder.Entity<Due>().Property(p => p.Escudo).IsRequired();
    builder.Entity<Due>().Property(p => p.Indexado).IsRequired();
    builder.Entity<Due>().Property(p => p.Inflacion).IsRequired();
    builder.Entity<Due>().Property(p => p.Numero).IsRequired();
    builder.Entity<Due>().Property(p => p.Plazo).IsRequired();
    builder.Entity<Due>().Property(p => p.Prima).IsRequired();
    builder.Entity<Due>().Property(p => p.EmisorEscudo).IsRequired();
    builder.Entity<Due>().Property(p => p.InflacionPeriodo).IsRequired();
    builder.Entity<Due>().Property(p => p.BondId).IsRequired();
    
    ////////////////////////////////////////////////////////////////////
    builder.Entity<Result>().ToTable("Results");
    builder.Entity<Result>().HasKey(p => p.Id);
    builder.Entity<Result>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Result>().Property(p => p.Capitalizacion).IsRequired();
    builder.Entity<Result>().Property(p => p.Cok).IsRequired();
    builder.Entity<Result>().Property(p => p.Convexidad).IsRequired();
    builder.Entity<Result>().Property(p => p.Duracion).IsRequired();
    builder.Entity<Result>().Property(p => p.Efectiva).IsRequired();
    builder.Entity<Result>().Property(p => p.Frecuencia).IsRequired();
    builder.Entity<Result>().Property(p => p.Periodo).IsRequired();
    builder.Entity<Result>().Property(p => p.Total).IsRequired();
    builder.Entity<Result>().Property(p => p.Utilidad).IsRequired();
    builder.Entity<Result>().Property(p => p.CostoEmisor).IsRequired();
    builder.Entity<Result>().Property(p => p.CostoInversor).IsRequired();
    builder.Entity<Result>().Property(p => p.DuracionModif).IsRequired();
    builder.Entity<Result>().Property(p => p.EfectivaAnual).IsRequired();
    builder.Entity<Result>().Property(p => p.TotalPeriodo).IsRequired();
    builder.Entity<Result>().Property(p => p.Precio).IsRequired();  
    builder.Entity<Result>().Property(p => p.BondId).IsRequired();
    builder.Entity<Result>().Property(p => p.TCEAemisor).IsRequired();
    builder.Entity<Result>().Property(p => p.TCEAemisorEscudo).IsRequired();
    builder.Entity<Result>().Property(p => p.TREAbonista).IsRequired();
    builder.UseSnakeCaseNamingConvention();
    }
}