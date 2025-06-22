using InventoryUserAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryUserAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariation> ProductVariations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relaciones uno a mucho

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Variations)
                .WithOne(v => v.Product)
                .HasForeignKey(v => v.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductVariation>()
                .HasOne(pv => pv.Color)
                .WithMany()
                .HasForeignKey(pv => pv.ColorId);


            //subiendo datos para pruebas

            modelBuilder.Entity<Color>().HasData(
                 new Color { Id = 1, Name = "Rojo" },
                 new Color { Id = 2, Name = "Azul" },
                 new Color { Id = 3, Name = "Verde" },
                 new Color { Id = 4, Name = "Negro" },
                 new Color { Id = 5, Name = "Blanco" },
                 new Color { Id = 6, Name = "Amarillo" },
                 new Color { Id = 7, Name = "Naranja" },
                 new Color { Id = 8, Name = "Rosa" },
                 new Color { Id = 9, Name = "Morado" },
                 new Color { Id = 10, Name = "Gris" },
                 new Color { Id = 11, Name = "Marron" },
                 new Color { Id = 12, Name = "Celeste" },
                 new Color { Id = 13, Name = "Turquesa" },
                 new Color { Id = 14, Name = "Dorado" }
                 );



            modelBuilder.Entity<Price>().HasData(
                new Price { Id = 1, Amount = 6200m },
                new Price { Id = 2, Amount = 4500m },
                new Price { Id = 3, Amount = 5300m },
                new Price { Id = 4, Amount = 3800m },
                new Price { Id = 5, Amount = 4100m },
                new Price { Id = 6, Amount = 8400m },
                new Price { Id = 7, Amount = 5250m },
                new Price { Id = 8, Amount = 2600m },
                new Price { Id = 9, Amount = 1700m },
                new Price { Id = 10, Amount = 7350m },
                new Price { Id = 11, Amount = 6550m },
                new Price { Id = 12, Amount = 4450m },
                new Price { Id = 13, Amount = 2650m },
                new Price { Id = 14, Amount = 3750m }
            );


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Razer DeathAdder V2", Description = "Mouse gaming ergonomico con sensor optico de alta precision", ImageUrl = "https://example.com/images/razer_deathadder_v2.png", Brand = "Razer" },
                new Product { Id = 2, Name = "Razer DeathAdder V2 Hyperspeed", Description = "Mouse gaming wireless con baja latencia y gran autonomia", ImageUrl = "https://example.com/images/razer_deathadder_v2_hyperspeed.png", Brand = "Razer" },
                new Product { Id = 3, Name = "Razer DeathAdder V3", Description = "Nuevo mouse con sensor mejorado y diseño ligero", ImageUrl = "https://example.com/images/razer_deathadder_v3.png", Brand = "Razer" },
                new Product { Id = 4, Name = "Logitech G502 HERO", Description = "Mouse gaming con sensor HERO 25K y 11 botones programables", ImageUrl = "https://example.com/images/logitech_g502_hero.png", Brand = "Logitech" },
                new Product { Id = 5, Name = "Logitech G Pro X Superlight", Description = "Mouse ultraligero para competiciones profesionales", ImageUrl = "https://example.com/images/logitech_g_pro_x_superlight.png", Brand = "Logitech" },
                new Product { Id = 6, Name = "Fantech X15", Description = "Mouse gaming con iluminacion RGB y sensor preciso", ImageUrl = "https://example.com/images/fantech_x15.png", Brand = "Fantech" },
                new Product { Id = 7, Name = "Corsair M65 RGB Elite", Description = "Mouse con sensor optico de 18000 DPI y disenho para diestros", ImageUrl = "https://example.com/images/corsair_m65_rgb_elite.png", Brand = "Corsair" },
                new Product { Id = 8, Name = "SteelSeries Rival 3", Description = "Mouse gaming con sensor TrueMove Core y RGB personalizable", ImageUrl = "https://example.com/images/steelseries_rival_3.png", Brand = "SteelSeries" },
                new Product { Id = 9, Name = "Logitech MX Master 3", Description = "Mouse ergonimico para productividad y trabajo", ImageUrl = "https://example.com/images/logitech_mx_master_3.png", Brand = "Logitech" },
                new Product { Id = 10, Name = "Razer Basilisk V3", Description = "Mouse gaming con 8 botones programables y scroll tactil", ImageUrl = "https://example.com/images/razer_basilisk_v3.png", Brand = "Razer" },
                new Product { Id = 11, Name = "HyperX Pulsefire Surge", Description = "Mouse gaming con iluminacion RGB y sensor de alta precision", ImageUrl = "https://example.com/images/hyperx_pulsefire_surge.png", Brand = "HyperX" },
                new Product { Id = 12, Name = "ASUS ROG Gladius III", Description = "Mouse gaming con switches mecanicos y sensor optico avanzado", ImageUrl = "https://example.com/images/asus_rog_gladius_iii.png", Brand = "ASUS" },
                new Product { Id = 13, Name = "Cooler Master MM710", Description = "Mouse ultraligero con diseño minimalista y sensor optico", ImageUrl = "https://example.com/images/cooler_master_mm710.png", Brand = "Cooler Master" },
                new Product { Id = 14, Name = "Glorious Model O", Description = "Mouse ultraligero con estructura honeycomb y RGB", ImageUrl = "https://example.com/images/glorious_model_o.png", Brand = "Glorious" },
                new Product { Id = 15, Name = "SteelSeries Sensei Ten", Description = "Mouse gaming con sensor TrueMove Pro y alta durabilidad", ImageUrl = "https://example.com/images/steelseries_sensei_ten.png", Brand = "SteelSeries" }
            );

            modelBuilder.Entity<ProductVariation>().HasData(
               new ProductVariation { Id = 1, ProductId = 1, ColorId = 1, PriceId = 1 },
               new ProductVariation { Id = 3, ProductId = 3, ColorId = 4, PriceId = 3 },  
               new ProductVariation { Id = 4, ProductId = 4, ColorId = 5, PriceId = 4 },   
               new ProductVariation { Id = 5, ProductId = 5, ColorId = 13, PriceId = 5 },  
               new ProductVariation { Id = 6, ProductId = 6, ColorId = 1, PriceId = 6 },   
               new ProductVariation { Id = 7, ProductId = 7, ColorId = 2, PriceId = 7 },  
               new ProductVariation { Id = 8, ProductId = 8, ColorId = 4, PriceId = 8 },  
               new ProductVariation { Id = 9, ProductId = 9, ColorId = 5, PriceId = 9 },   
               new ProductVariation { Id = 10, ProductId = 10, ColorId = 13, PriceId = 10 }, 
               new ProductVariation { Id = 11, ProductId = 11, ColorId = 1, PriceId = 11 },  
               new ProductVariation { Id = 12, ProductId = 12, ColorId = 2, PriceId = 12 },  
               new ProductVariation { Id = 13, ProductId = 13, ColorId = 4, PriceId = 13 },  
               new ProductVariation { Id = 14, ProductId = 14, ColorId = 5, PriceId = 14 },  
               new ProductVariation { Id = 15, ProductId = 15, ColorId = 13, PriceId = 15 } 
             );


        }
    }
}
