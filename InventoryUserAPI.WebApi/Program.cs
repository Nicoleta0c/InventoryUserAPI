using InventoryUserAPI.Application.Interfaces;
using InventoryUserAPI.Application.Services;
using InventoryUserAPI.Infrastructure.Data;
using InventoryUserAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar EF con SQLite
var configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));


//patron repositorio generico para inyectar dependencias
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//Patron Unit of Work para manejar transacciones
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//logicas de negocios
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IPriceService, PriceService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductVariationRepository, ProductVariationRepository>();
builder.Services.AddScoped<IProductVariationService, ProductVariationService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
