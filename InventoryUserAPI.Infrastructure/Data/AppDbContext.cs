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
                 new Product { Id = 1, Name = "Razer DeathAdder V2", Description = "Mouse gaming ergonómico con sensor óptico de alta precisión", ImageUrl = "https://assets2.razerzone.com/images/pnx.assets/1c57836a4f14a7f9de98886720ef9d1f/razer-deathadder-v2-500x500.png", Brand = "Razer" },
                 new Product { Id = 2, Name = "Razer DeathAdder V2 Hyperspeed", Description = "Mouse gaming wireless con baja latencia y gran autonomía", ImageUrl = "https://m.media-amazon.com/images/I/51QK8cvx3UL._AC_SL1000_.jpg", Brand = "Razer" },
                 new Product { Id = 3, Name = "Razer DeathAdder V3", Description = "Nuevo mouse con sensor mejorado y diseño ligero", ImageUrl = "https://assets2.razerzone.com/images/pnx.assets/2700d2e169f2f26ac2cc121d781f6d52/razer-deathadder-v3-pro-gallery-01.png", Brand = "Razer" },
                 new Product { Id = 4, Name = "Logitech G502 HERO", Description = "Mouse gaming con sensor HERO 25K y 11 botones programables", ImageUrl = "https://resource.logitech.com/content/dam/logitech/en/products/gaming/g502-hero/g502-hero-gallery-1.png", Brand = "Logitech" },
                 new Product { Id = 5, Name = "Logitech G Pro X Superlight", Description = "Mouse ultraligero para competiciones profesionales", ImageUrl = "https://resource.logitech.com/w_800,c_limit,q_auto,f_auto,dpr_1.0/d_transparent.gif/content/dam/logitech/en/products/gaming/pro-x-superlight/gallery/pro-x-superlight-gallery-1.png", Brand = "Logitech" },
                 new Product { Id = 6, Name = "Fantech X15", Description = "Mouse gaming con iluminación RGB y sensor preciso", ImageUrl = "https://fantechworld.com/wp-content/uploads/2021/09/X15-Lee-Sin-01.png", Brand = "Fantech" },
                 new Product { Id = 7, Name = "Corsair M65 RGB Elite", Description = "Mouse con sensor óptico de 18000 DPI y diseño para diestros", ImageUrl = "https://www.corsair.com/medias/sys_master/images/images/hf8/h80/9648556367902/base-m65-rgb-elite-config/Gallery/M65_RGB_Elite_01/-base-m65-rgb-elite-config-Gallery-M65-RGB-Elite-01.png", Brand = "Corsair" },
                 new Product { Id = 8, Name = "SteelSeries Rival 3", Description = "Mouse gaming con sensor TrueMove Core y RGB personalizable", ImageUrl = "https://media.steelseriescdn.com/thumbs/filer_public/44/c6/44c6f824-bfbf-4ab9-90cf-8e0bb579adf2/rival-3-wired-01.png__1850x800_q100_crop-fit_optimize_subsampling-2.png", Brand = "SteelSeries" },
                 new Product { Id = 9, Name = "Logitech MX Master 3", Description = "Mouse ergonómico para productividad y trabajo", ImageUrl = "https://resource.logitech.com/w_800,c_limit,q_auto,f_auto,dpr_1.0/d_transparent.gif/content/dam/logitech/en/products/mice/mx-master-3/gallery/mx-master-3-top.png", Brand = "Logitech" },
                 new Product { Id = 10, Name = "Razer Basilisk V3", Description = "Mouse gaming con 8 botones programables y scroll táctil", ImageUrl = "https://assets2.razerzone.com/images/pnx.assets/b243c6e4b15e4cf3a112d64d5080a0b3/basilisk-v3-500x500.png", Brand = "Razer" },
                 new Product { Id = 11, Name = "HyperX Pulsefire Surge", Description = "Mouse gaming con iluminación RGB y sensor de alta precisión", ImageUrl = "https://hyperx.com/cdn/shop/products/HyperX_Pulsefire_Surge_Angle_1.png", Brand = "HyperX" },
                 new Product { Id = 12, Name = "ASUS ROG Gladius III", Description = "Mouse gaming con switches mecánicos y sensor óptico avanzado", ImageUrl = "https://dlcdnwebimgs.asus.com/gain/8c0f8418-4d53-472c-8e93-6b8ed15a2293/", Brand = "ASUS" },
                 new Product { Id = 13, Name = "Cooler Master MM710", Description = "Mouse ultraligero con diseño minimalista y sensor óptico", ImageUrl = "https://www.coolermaster.com/catalog/peripheral/mice/mm710/mm710-kks1/images/MM-710-KKOL1.png", Brand = "Cooler Master" },
                 new Product { Id = 14, Name = "Glorious Model O", Description = "Mouse ultraligero con estructura honeycomb y RGB", ImageUrl = "https://www.pcgamingrace.com/cdn/shop/products/modelo-white_1024x.png", Brand = "Glorious" },
                 new Product { Id = 15, Name = "SteelSeries Sensei Ten", Description = "Mouse gaming con sensor TrueMove Pro y alta durabilidad", ImageUrl = "https://media.steelseriescdn.com/thumbs/catalog/items/62527/2d08cfd60d27403d84e703b8166c8127.png", Brand = "SteelSeries" }
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
