using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnionArchitectureWebAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(4592), false, "Limoncuoğlu, Demirbaş and Aşıkoğlu" },
                    { 2, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(4777), false, "Erez and Sons" },
                    { 3, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(4886), false, "Çetin - Doğan " },
                    { 4, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(4993), false, "Atan - Körmükçü" },
                    { 5, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(5147), false, "Yalçın, Arıcan and Aclan" },
                    { 6, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(5251), false, "Ertepınar LLC" },
                    { 7, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(5357), false, "Ayaydın - Yalçın" },
                    { 8, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(5498), false, "Egeli, Bademci and Özberk" },
                    { 9, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(5601), false, "Ertepınar - Kutlay" },
                    { 10, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(5755), false, "Alnıaçık, Beşok and Akay" },
                    { 11, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(6010), true, "Kurutluoğlu, Çatalbaş and Keseroğlu" },
                    { 12, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(6162), true, "Tuğluk, Hakyemez and Çağıran" },
                    { 13, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(6310), true, "Yazıcı, Abadan and Dağlaroğlu" },
                    { 14, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(6416), true, "Köybaşı and Sons" },
                    { 15, new DateTime(2025, 10, 21, 16, 14, 29, 971, DateTimeKind.Local).AddTicks(6527), true, "Günday - Önür" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 21, 16, 14, 29, 972, DateTimeKind.Local).AddTicks(473), false, "Elektrik", 0, 1 },
                    { 2, new DateTime(2025, 10, 21, 16, 14, 29, 972, DateTimeKind.Local).AddTicks(479), false, "Moda", 0, 2 },
                    { 3, new DateTime(2025, 10, 21, 16, 14, 29, 972, DateTimeKind.Local).AddTicks(481), false, "Bilgisayar", 1, 1 },
                    { 4, new DateTime(2025, 10, 21, 16, 14, 29, 972, DateTimeKind.Local).AddTicks(482), false, "kadın", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3070), "Masanın kulu ex koştum voluptate.", false, "Eve." },
                    { 2, 2, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3123), "Voluptatem kulu ki consequatur yaptı.", false, "Minima." },
                    { 3, 1, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3165), "Laudantium sinema değirmeni koşuyorlar ekşili.", false, "Cesurca." },
                    { 4, 3, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3207), "Quia yapacakmış layıkıyla non domates.", false, "Non." },
                    { 5, 2, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3246), "Consequatur lakin sed koyun quis.", false, "Değerli." },
                    { 6, 2, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3287), "İçin aperiam dolayı de odio.", false, "Molestiae." },
                    { 7, 1, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3332), "Vitae rem çorba dicta orta.", false, "Bilgisayarı." },
                    { 8, 2, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3370), "Balıkhaneye cezbelendi sıfat ullam totam.", false, "Voluptatem." },
                    { 9, 1, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3407), "Yazın ve karşıdakine yapacakmış kulu.", false, "Quis." },
                    { 10, 1, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3452), "Koşuyorlar sinema rem iure et.", false, "Açılmadan." },
                    { 11, 1, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3488), "Aperiam kalemi consequatur çünkü bahar.", false, "Masanın." },
                    { 12, 4, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3524), "Biber tempora sıla dergi ut.", false, "Düşünüyor." },
                    { 13, 4, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3562), "Aliquam açılmadan eius ratione ama.", false, "Quia." },
                    { 14, 2, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3599), "Otobüs orta aliquid beatae oldular.", false, "Layıkıyla." },
                    { 15, 4, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3639), "Patlıcan ducimus quaerat ducimus bilgiyasayarı.", false, "Değerli." },
                    { 16, 2, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3672), "Değirmeni reprehenderit sevindi eius ipsam.", false, "Domates." },
                    { 17, 3, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3709), "Makinesi eaque non nisi sokaklarda.", false, "Sarmal." },
                    { 18, 3, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3742), "Un gazete mutlu dolor çakıl.", false, "Sarmal." },
                    { 19, 1, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3778), "Işık quasi magni nesciunt et.", false, "Beğendim." },
                    { 20, 4, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3909), "Numquam commodi salladı oldular explicabo.", false, "Bilgisayarı." },
                    { 21, 2, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3960), "Nisi accusantium in quam açılmadan.", true, "Voluptatem." },
                    { 22, 1, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(3995), "Çakıl kutusu sunt kutusu numquam.", true, "Çakıl." },
                    { 23, 2, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(4028), "Ut kapının göze salladı veniam.", true, "Quis." },
                    { 24, 2, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(4062), "Sıla gülüyorum mıknatıslı gidecekmiş labore.", true, "İure." },
                    { 25, 4, new DateTime(2025, 10, 21, 16, 14, 29, 974, DateTimeKind.Local).AddTicks(4097), "Salladı magnam qui ullam ki.", true, "Consequatur." }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6248), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 222.00m, false, 6447.45m, "Unbranded Granite Salad" },
                    { 2, 5, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6309), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 284.16m, false, 3414.88m, "Fantastic Plastic Towels" },
                    { 3, 5, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6365), "The Football Is Good For Training And Recreational Purposes", 178.03m, false, 2208.81m, "Handcrafted Cotton Hat" },
                    { 4, 10, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6408), "The Football Is Good For Training And Recreational Purposes", 223.58m, false, 803.92m, "Incredible Steel Gloves" },
                    { 5, 6, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6445), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 232.25m, false, 6730.26m, "Practical Cotton Shirt" },
                    { 6, 1, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6487), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 0.02m, false, 5596.47m, "Gorgeous Granite Towels" },
                    { 7, 5, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6528), "The Football Is Good For Training And Recreational Purposes", 210.02m, false, 5676.46m, "Intelligent Metal Chicken" },
                    { 8, 10, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6565), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 167.79m, false, 9756.42m, "Sleek Concrete Pizza" },
                    { 9, 3, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6601), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 57.61m, false, 5423.12m, "Ergonomic Wooden Towels" },
                    { 10, 3, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6641), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 279.35m, false, 3120.59m, "Handcrafted Granite Table" },
                    { 11, 3, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6677), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 257.86m, false, 5361.71m, "Rustic Cotton Car" },
                    { 12, 9, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6726), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 106.72m, false, 8480.22m, "Small Wooden Cheese" },
                    { 13, 10, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6763), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 254.39m, false, 8286.44m, "Incredible Concrete Hat" },
                    { 14, 4, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6799), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 245.08m, false, 8598.08m, "Awesome Cotton Shirt" },
                    { 15, 3, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6837), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 59.40m, false, 6869.77m, "Unbranded Fresh Car" },
                    { 16, 4, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6873), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 93.49m, false, 8569.61m, "Sleek Cotton Salad" },
                    { 17, 2, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6909), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 161.08m, false, 7941.23m, "Small Rubber Shoes" },
                    { 18, 10, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6946), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 115.68m, false, 6150.66m, "Unbranded Plastic Chips" },
                    { 19, 7, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(6982), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 61.53m, false, 5956.66m, "Fantastic Rubber Shirt" },
                    { 20, 4, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7019), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 155.87m, false, 9370.81m, "Ergonomic Plastic Tuna" },
                    { 21, 2, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7070), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 138.83m, false, 5677.67m, "Incredible Fresh Bacon" },
                    { 22, 1, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7107), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 40.42m, false, 8476.50m, "Small Cotton Shoes" },
                    { 23, 9, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7143), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 127.29m, false, 7231.16m, "Intelligent Frozen Tuna" },
                    { 24, 10, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7179), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 79.85m, false, 1322.92m, "Unbranded Steel Keyboard" },
                    { 25, 5, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7215), "The Football Is Good For Training And Recreational Purposes", 165.53m, false, 4765.75m, "Tasty Concrete Gloves" },
                    { 26, 3, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7251), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 205.29m, false, 5948.63m, "Handmade Concrete Chips" },
                    { 27, 4, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7286), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 64.40m, false, 7675.23m, "Awesome Frozen Table" },
                    { 28, 7, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7322), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 128.03m, false, 6923.16m, "Unbranded Granite Fish" },
                    { 29, 1, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7358), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 83.65m, false, 5633.38m, "Ergonomic Metal Cheese" },
                    { 30, 9, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7394), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 98.79m, false, 7519.87m, "Small Soft Pants" },
                    { 31, 5, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7438), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 287.63m, false, 8685.24m, "Rustic Granite Shirt" },
                    { 32, 4, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7474), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 173.12m, false, 5866.39m, "Handcrafted Metal Tuna" },
                    { 33, 3, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7510), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 199.38m, false, 2492.66m, "Rustic Cotton Cheese" },
                    { 34, 9, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7545), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 199.07m, false, 3889.14m, "Handmade Cotton Computer" },
                    { 35, 5, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7582), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 186.48m, false, 8097.51m, "Generic Plastic Chips" },
                    { 36, 5, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7615), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 36.03m, false, 556.20m, "Licensed Rubber Hat" },
                    { 37, 7, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7650), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 251.50m, false, 7780.64m, "Ergonomic Frozen Towels" },
                    { 38, 1, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7685), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 101.09m, false, 5385.25m, "Intelligent Rubber Hat" },
                    { 39, 7, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7720), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 58.15m, false, 2108.10m, "Intelligent Frozen Table" },
                    { 40, 5, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7760), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 33.98m, false, 3604.18m, "Generic Steel Pizza" },
                    { 41, 9, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7794), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 100.99m, false, 4764.48m, "Tasty Plastic Shirt" },
                    { 42, 10, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7828), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 204.54m, false, 8589.72m, "Small Frozen Shoes" },
                    { 43, 8, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7862), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 284.15m, false, 1075.02m, "Rustic Granite Bacon" },
                    { 44, 7, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7895), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 168.36m, false, 3742.22m, "Small Concrete Salad" },
                    { 45, 3, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7930), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 120.88m, false, 8002.25m, "Small Wooden Mouse" },
                    { 46, 8, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7964), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 285.04m, false, 2786.21m, "Fantastic Soft Shoes" },
                    { 47, 2, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(7997), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 177.82m, false, 629.54m, "Handmade Steel Chips" },
                    { 48, 6, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8030), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 133.92m, false, 5215.42m, "Small Granite Car" },
                    { 49, 6, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8072), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 121.99m, false, 3017.52m, "Sleek Concrete Towels" },
                    { 50, 3, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8107), "The Football Is Good For Training And Recreational Purposes", 185.04m, false, 2374.52m, "Practical Plastic Mouse" },
                    { 51, 7, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8156), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 292.79m, true, 2106.73m, "Gorgeous Metal Shoes" },
                    { 52, 6, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8190), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 114.49m, true, 819.03m, "Fantastic Metal Computer" },
                    { 53, 8, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8225), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 5.00m, true, 5109.09m, "Fantastic Soft Pizza" },
                    { 54, 1, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8260), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 62.92m, true, 8319.55m, "Handmade Frozen Bike" },
                    { 55, 2, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8294), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 162.38m, true, 8653.88m, "Fantastic Plastic Ball" },
                    { 56, 3, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8328), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 269.14m, true, 8298.83m, "Handcrafted Plastic Tuna" },
                    { 57, 10, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8361), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 123.14m, true, 8777.50m, "Rustic Metal Towels" },
                    { 58, 8, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8412), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 162.64m, true, 5790.14m, "Awesome Granite Shoes" },
                    { 59, 3, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8446), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 37.92m, true, 1523.31m, "Licensed Steel Computer" },
                    { 60, 6, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8480), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 147.75m, true, 9068.48m, "Intelligent Soft Chair" },
                    { 61, 7, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8514), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 115.13m, true, 5098.61m, "Ergonomic Steel Gloves" },
                    { 62, 1, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8548), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 192.07m, true, 4548.96m, "Sleek Soft Hat" },
                    { 63, 1, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8582), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 53.89m, true, 417.44m, "Intelligent Rubber Sausages" },
                    { 64, 4, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8616), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 10.00m, true, 5181.58m, "Licensed Cotton Gloves" },
                    { 65, 6, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8650), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 210.38m, true, 1815.39m, "Handcrafted Granite Ball" },
                    { 66, 5, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8684), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 121.81m, true, 336.67m, "Handcrafted Fresh Shoes" },
                    { 67, 5, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8719), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 99.47m, true, 4483.32m, "Intelligent Soft Tuna" },
                    { 68, 4, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8761), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 130.60m, true, 9077.86m, "Ergonomic Rubber Towels" },
                    { 69, 2, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8794), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 86.93m, true, 1056.97m, "Tasty Fresh Mouse" },
                    { 70, 5, new DateTime(2025, 10, 21, 16, 14, 29, 976, DateTimeKind.Local).AddTicks(8828), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 20.66m, true, 6155.87m, "Gorgeous Soft Chips" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
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
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
