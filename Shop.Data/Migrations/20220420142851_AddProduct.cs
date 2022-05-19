using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations
{
    public partial class AddProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "0d0838fb-2e62-402e-876a-ca7830464438");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductAcceptOrRejectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductAcceptanceState = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "CreatedAt", "Description", "Email", "IsDeleted", "PhoneNumber", "UpdatedAt" },
                values: new object[] { "90305855-2ba1-4c07-b044-1a47ba22e1c6", "1401/1/31", "فروشگاه روبیک مارکت ", "mohammad98.master@gmail.com", false, "09918535698", null });

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "00b8689e-5add-4607-95b6-ddc60d6c9ca8",
                column: "CreatedAt",
                value: "1401/1/31");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "70f20b22-620f-4dfc-9da8-561cd00d6cab",
                column: "CreatedAt",
                value: "1401/1/31");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "ae086c96-f400-4af7-b0bd-0e416e91c4c4",
                column: "CreatedAt",
                value: "1401/1/31");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "f839f213-d2be-4032-8dcc-586424c288e0",
                column: "CreatedAt",
                value: "1401/1/31");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "07171c7f-a97d-45f8-a76e-2df3398a7e8e",
                column: "ConcurrencyStamp",
                value: "67cbd7c5-9fc5-48f6-9c7c-6b5f57c3ee94");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "19b499d6-8920-43c0-a6d7-bbe48c42f7b3",
                column: "ConcurrencyStamp",
                value: "53ac2432-379d-4492-95a0-4e3d8a9199ad");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ac0e1032-58c2-449a-8b47-7f6838386bc0",
                column: "ConcurrencyStamp",
                value: "7cc35720-cec7-4c91-ae3a-88f56632abbb");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ea345380-5af2-4d0c-a0e2-65f3eeabb898",
                column: "ConcurrencyStamp",
                value: "6c8c4ac9-4cbb-468c-a264-60a1781fa8e6");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StoreId",
                table: "Product",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "90305855-2ba1-4c07-b044-1a47ba22e1c6");

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "CreatedAt", "Description", "Email", "IsDeleted", "PhoneNumber", "UpdatedAt" },
                values: new object[] { "0d0838fb-2e62-402e-876a-ca7830464438", "1401/1/15", "فروشگاه روبیک مارکت ", "mohammad98.master@gmail.com", false, "09918535698", null });

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "00b8689e-5add-4607-95b6-ddc60d6c9ca8",
                column: "CreatedAt",
                value: "1401/1/15");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "70f20b22-620f-4dfc-9da8-561cd00d6cab",
                column: "CreatedAt",
                value: "1401/1/15");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "ae086c96-f400-4af7-b0bd-0e416e91c4c4",
                column: "CreatedAt",
                value: "1401/1/15");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "f839f213-d2be-4032-8dcc-586424c288e0",
                column: "CreatedAt",
                value: "1401/1/15");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "07171c7f-a97d-45f8-a76e-2df3398a7e8e",
                column: "ConcurrencyStamp",
                value: "b23e5af6-956a-4afe-a4e3-fa39c959b222");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "19b499d6-8920-43c0-a6d7-bbe48c42f7b3",
                column: "ConcurrencyStamp",
                value: "67b7ddcb-69ec-450e-bdfb-71e72496298a");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ac0e1032-58c2-449a-8b47-7f6838386bc0",
                column: "ConcurrencyStamp",
                value: "732fcaca-2853-410d-b9cb-f489ea370dcd");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ea345380-5af2-4d0c-a0e2-65f3eeabb898",
                column: "ConcurrencyStamp",
                value: "45792c8b-3d9d-466c-a7ca-f357a5073d4b");
        }
    }
}
