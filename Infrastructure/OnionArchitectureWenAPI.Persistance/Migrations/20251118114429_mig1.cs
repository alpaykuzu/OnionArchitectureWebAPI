using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnionArchitectureWebAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Priorty = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7221), false, "Özdoğan, Koçoğlu and Paksüt" },
                    { 2, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7360), false, "Akan Group" },
                    { 3, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7447), false, "Çağıran and Sons" },
                    { 4, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7534), false, "Akyürek Inc" },
                    { 5, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7660), false, "Oraloğlu, Kasapoğlu and Topaloğlu" },
                    { 6, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7734), false, "Kıraç  - Tütüncü" },
                    { 7, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7821), false, "Karabulut LLC" },
                    { 8, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7899), false, "Yetkiner - Atan" },
                    { 9, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8017), false, "Öymen, Koyuncu and Sezek" },
                    { 10, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8094), false, "Bakırcıoğlu and Sons" },
                    { 11, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8240), true, "Koçyiğit Group" },
                    { 12, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8392), true, "Erginsoy, Solmaz and Alpuğan" },
                    { 13, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8479), true, "Okur and Sons" },
                    { 14, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8561), true, "Ekici LLC" },
                    { 15, new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8645), true, "Numanoğlu - Sandalcı" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 18, 14, 44, 28, 694, DateTimeKind.Local).AddTicks(2158), false, "Elektrik", 0, 1 },
                    { 2, new DateTime(2025, 11, 18, 14, 44, 28, 694, DateTimeKind.Local).AddTicks(2164), false, "Moda", 0, 2 },
                    { 3, new DateTime(2025, 11, 18, 14, 44, 28, 694, DateTimeKind.Local).AddTicks(2165), false, "Bilgisayar", 1, 1 },
                    { 4, new DateTime(2025, 11, 18, 14, 44, 28, 694, DateTimeKind.Local).AddTicks(2166), false, "Kadın", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(23), "Aliquam beğendim masanın doğru alias.", false, "Koşuyorlar." },
                    { 2, 3, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(73), "Eos sit yazın eum alias.", false, "Aut." },
                    { 3, 3, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(108), "Nihil amet orta göze nihil.", false, "Değirmeni." },
                    { 4, 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(141), "Adresini cesurca tempora consequuntur qui.", false, "Eve." },
                    { 5, 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(171), "Eve düşünüyor kulu aut biber.", false, "Odio." },
                    { 6, 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(213), "Autem lakin velit quia layıkıyla.", false, "Quis." },
                    { 7, 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(246), "Voluptatem quia qui ekşili voluptas.", false, "Ex." },
                    { 8, 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(275), "Çakıl dolor ekşili ipsa de.", false, "Numquam." },
                    { 9, 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(305), "Gitti balıkhaneye teldeki qui aut.", false, "Tv." },
                    { 10, 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(336), "Mi enim ekşili doloremque ut.", false, "Autem." },
                    { 11, 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(367), "Quam tempora quasi eos teldeki.", false, "Velit." },
                    { 12, 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(398), "Sunt quia öyle sıla perferendis.", false, "İçin." },
                    { 13, 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(432), "Sit dolorem enim sunt sokaklarda.", false, "Architecto." },
                    { 14, 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(465), "Ut kalemi vitae quasi sevindi.", false, "Totam." },
                    { 15, 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(494), "Nisi beğendim reprehenderit iusto dolorem.", false, "İpsa." },
                    { 16, 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(521), "Masanın nisi qui quasi ea.", false, "Değerli." },
                    { 17, 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(789), "Amet exercitationem voluptatem autem kapının.", false, "Çobanın." },
                    { 18, 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(819), "İçin ipsum sequi sayfası ipsa.", false, "Aliquid." },
                    { 19, 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(846), "Sokaklarda layıkıyla sequi accusantium aut.", false, "Quia." },
                    { 20, 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(873), "Ama cesurca ex sed exercitationem.", false, "Anlamsız." },
                    { 21, 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(916), "Eve çarpan gazete consequatur umut.", true, "Filmini." },
                    { 22, 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(943), "Nisi koşuyorlar kulu cesurca enim.", true, "Ut." },
                    { 23, 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(971), "Adipisci cesurca aperiam eaque doloremque.", true, "Ullam." },
                    { 24, 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(999), "Değerli ullam telefonu tv ve.", true, "Quae." },
                    { 25, 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(1027), "Veritatis gül kalemi biber oldular.", true, "Quia." }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 9, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9199), "The Football Is Good For Training And Recreational Purposes", 18.08m, false, 6598.73m, "Handmade Plastic Shoes" },
                    { 2, 8, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9257), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 45.56m, false, 6408.13m, "Practical Fresh Shirt" },
                    { 3, 6, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9291), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 34.70m, false, 8987.84m, "Small Metal Hat" },
                    { 4, 8, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9324), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 4.05m, false, 9167.87m, "Small Frozen Keyboard" },
                    { 5, 2, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9354), "The Football Is Good For Training And Recreational Purposes", 26.71m, false, 9230.04m, "Rustic Metal Keyboard" },
                    { 6, 8, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9393), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 25.43m, false, 1708.80m, "Rustic Metal Ball" },
                    { 7, 1, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9428), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 16.83m, false, 3075.47m, "Refined Metal Mouse" },
                    { 8, 2, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9457), "The Football Is Good For Training And Recreational Purposes", 11.35m, false, 3692.80m, "Sleek Cotton Towels" },
                    { 9, 3, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9485), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 48.27m, false, 4613.38m, "Gorgeous Wooden Keyboard" },
                    { 10, 10, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9517), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 25.03m, false, 3959.07m, "Incredible Cotton Sausages" },
                    { 11, 3, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9548), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 22.25m, false, 3391.63m, "Tasty Rubber Bike" },
                    { 12, 7, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9577), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 10.33m, false, 3620.59m, "Fantastic Frozen Tuna" },
                    { 13, 1, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9605), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 43.64m, false, 4187.19m, "Tasty Concrete Pizza" },
                    { 14, 3, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9634), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 18.59m, false, 8794.50m, "Unbranded Metal Fish" },
                    { 15, 9, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9670), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 48.93m, false, 8920.56m, "Incredible Metal Table" },
                    { 16, 10, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9697), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 46.81m, false, 9639.73m, "Sleek Steel Chair" },
                    { 17, 8, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9727), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 24.16m, false, 6005.93m, "Generic Granite Keyboard" },
                    { 18, 9, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9754), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 10.30m, false, 5117.98m, "Sleek Metal Shirt" },
                    { 19, 6, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9783), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 44.70m, false, 6872.43m, "Sleek Frozen Computer" },
                    { 20, 5, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9811), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 22.37m, false, 7871.19m, "Incredible Frozen Mouse" },
                    { 21, 9, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9839), "The Football Is Good For Training And Recreational Purposes", 10.19m, false, 3881.20m, "Handcrafted Metal Ball" },
                    { 22, 10, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9868), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 39.36m, false, 5017.54m, "Licensed Wooden Salad" },
                    { 23, 5, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9896), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 6.40m, false, 9050.48m, "Handcrafted Plastic Bacon" },
                    { 24, 10, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9932), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 45.06m, false, 8076.71m, "Incredible Metal Chips" },
                    { 25, 10, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9961), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 9.30m, false, 6742.50m, "Handcrafted Metal Fish" },
                    { 26, 5, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9988), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 35.09m, false, 4657.79m, "Practical Fresh Keyboard" },
                    { 27, 5, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(17), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 4.81m, false, 898.56m, "Handcrafted Cotton Towels" },
                    { 28, 8, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(45), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 29.80m, false, 2512.37m, "Sleek Wooden Pizza" },
                    { 29, 6, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(72), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 39.84m, false, 1604.97m, "Tasty Wooden Chair" },
                    { 30, 5, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(100), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 13.46m, false, 5983.61m, "Rustic Steel Keyboard" },
                    { 31, 2, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(129), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 0.49m, false, 677.84m, "Ergonomic Wooden Cheese" },
                    { 32, 4, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(157), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 1.73m, false, 1468.68m, "Fantastic Fresh Pants" },
                    { 33, 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(184), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 31.77m, false, 3949.97m, "Handmade Plastic Computer" },
                    { 34, 5, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(219), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 35.65m, false, 9180.43m, "Licensed Frozen Chicken" },
                    { 35, 8, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(247), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 41.69m, false, 3907.91m, "Fantastic Rubber Tuna" },
                    { 36, 6, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(276), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 0.64m, false, 6369.27m, "Intelligent Soft Pants" },
                    { 37, 8, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(305), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 35.12m, false, 8552.24m, "Rustic Fresh Ball" },
                    { 38, 9, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(333), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 12.72m, false, 7627.42m, "Small Soft Ball" },
                    { 39, 3, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(361), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 29.31m, false, 9247.58m, "Handmade Granite Chicken" },
                    { 40, 4, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(388), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 42.39m, false, 5051.78m, "Gorgeous Concrete Computer" },
                    { 41, 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(417), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 42.48m, false, 1008.33m, "Unbranded Fresh Soap" },
                    { 42, 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(445), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 43.43m, false, 271.38m, "Unbranded Granite Bacon" },
                    { 43, 6, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(481), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 38.88m, false, 5670.27m, "Ergonomic Wooden Chips" },
                    { 44, 4, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(509), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 40.40m, false, 3487.04m, "Handcrafted Fresh Mouse" },
                    { 45, 2, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(538), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 13.23m, false, 6049.23m, "Unbranded Steel Car" },
                    { 46, 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(566), "The Football Is Good For Training And Recreational Purposes", 3.17m, false, 2318.35m, "Unbranded Metal Shirt" },
                    { 47, 9, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(595), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 41.50m, false, 159.51m, "Ergonomic Metal Bacon" },
                    { 48, 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(623), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 29.99m, false, 4128.22m, "Awesome Soft Hat" },
                    { 49, 3, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(651), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 7.36m, false, 6469.08m, "Incredible Metal Table" },
                    { 50, 2, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(678), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 34.64m, false, 9914.63m, "Small Frozen Chicken" },
                    { 51, 6, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(716), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 11.74m, true, 3701.64m, "Practical Cotton Hat" },
                    { 52, 1, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(752), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 18.41m, true, 7072.32m, "Fantastic Rubber Mouse" },
                    { 53, 1, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(781), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 0.57m, true, 9888.97m, "Rustic Concrete Salad" },
                    { 54, 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(809), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 9.70m, true, 7499.12m, "Ergonomic Steel Chicken" },
                    { 55, 5, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(838), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 18.41m, true, 9004.66m, "Fantastic Wooden Mouse" },
                    { 56, 3, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(865), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 26.75m, true, 6155.31m, "Sleek Frozen Salad" },
                    { 57, 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(893), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 26.61m, true, 2744.71m, "Generic Plastic Chips" },
                    { 58, 1, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(922), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 13.27m, true, 8291.17m, "Ergonomic Wooden Car" },
                    { 59, 9, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(950), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 7.49m, true, 1980.75m, "Generic Wooden Towels" },
                    { 60, 8, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(979), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 0.76m, true, 7987.58m, "Handcrafted Plastic Shoes" },
                    { 61, 3, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1015), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 3.09m, true, 5234.82m, "Handcrafted Wooden Shirt" },
                    { 62, 1, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1043), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 11.49m, true, 4402.01m, "Licensed Plastic Gloves" },
                    { 63, 5, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1070), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 18.24m, true, 2359.64m, "Intelligent Fresh Table" },
                    { 64, 7, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1098), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 23.23m, true, 8980.05m, "Licensed Steel Shoes" },
                    { 65, 3, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1126), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 37.58m, true, 729.88m, "Handcrafted Granite Towels" },
                    { 66, 6, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1154), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 34.27m, true, 3134.66m, "Licensed Frozen Soap" },
                    { 67, 7, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1182), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 30.28m, true, 4256.34m, "Handmade Steel Towels" },
                    { 68, 8, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1210), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 14.25m, true, 2700.21m, "Generic Plastic Ball" },
                    { 69, 8, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1238), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 0.97m, true, 8278.81m, "Refined Wooden Chair" },
                    { 70, 7, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1274), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 27.06m, true, 6222.05m, "Rustic Wooden Chicken" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
