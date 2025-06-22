using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryUserAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorId = table.Column<int>(type: "INTEGER", nullable: false),
                    PriceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariations_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariations_Price_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rojo" },
                    { 2, "Azul" },
                    { 3, "Verde" },
                    { 4, "Negro" },
                    { 5, "Blanco" },
                    { 6, "Amarillo" },
                    { 7, "Naranja" },
                    { 8, "Rosa" },
                    { 9, "Morado" },
                    { 10, "Gris" },
                    { 11, "Marron" },
                    { 12, "Celeste" },
                    { 13, "Turquesa" },
                    { 14, "Dorado" }
                });

            migrationBuilder.InsertData(
                table: "Price",
                columns: new[] { "Id", "Amount" },
                values: new object[,]
                {
                    { 1, 6200m },
                    { 2, 4500m },
                    { 3, 5300m },
                    { 4, 3800m },
                    { 5, 4100m },
                    { 6, 8400m },
                    { 7, 5250m },
                    { 8, 2600m },
                    { 9, 1700m },
                    { 10, 7350m },
                    { 11, 6550m },
                    { 12, 4450m },
                    { 13, 2650m },
                    { 14, 3750m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Razer", "Mouse gaming ergonomico con sensor optico de alta precision", "https://example.com/images/razer_deathadder_v2.png", "Razer DeathAdder V2" },
                    { 2, "Razer", "Mouse gaming wireless con baja latencia y gran autonomia", "https://example.com/images/razer_deathadder_v2_hyperspeed.png", "Razer DeathAdder V2 Hyperspeed" },
                    { 3, "Razer", "Nuevo mouse con sensor mejorado y diseño ligero", "https://example.com/images/razer_deathadder_v3.png", "Razer DeathAdder V3" },
                    { 4, "Logitech", "Mouse gaming con sensor HERO 25K y 11 botones programables", "https://example.com/images/logitech_g502_hero.png", "Logitech G502 HERO" },
                    { 5, "Logitech", "Mouse ultraligero para competiciones profesionales", "https://example.com/images/logitech_g_pro_x_superlight.png", "Logitech G Pro X Superlight" },
                    { 6, "Fantech", "Mouse gaming con iluminacion RGB y sensor preciso", "https://example.com/images/fantech_x15.png", "Fantech X15" },
                    { 7, "Corsair", "Mouse con sensor optico de 18000 DPI y disenho para diestros", "https://example.com/images/corsair_m65_rgb_elite.png", "Corsair M65 RGB Elite" },
                    { 8, "SteelSeries", "Mouse gaming con sensor TrueMove Core y RGB personalizable", "https://example.com/images/steelseries_rival_3.png", "SteelSeries Rival 3" },
                    { 9, "Logitech", "Mouse ergonimico para productividad y trabajo", "https://example.com/images/logitech_mx_master_3.png", "Logitech MX Master 3" },
                    { 10, "Razer", "Mouse gaming con 8 botones programables y scroll tactil", "https://example.com/images/razer_basilisk_v3.png", "Razer Basilisk V3" },
                    { 11, "HyperX", "Mouse gaming con iluminacion RGB y sensor de alta precision", "https://example.com/images/hyperx_pulsefire_surge.png", "HyperX Pulsefire Surge" },
                    { 12, "ASUS", "Mouse gaming con switches mecanicos y sensor optico avanzado", "https://example.com/images/asus_rog_gladius_iii.png", "ASUS ROG Gladius III" },
                    { 13, "Cooler Master", "Mouse ultraligero con diseño minimalista y sensor optico", "https://example.com/images/cooler_master_mm710.png", "Cooler Master MM710" },
                    { 14, "Glorious", "Mouse ultraligero con estructura honeycomb y RGB", "https://example.com/images/glorious_model_o.png", "Glorious Model O" },
                    { 15, "SteelSeries", "Mouse gaming con sensor TrueMove Pro y alta durabilidad", "https://example.com/images/steelseries_sensei_ten.png", "SteelSeries Sensei Ten" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariations",
                columns: new[] { "Id", "ColorId", "PriceId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 3, 4, 3, 3 },
                    { 4, 5, 4, 4 },
                    { 5, 13, 5, 5 },
                    { 6, 1, 6, 6 },
                    { 7, 2, 7, 7 },
                    { 8, 4, 8, 8 },
                    { 9, 5, 9, 9 },
                    { 10, 13, 10, 10 },
                    { 11, 1, 11, 11 },
                    { 12, 2, 12, 12 },
                    { 13, 4, 13, 13 },
                    { 14, 5, 14, 14 },
                    { 15, 13, 15, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariations_ColorId",
                table: "ProductVariations",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariations_PriceId",
                table: "ProductVariations",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariations_ProductId",
                table: "ProductVariations",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
