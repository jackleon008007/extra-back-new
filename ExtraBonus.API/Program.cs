using ExtraBonus.API.BonusCenter.Domain.Repositories;
using ExtraBonus.API.BonusCenter.Domain.Services;
using ExtraBonus.API.BonusCenter.Persistence.Repositories;
using ExtraBonus.API.BonusCenter.Services;
using ExtraBonus.API.Security.Domain.Repositories;
using ExtraBonus.API.Security.Domain.Services;
using ExtraBonus.API.Security.Persistence.Repositories;
using ExtraBonus.API.Shared.Domain.Repositories;
using ExtraBonus.API.Shared.Mapping;
using ExtraBonus.API.Shared.Persistence.Context;
using ExtraBonus.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using SocialMed.API.Security.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen();





var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());


builder.Services.AddRouting(options => options.LowercaseUrls = true);




//////////////////////////////////////////////////////////////

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IBondRepository, BondRepository>();
builder.Services.AddScoped<IBondService, BondService>();

builder.Services.AddScoped<IDueRepository, DueRepository>();
builder.Services.AddScoped<IDueService, DueService>();

builder.Services.AddScoped<IResultRepository, ResultRepository>();
builder.Services.AddScoped<IResultService, ResultService>();





// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile));


var app = builder.Build();



using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();