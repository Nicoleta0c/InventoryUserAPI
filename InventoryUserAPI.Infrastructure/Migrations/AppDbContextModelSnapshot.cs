﻿// <auto-generated />
using InventoryUserAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryUserAPI.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("InventoryUserAPI.Domain.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Color");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rojo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Azul"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Verde"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Negro"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Blanco"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Amarillo"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Naranja"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Rosa"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Morado"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Gris"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Marron"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Celeste"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Turquesa"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Dorado"
                        });
                });

            modelBuilder.Entity("InventoryUserAPI.Domain.Entities.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Price");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 6200m
                        },
                        new
                        {
                            Id = 2,
                            Amount = 4500m
                        },
                        new
                        {
                            Id = 3,
                            Amount = 5300m
                        },
                        new
                        {
                            Id = 4,
                            Amount = 3800m
                        },
                        new
                        {
                            Id = 5,
                            Amount = 4100m
                        },
                        new
                        {
                            Id = 6,
                            Amount = 8400m
                        },
                        new
                        {
                            Id = 7,
                            Amount = 5250m
                        },
                        new
                        {
                            Id = 8,
                            Amount = 2600m
                        },
                        new
                        {
                            Id = 9,
                            Amount = 1700m
                        },
                        new
                        {
                            Id = 10,
                            Amount = 7350m
                        },
                        new
                        {
                            Id = 11,
                            Amount = 6550m
                        },
                        new
                        {
                            Id = 12,
                            Amount = 4450m
                        },
                        new
                        {
                            Id = 13,
                            Amount = 2650m
                        },
                        new
                        {
                            Id = 14,
                            Amount = 3750m
                        });
                });

            modelBuilder.Entity("InventoryUserAPI.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Razer",
                            Description = "Mouse gaming ergonómico con sensor óptico de alta precisión",
                            ImageUrl = "https://assets2.razerzone.com/images/pnx.assets/1c57836a4f14a7f9de98886720ef9d1f/razer-deathadder-v2-500x500.png",
                            Name = "Razer DeathAdder V2"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Razer",
                            Description = "Mouse gaming wireless con baja latencia y gran autonomía",
                            ImageUrl = "https://m.media-amazon.com/images/I/51QK8cvx3UL._AC_SL1000_.jpg",
                            Name = "Razer DeathAdder V2 Hyperspeed"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Razer",
                            Description = "Nuevo mouse con sensor mejorado y diseño ligero",
                            ImageUrl = "https://assets2.razerzone.com/images/pnx.assets/2700d2e169f2f26ac2cc121d781f6d52/razer-deathadder-v3-pro-gallery-01.png",
                            Name = "Razer DeathAdder V3"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Logitech",
                            Description = "Mouse gaming con sensor HERO 25K y 11 botones programables",
                            ImageUrl = "https://resource.logitech.com/content/dam/logitech/en/products/gaming/g502-hero/g502-hero-gallery-1.png",
                            Name = "Logitech G502 HERO"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Logitech",
                            Description = "Mouse ultraligero para competiciones profesionales",
                            ImageUrl = "https://resource.logitech.com/w_800,c_limit,q_auto,f_auto,dpr_1.0/d_transparent.gif/content/dam/logitech/en/products/gaming/pro-x-superlight/gallery/pro-x-superlight-gallery-1.png",
                            Name = "Logitech G Pro X Superlight"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Fantech",
                            Description = "Mouse gaming con iluminación RGB y sensor preciso",
                            ImageUrl = "https://fantechworld.com/wp-content/uploads/2021/09/X15-Lee-Sin-01.png",
                            Name = "Fantech X15"
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Corsair",
                            Description = "Mouse con sensor óptico de 18000 DPI y diseño para diestros",
                            ImageUrl = "https://www.corsair.com/medias/sys_master/images/images/hf8/h80/9648556367902/base-m65-rgb-elite-config/Gallery/M65_RGB_Elite_01/-base-m65-rgb-elite-config-Gallery-M65-RGB-Elite-01.png",
                            Name = "Corsair M65 RGB Elite"
                        },
                        new
                        {
                            Id = 8,
                            Brand = "SteelSeries",
                            Description = "Mouse gaming con sensor TrueMove Core y RGB personalizable",
                            ImageUrl = "https://media.steelseriescdn.com/thumbs/filer_public/44/c6/44c6f824-bfbf-4ab9-90cf-8e0bb579adf2/rival-3-wired-01.png__1850x800_q100_crop-fit_optimize_subsampling-2.png",
                            Name = "SteelSeries Rival 3"
                        },
                        new
                        {
                            Id = 9,
                            Brand = "Logitech",
                            Description = "Mouse ergonómico para productividad y trabajo",
                            ImageUrl = "https://resource.logitech.com/w_800,c_limit,q_auto,f_auto,dpr_1.0/d_transparent.gif/content/dam/logitech/en/products/mice/mx-master-3/gallery/mx-master-3-top.png",
                            Name = "Logitech MX Master 3"
                        },
                        new
                        {
                            Id = 10,
                            Brand = "Razer",
                            Description = "Mouse gaming con 8 botones programables y scroll táctil",
                            ImageUrl = "https://assets2.razerzone.com/images/pnx.assets/b243c6e4b15e4cf3a112d64d5080a0b3/basilisk-v3-500x500.png",
                            Name = "Razer Basilisk V3"
                        },
                        new
                        {
                            Id = 11,
                            Brand = "HyperX",
                            Description = "Mouse gaming con iluminación RGB y sensor de alta precisión",
                            ImageUrl = "https://hyperx.com/cdn/shop/products/HyperX_Pulsefire_Surge_Angle_1.png",
                            Name = "HyperX Pulsefire Surge"
                        },
                        new
                        {
                            Id = 12,
                            Brand = "ASUS",
                            Description = "Mouse gaming con switches mecánicos y sensor óptico avanzado",
                            ImageUrl = "https://dlcdnwebimgs.asus.com/gain/8c0f8418-4d53-472c-8e93-6b8ed15a2293/",
                            Name = "ASUS ROG Gladius III"
                        },
                        new
                        {
                            Id = 13,
                            Brand = "Cooler Master",
                            Description = "Mouse ultraligero con diseño minimalista y sensor óptico",
                            ImageUrl = "https://www.coolermaster.com/catalog/peripheral/mice/mm710/mm710-kks1/images/MM-710-KKOL1.png",
                            Name = "Cooler Master MM710"
                        },
                        new
                        {
                            Id = 14,
                            Brand = "Glorious",
                            Description = "Mouse ultraligero con estructura honeycomb y RGB",
                            ImageUrl = "https://www.pcgamingrace.com/cdn/shop/products/modelo-white_1024x.png",
                            Name = "Glorious Model O"
                        },
                        new
                        {
                            Id = 15,
                            Brand = "SteelSeries",
                            Description = "Mouse gaming con sensor TrueMove Pro y alta durabilidad",
                            ImageUrl = "https://media.steelseriescdn.com/thumbs/catalog/items/62527/2d08cfd60d27403d84e703b8166c8127.png",
                            Name = "SteelSeries Sensei Ten"
                        });
                });

            modelBuilder.Entity("InventoryUserAPI.Domain.Entities.ProductVariation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PriceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("PriceId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVariations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ColorId = 1,
                            PriceId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 3,
                            ColorId = 4,
                            PriceId = 3,
                            ProductId = 3
                        },
                        new
                        {
                            Id = 4,
                            ColorId = 5,
                            PriceId = 4,
                            ProductId = 4
                        },
                        new
                        {
                            Id = 5,
                            ColorId = 13,
                            PriceId = 5,
                            ProductId = 5
                        },
                        new
                        {
                            Id = 6,
                            ColorId = 1,
                            PriceId = 6,
                            ProductId = 6
                        },
                        new
                        {
                            Id = 7,
                            ColorId = 2,
                            PriceId = 7,
                            ProductId = 7
                        },
                        new
                        {
                            Id = 8,
                            ColorId = 4,
                            PriceId = 8,
                            ProductId = 8
                        },
                        new
                        {
                            Id = 9,
                            ColorId = 5,
                            PriceId = 9,
                            ProductId = 9
                        },
                        new
                        {
                            Id = 10,
                            ColorId = 13,
                            PriceId = 10,
                            ProductId = 10
                        },
                        new
                        {
                            Id = 11,
                            ColorId = 1,
                            PriceId = 11,
                            ProductId = 11
                        },
                        new
                        {
                            Id = 12,
                            ColorId = 2,
                            PriceId = 12,
                            ProductId = 12
                        },
                        new
                        {
                            Id = 13,
                            ColorId = 4,
                            PriceId = 13,
                            ProductId = 13
                        },
                        new
                        {
                            Id = 14,
                            ColorId = 5,
                            PriceId = 14,
                            ProductId = 14
                        },
                        new
                        {
                            Id = 15,
                            ColorId = 13,
                            PriceId = 15,
                            ProductId = 15
                        });
                });

            modelBuilder.Entity("InventoryUserAPI.Domain.Entities.ProductVariation", b =>
                {
                    b.HasOne("InventoryUserAPI.Domain.Entities.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryUserAPI.Domain.Entities.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryUserAPI.Domain.Entities.Product", "Product")
                        .WithMany("Variations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Price");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("InventoryUserAPI.Domain.Entities.Product", b =>
                {
                    b.Navigation("Variations");
                });
#pragma warning restore 612, 618
        }
    }
}
