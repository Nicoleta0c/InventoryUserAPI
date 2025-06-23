using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryUserAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming ergonómico con sensor óptico de alta precisión", "https://assets2.razerzone.com/images/pnx.assets/1c57836a4f14a7f9de98886720ef9d1f/razer-deathadder-v2-500x500.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming wireless con baja latencia y gran autonomía", "https://m.media-amazon.com/images/I/51QK8cvx3UL._AC_SL1000_.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://assets2.razerzone.com/images/pnx.assets/2700d2e169f2f26ac2cc121d781f6d52/razer-deathadder-v3-pro-gallery-01.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://resource.logitech.com/content/dam/logitech/en/products/gaming/g502-hero/g502-hero-gallery-1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://resource.logitech.com/w_800,c_limit,q_auto,f_auto,dpr_1.0/d_transparent.gif/content/dam/logitech/en/products/gaming/pro-x-superlight/gallery/pro-x-superlight-gallery-1.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming con iluminación RGB y sensor preciso", "https://fantechworld.com/wp-content/uploads/2021/09/X15-Lee-Sin-01.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse con sensor óptico de 18000 DPI y diseño para diestros", "https://www.corsair.com/medias/sys_master/images/images/hf8/h80/9648556367902/base-m65-rgb-elite-config/Gallery/M65_RGB_Elite_01/-base-m65-rgb-elite-config-Gallery-M65-RGB-Elite-01.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://media.steelseriescdn.com/thumbs/filer_public/44/c6/44c6f824-bfbf-4ab9-90cf-8e0bb579adf2/rival-3-wired-01.png__1850x800_q100_crop-fit_optimize_subsampling-2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse ergonómico para productividad y trabajo", "https://resource.logitech.com/w_800,c_limit,q_auto,f_auto,dpr_1.0/d_transparent.gif/content/dam/logitech/en/products/mice/mx-master-3/gallery/mx-master-3-top.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming con 8 botones programables y scroll táctil", "https://assets2.razerzone.com/images/pnx.assets/b243c6e4b15e4cf3a112d64d5080a0b3/basilisk-v3-500x500.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming con iluminación RGB y sensor de alta precisión", "https://hyperx.com/cdn/shop/products/HyperX_Pulsefire_Surge_Angle_1.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming con switches mecánicos y sensor óptico avanzado", "https://dlcdnwebimgs.asus.com/gain/8c0f8418-4d53-472c-8e93-6b8ed15a2293/" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse ultraligero con diseño minimalista y sensor óptico", "https://www.coolermaster.com/catalog/peripheral/mice/mm710/mm710-kks1/images/MM-710-KKOL1.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://www.pcgamingrace.com/cdn/shop/products/modelo-white_1024x.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://media.steelseriescdn.com/thumbs/catalog/items/62527/2d08cfd60d27403d84e703b8166c8127.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming ergonomico con sensor optico de alta precision", "https://example.com/images/razer_deathadder_v2.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming wireless con baja latencia y gran autonomia", "https://example.com/images/razer_deathadder_v2_hyperspeed.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://example.com/images/razer_deathadder_v3.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://example.com/images/logitech_g502_hero.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://example.com/images/logitech_g_pro_x_superlight.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming con iluminacion RGB y sensor preciso", "https://example.com/images/fantech_x15.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse con sensor optico de 18000 DPI y disenho para diestros", "https://example.com/images/corsair_m65_rgb_elite.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://example.com/images/steelseries_rival_3.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse ergonimico para productividad y trabajo", "https://example.com/images/logitech_mx_master_3.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming con 8 botones programables y scroll tactil", "https://example.com/images/razer_basilisk_v3.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming con iluminacion RGB y sensor de alta precision", "https://example.com/images/hyperx_pulsefire_surge.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse gaming con switches mecanicos y sensor optico avanzado", "https://example.com/images/asus_rog_gladius_iii.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Mouse ultraligero con diseño minimalista y sensor optico", "https://example.com/images/cooler_master_mm710.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://example.com/images/glorious_model_o.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://example.com/images/steelseries_sensei_ten.png");
        }
    }
}
