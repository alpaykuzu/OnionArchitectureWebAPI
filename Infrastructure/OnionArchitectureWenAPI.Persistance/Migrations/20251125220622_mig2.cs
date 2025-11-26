using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArchitectureWebAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpireTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(7444), "Egeli - Arslanoğlu" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(7622), "Evliyaoğlu and Sons" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(7727), "Avan Inc" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(7833), "Menemencioğlu Inc" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(7921), "Akan Group" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(8018), "Kulaksızoğlu Inc" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(8107), "Kumcuoğlu - Nalbantoğlu" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(8198), "Uluhan - Eronat" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(8280), "Akan - Arslanoğlu" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(8379), "Atakol LLC" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(8521), "Okumuş, Erbay and Koç" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(8657), "Gönültaş, Kılıççı and Akar " });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(8793), "Çevik, Aybar and Balaban" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(8878), "Babaoğlu - Polat" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 516, DateTimeKind.Local).AddTicks(8970), "Yeşilkaya - Özkara" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 26, 1, 6, 21, 517, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 26, 1, 6, 21, 517, DateTimeKind.Local).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 26, 1, 6, 21, 517, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 26, 1, 6, 21, 517, DateTimeKind.Local).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3177), "Voluptate inventore ut gidecekmiş ut.", "Dağılımı." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3263), "İncidunt sarmal qui iusto praesentium.", "Bahar." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3335), "Göze masanın eos türemiş değerli.", "Salladı." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3411), "Kapının quis non oldular cesurca.", "De." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3474), "Voluptatem bundan voluptas incidunt ve.", "Ea." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3532), "Velit öyle rem olduğu suscipit.", "Orta." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3593), "Dergi de adipisci qui çünkü.", "Ea." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3655), "Ötekinden okuma layıkıyla yapacakmış laudantium.", "Eos." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3717), "Çıktılar aperiam un göze dicta.", "Dağılımı." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3775), "Ona odit umut consequatur rem.", "Telefonu." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3849), "Voluptatem düşünüyor çakıl eos reprehenderit.", "Magnam." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3906), "Sit ona adipisci voluptas architecto.", "Çıktılar." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(3964), "Ötekinden dolore beğendim sıla qui.", "Adresini." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(4025), "Gazete fugit mi odio düşünüyor.", "Kalemi." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CategoryId", "CreatedDate", "Description" },
                values: new object[] { 4, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(4087), "Ab sunt qui koyun ab." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(4142), "Bilgiyasayarı umut olduğu camisi et.", "İllo." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(4199), "Gördüm çakıl dignissimos cesurca ona.", "Ex." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(4688), "Sunt quis magnam illo totam.", "Masanın." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(4756), "Aut dışarı sokaklarda dağılımı et.", "Çıktılar." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(4812), "Dışarı ışık sıfat nesciunt sokaklarda.", "Architecto." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(4880), "Salladı quae autem ea eos.", "Açılmadan." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(4943), "Consequatur oldular ea architecto dergi.", "Qui." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(5007), "Orta beatae vel rem quia.", "Ad." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(5061), "Masanın voluptas inventore exercitationem ut.", "Velit." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 520, DateTimeKind.Local).AddTicks(5103), "Quis kulu gördüm mutlu uzattı.", "Voluptatem." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1129), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 13.27m, 5033.13m, "Tasty Fresh Bacon" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1188), "The Football Is Good For Training And Recreational Purposes", 16.07m, 8876.45m, "Unbranded Concrete Fish" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1240), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 38.85m, 5662.97m, "Gorgeous Wooden Bike" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1277), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 15.33m, 3700.08m, "Handcrafted Concrete Cheese" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1313), 8.74m, 3228.39m, "Fantastic Cotton Computer" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1348), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 28.47m, 8578.14m, "Intelligent Granite Bike" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1384), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 46.99m, 9081.34m, "Incredible Cotton Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1421), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 3.58m, 6068.32m, "Fantastic Wooden Tuna" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1456), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 2.29m, 4151.16m, "Small Frozen Bike" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1491), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 24.42m, 1866.48m, "Unbranded Wooden Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1525), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 46.33m, 6143.50m, "Tasty Fresh Tuna" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1571), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 45.14m, 9170.02m, "Unbranded Wooden Tuna" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1604), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 12.06m, 9798.31m, "Intelligent Wooden Tuna" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1638), "The Football Is Good For Training And Recreational Purposes", 8.27m, 4004.49m, "Refined Fresh Chair" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1671), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 20.33m, 5391.53m, "Gorgeous Concrete Salad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1706), "The Football Is Good For Training And Recreational Purposes", 2.18m, 8218.79m, "Handcrafted Wooden Tuna" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1740), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 25.17m, 8583.35m, "Ergonomic Fresh Tuna" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1774), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 5.00m, 9384.92m, "Handcrafted Plastic Computer" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1810), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 0.34m, 6418.85m, "Unbranded Concrete Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1844), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 46.60m, 6620.96m, "Unbranded Plastic Bacon" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1879), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 41.95m, 780.47m, "Licensed Fresh Keyboard" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1925), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 22.30m, 7576.57m, "Small Metal Soap" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1960), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 16.00m, 6429.51m, "Practical Frozen Table" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(1993), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 22.32m, 2133.76m, "Awesome Plastic Salad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2026), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 34.43m, 8614.59m, "Gorgeous Steel Chair" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2059), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 18.51m, 7472.73m, "Licensed Concrete Chicken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2092), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 25.64m, 9640.92m, "Rustic Soft Computer" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2126), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 4.13m, 741.03m, "Fantastic Steel Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2159), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 49.99m, 4136.97m, "Awesome Cotton Pizza" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2193), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 8.75m, 6195.96m, "Awesome Granite Bacon" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2239), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 30.05m, 6296.69m, "Awesome Metal Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2273), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 38.26m, 2092.96m, "Unbranded Steel Ball" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2306), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 25.34m, 6624.55m, "Practical Rubber Shoes" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2339), "The Football Is Good For Training And Recreational Purposes", 46.22m, 5258.13m, "Tasty Cotton Fish" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2373), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 23.08m, 1465.43m, "Incredible Plastic Chicken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2407), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 20.84m, 9697.79m, "Handmade Soft Sausages" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2441), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 39.33m, 8672.29m, "Practical Frozen Pizza" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2475), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 1.19m, 8466.85m, "Practical Fresh Pants" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2509), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 0.77m, 2550.05m, "Tasty Rubber Ball" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2542), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 0.41m, 1842.95m, "Gorgeous Wooden Bike" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2585), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 30.27m, 6442.15m, "Intelligent Granite Chips" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BrandId", "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2619), 28.65m, 5153.07m, "Unbranded Cotton Keyboard" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "BrandId", "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2652), 49.32m, 6925.20m, "Sleek Fresh Chicken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2686), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 34.92m, 3775.50m, "Unbranded Fresh Bike" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 9, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2719), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 6.54m, 998.76m, "Tasty Plastic Table" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2752), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 43.43m, 5625.60m, "Licensed Cotton Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2785), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 9.95m, 8031.14m, "Handmade Rubber Hat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 9, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2819), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 15.27m, 7715.62m, "Intelligent Concrete Shoes" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2853), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 41.55m, 8276.12m, "Fantastic Wooden Pizza" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "BrandId", "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2894), 31.45m, 5691.62m, "Tasty Metal Bacon" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2938), "The Football Is Good For Training And Recreational Purposes", 21.63m, 6782.45m, "Refined Rubber Hat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(2973), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 1.16m, 8257.92m, "Handmade Soft Sausages" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3007), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 28.04m, 8901.74m, "Sleek Wooden Ball" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3041), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 49.66m, 8265.99m, "Handmade Rubber Pizza" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3076), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 24.39m, 333.47m, "Handcrafted Frozen Sausages" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3109), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 16.22m, 9766.33m, "Awesome Plastic Soap" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 9, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3143), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 38.43m, 6597.19m, "Handmade Frozen Bacon" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3177), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 10.98m, 2885.69m, "Tasty Rubber Cheese" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3224), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 27.94m, 1808.52m, "Ergonomic Metal Hat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3258), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 49.14m, 2644.40m, "Refined Steel Tuna" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3291), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 46.53m, 6394.29m, "Practical Soft Hat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3325), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 3.47m, 8199.60m, "Handcrafted Fresh Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3358), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 46.91m, 5282.04m, "Practical Rubber Pizza" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "BrandId", "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3392), 10.35m, 383.70m, "Gorgeous Rubber Chair" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3425), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 20.70m, 1837.37m, "Intelligent Concrete Table" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3459), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 9.76m, 6355.28m, "Sleek Steel Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3492), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 13.43m, 7323.30m, "Handmade Plastic Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3525), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 25.82m, 5885.47m, "Incredible Rubber Pizza" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3568), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 20.12m, 5712.79m, "Intelligent Granite Pizza" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 26, 1, 6, 21, 524, DateTimeKind.Local).AddTicks(3602), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 12.78m, 7379.81m, "Practical Metal Tuna" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7221), "Özdoğan, Koçoğlu and Paksüt" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7360), "Akan Group" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7447), "Çağıran and Sons" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7534), "Akyürek Inc" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7660), "Oraloğlu, Kasapoğlu and Topaloğlu" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7734), "Kıraç  - Tütüncü" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7821), "Karabulut LLC" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(7899), "Yetkiner - Atan" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8017), "Öymen, Koyuncu and Sezek" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8094), "Bakırcıoğlu and Sons" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8240), "Koçyiğit Group" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8392), "Erginsoy, Solmaz and Alpuğan" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8479), "Okur and Sons" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8561), "Ekici LLC" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 693, DateTimeKind.Local).AddTicks(8645), "Numanoğlu - Sandalcı" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 14, 44, 28, 694, DateTimeKind.Local).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 14, 44, 28, 694, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 14, 44, 28, 694, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 14, 44, 28, 694, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(23), "Aliquam beğendim masanın doğru alias.", "Koşuyorlar." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(73), "Eos sit yazın eum alias.", "Aut." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(108), "Nihil amet orta göze nihil.", "Değirmeni." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(141), "Adresini cesurca tempora consequuntur qui.", "Eve." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(171), "Eve düşünüyor kulu aut biber.", "Odio." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(213), "Autem lakin velit quia layıkıyla.", "Quis." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(246), "Voluptatem quia qui ekşili voluptas.", "Ex." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(275), "Çakıl dolor ekşili ipsa de.", "Numquam." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(305), "Gitti balıkhaneye teldeki qui aut.", "Tv." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(336), "Mi enim ekşili doloremque ut.", "Autem." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(367), "Quam tempora quasi eos teldeki.", "Velit." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(398), "Sunt quia öyle sıla perferendis.", "İçin." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(432), "Sit dolorem enim sunt sokaklarda.", "Architecto." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(465), "Ut kalemi vitae quasi sevindi.", "Totam." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CategoryId", "CreatedDate", "Description" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(494), "Nisi beğendim reprehenderit iusto dolorem." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(521), "Masanın nisi qui quasi ea.", "Değerli." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(789), "Amet exercitationem voluptatem autem kapının.", "Çobanın." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(819), "İçin ipsum sequi sayfası ipsa.", "Aliquid." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(846), "Sokaklarda layıkıyla sequi accusantium aut.", "Quia." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(873), "Ama cesurca ex sed exercitationem.", "Anlamsız." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(916), "Eve çarpan gazete consequatur umut.", "Filmini." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(943), "Nisi koşuyorlar kulu cesurca enim.", "Ut." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(971), "Adipisci cesurca aperiam eaque doloremque.", "Ullam." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(999), "Değerli ullam telefonu tv ve.", "Quae." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 18, 14, 44, 28, 696, DateTimeKind.Local).AddTicks(1027), "Veritatis gül kalemi biber oldular.", "Quia." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9199), "The Football Is Good For Training And Recreational Purposes", 18.08m, 6598.73m, "Handmade Plastic Shoes" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9257), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 45.56m, 6408.13m, "Practical Fresh Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9291), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 34.70m, 8987.84m, "Small Metal Hat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9324), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 4.05m, 9167.87m, "Small Frozen Keyboard" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9354), 26.71m, 9230.04m, "Rustic Metal Keyboard" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9393), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 25.43m, 1708.80m, "Rustic Metal Ball" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9428), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 16.83m, 3075.47m, "Refined Metal Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9457), "The Football Is Good For Training And Recreational Purposes", 11.35m, 3692.80m, "Sleek Cotton Towels" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9485), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 48.27m, 4613.38m, "Gorgeous Wooden Keyboard" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9517), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 25.03m, 3959.07m, "Incredible Cotton Sausages" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9548), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 22.25m, 3391.63m, "Tasty Rubber Bike" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9577), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 10.33m, 3620.59m, "Fantastic Frozen Tuna" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9605), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 43.64m, 4187.19m, "Tasty Concrete Pizza" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9634), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 18.59m, 8794.50m, "Unbranded Metal Fish" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 9, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9670), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 48.93m, 8920.56m, "Incredible Metal Table" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9697), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 46.81m, 9639.73m, "Sleek Steel Chair" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9727), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 24.16m, 6005.93m, "Generic Granite Keyboard" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 9, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9754), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 10.30m, 5117.98m, "Sleek Metal Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9783), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 44.70m, 6872.43m, "Sleek Frozen Computer" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9811), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 22.37m, 7871.19m, "Incredible Frozen Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 9, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9839), "The Football Is Good For Training And Recreational Purposes", 10.19m, 3881.20m, "Handcrafted Metal Ball" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9868), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 39.36m, 5017.54m, "Licensed Wooden Salad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9896), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 6.40m, 9050.48m, "Handcrafted Plastic Bacon" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9932), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 45.06m, 8076.71m, "Incredible Metal Chips" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9961), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 9.30m, 6742.50m, "Handcrafted Metal Fish" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 18, 14, 44, 28, 698, DateTimeKind.Local).AddTicks(9988), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 35.09m, 4657.79m, "Practical Fresh Keyboard" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(17), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 4.81m, 898.56m, "Handcrafted Cotton Towels" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(45), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 29.80m, 2512.37m, "Sleek Wooden Pizza" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(72), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 39.84m, 1604.97m, "Tasty Wooden Chair" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(100), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 13.46m, 5983.61m, "Rustic Steel Keyboard" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(129), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 0.49m, 677.84m, "Ergonomic Wooden Cheese" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(157), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 1.73m, 1468.68m, "Fantastic Fresh Pants" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(184), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 31.77m, 3949.97m, "Handmade Plastic Computer" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(219), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 35.65m, 9180.43m, "Licensed Frozen Chicken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(247), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 41.69m, 3907.91m, "Fantastic Rubber Tuna" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(276), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 0.64m, 6369.27m, "Intelligent Soft Pants" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(305), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 35.12m, 8552.24m, "Rustic Fresh Ball" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 9, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(333), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 12.72m, 7627.42m, "Small Soft Ball" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(361), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 29.31m, 9247.58m, "Handmade Granite Chicken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(388), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 42.39m, 5051.78m, "Gorgeous Concrete Computer" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(417), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 42.48m, 1008.33m, "Unbranded Fresh Soap" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BrandId", "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(445), 43.43m, 271.38m, "Unbranded Granite Bacon" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "BrandId", "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(481), 38.88m, 5670.27m, "Ergonomic Wooden Chips" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 4, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(509), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 40.40m, 3487.04m, "Handcrafted Fresh Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(538), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 13.23m, 6049.23m, "Unbranded Steel Car" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(566), "The Football Is Good For Training And Recreational Purposes", 3.17m, 2318.35m, "Unbranded Metal Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 9, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(595), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 41.50m, 159.51m, "Ergonomic Metal Bacon" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(623), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 29.99m, 4128.22m, "Awesome Soft Hat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(651), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 7.36m, 6469.08m, "Incredible Metal Table" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "BrandId", "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { 2, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(678), 34.64m, 9914.63m, "Small Frozen Chicken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(716), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 11.74m, 3701.64m, "Practical Cotton Hat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(752), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 18.41m, 7072.32m, "Fantastic Rubber Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(781), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 0.57m, 9888.97m, "Rustic Concrete Salad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(809), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 9.70m, 7499.12m, "Ergonomic Steel Chicken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 5, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(838), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 18.41m, 9004.66m, "Fantastic Wooden Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 3, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(865), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 26.75m, 6155.31m, "Sleek Frozen Salad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 10, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(893), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 26.61m, 2744.71m, "Generic Plastic Chips" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(922), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 13.27m, 8291.17m, "Ergonomic Wooden Car" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 9, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(950), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 7.49m, 1980.75m, "Generic Wooden Towels" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(979), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 0.76m, 7987.58m, "Handcrafted Plastic Shoes" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1015), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 3.09m, 5234.82m, "Handcrafted Wooden Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 1, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1043), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 11.49m, 4402.01m, "Licensed Plastic Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1070), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 18.24m, 2359.64m, "Intelligent Fresh Table" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "BrandId", "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1098), 23.23m, 8980.05m, "Licensed Steel Shoes" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1126), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 37.58m, 729.88m, "Handcrafted Granite Towels" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 6, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1154), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 34.27m, 3134.66m, "Licensed Frozen Soap" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1182), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 30.28m, 4256.34m, "Handmade Steel Towels" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1210), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 14.25m, 2700.21m, "Generic Plastic Ball" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 8, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1238), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 0.97m, 8278.81m, "Refined Wooden Chair" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "BrandId", "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { 7, new DateTime(2025, 11, 18, 14, 44, 28, 699, DateTimeKind.Local).AddTicks(1274), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 27.06m, 6222.05m, "Rustic Wooden Chicken" });
        }
    }
}
