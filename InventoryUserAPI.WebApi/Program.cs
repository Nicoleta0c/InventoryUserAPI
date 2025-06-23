using InventoryUserAPI.Application.Interfaces;
using InventoryUserAPI.Application.Interfaces.IProducts;
using InventoryUserAPI.Application.Interfaces.IUsersRoles;
using InventoryUserAPI.Application.Services.ProductsService;
using InventoryUserAPI.Application.Services.UsersService;
using InventoryUserAPI.Infrastructure;
using InventoryUserAPI.Infrastructure.Data;
using InventoryUserAPI.Infrastructure.Identity;
using InventoryUserAPI.Infrastructure.Repositories;
using InventoryUserAPI.Infrastructure.Repositories.ProductsRespositories;
using InventoryUserAPI.Infrastructure.Repositories.UsersRespositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar EF con SQLite para productos
var configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

//DbContext de Identity
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

// Configurar el seeder de roles
builder.Services.AddScoped<RoleSeeder>();

//Identity con usuario y roles
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

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

// Servicios de usuario 
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Agregar Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

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

// Configurar CORS Habilitado 
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Seedear roles al iniciar la aplicacion
using (var scope = app.Services.CreateScope())
{
    var roleSeeder = scope.ServiceProvider.GetRequiredService<RoleSeeder>();
    await roleSeeder.SeedRolesAsync();
}

app.Run();
