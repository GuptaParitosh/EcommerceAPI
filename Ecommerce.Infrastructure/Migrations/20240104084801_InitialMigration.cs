using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("2aef81d8-f6f9-4dd1-ad4b-377f2996ac02"), "Men's Fashion" },
                    { new Guid("3f85c6ef-0e1b-449b-8f15-989575379024"), "Women's Fashion" },
                    { new Guid("738bff8a-b670-4d29-af79-9eb31058dd64"), "Mobiles, Computers" },
                    { new Guid("7eef79a6-745a-4c4e-8d9c-99d71bb4ccd5"), "Toy, Baby Products, Kid's Fashion" },
                    { new Guid("9a3768da-4464-4702-b24d-48288dd96eb0"), "TV, Appliances, Electronics" },
                    { new Guid("f382d6f5-37e9-4ae1-b957-6df092654021"), "Books" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Price", "ProductName", "ProductType" },
                values: new object[,]
                {
                    { new Guid("414fb751-5548-4b76-b9d5-d2fb0f7d1de4"), new Guid("f382d6f5-37e9-4ae1-b957-6df092654021"), 250L, "Two States By Chetan Bhagat", "FictionBooks" },
                    { new Guid("62707d45-cdd5-4f2f-b1d2-e05f9f1ef149"), new Guid("738bff8a-b670-4d29-af79-9eb31058dd64"), 18000L, "Samsung Galaxy Tab A9+", "Tablets" },
                    { new Guid("8cee5fc7-2773-43de-b2db-8b0e5ff60710"), new Guid("2aef81d8-f6f9-4dd1-ad4b-377f2996ac02"), 11997L, "Fossil Gen 6 Digital Black Dial Men's Watch-FTW4061", " MensWatches" },
                    { new Guid("8f568a3c-c327-4e8c-8802-e63e2b2406da"), new Guid("3f85c6ef-0e1b-449b-8f15-989575379024"), 1197L, "Fastrack New Limitless FS1 Smart Watch", " WomensWatches" },
                    { new Guid("a0bd54bc-a197-49ad-b5dc-f6f6c623e297"), new Guid("f382d6f5-37e9-4ae1-b957-6df092654021"), 500L, "Harry Potter and the Philosopher Stone by J.K. Rowling", "KidsBooks" },
                    { new Guid("bf4f4572-30fc-4783-9bd3-f0eef99c7723"), new Guid("f382d6f5-37e9-4ae1-b957-6df092654021"), 2500L, "System Design By Paritosh Gupta", "TextBooks" },
                    { new Guid("dc57f3ff-df12-42ef-a8b9-39c67b7320c9"), new Guid("738bff8a-b670-4d29-af79-9eb31058dd64"), 30000L, "IQOO Z6", "Mobiles" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
