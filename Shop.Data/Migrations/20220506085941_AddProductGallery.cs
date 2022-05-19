using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations
{
    public partial class AddProductGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "403388dc-91e3-46a1-9a58-74ed23387843");

            migrationBuilder.CreateTable(
                name: "ProductGallery",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DisplayPriority = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGallery_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "CreatedAt", "Description", "Email", "IsDeleted", "PhoneNumber", "UpdatedAt" },
                values: new object[] { "af01ddc7-d7bc-408b-98e8-ea02728381d8", "1401/2/16", "فروشگاه روبیک مارکت ", "mohammad98.master@gmail.com", false, "09918535698", null });

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "00b8689e-5add-4607-95b6-ddc60d6c9ca8",
                column: "CreatedAt",
                value: "1401/2/16");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "70f20b22-620f-4dfc-9da8-561cd00d6cab",
                column: "CreatedAt",
                value: "1401/2/16");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "ae086c96-f400-4af7-b0bd-0e416e91c4c4",
                column: "CreatedAt",
                value: "1401/2/16");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "f839f213-d2be-4032-8dcc-586424c288e0",
                column: "CreatedAt",
                value: "1401/2/16");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "07171c7f-a97d-45f8-a76e-2df3398a7e8e",
                column: "ConcurrencyStamp",
                value: "71ffadde-5065-43ef-9784-4604f8b1697d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "19b499d6-8920-43c0-a6d7-bbe48c42f7b3",
                column: "ConcurrencyStamp",
                value: "c67b49ad-e662-406a-9993-b657c644c647");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ac0e1032-58c2-449a-8b47-7f6838386bc0",
                column: "ConcurrencyStamp",
                value: "4c9cea6a-c1fb-4ad7-b50b-aa778df86a3f");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ea345380-5af2-4d0c-a0e2-65f3eeabb898",
                column: "ConcurrencyStamp",
                value: "8ed02695-5c5b-4513-89ef-351418ccdfe1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGallery_ProductId",
                table: "ProductGallery",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductGallery");

            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "af01ddc7-d7bc-408b-98e8-ea02728381d8");

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "CreatedAt", "Description", "Email", "IsDeleted", "PhoneNumber", "UpdatedAt" },
                values: new object[] { "403388dc-91e3-46a1-9a58-74ed23387843", "1401/2/2", "فروشگاه روبیک مارکت ", "mohammad98.master@gmail.com", false, "09918535698", null });

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "00b8689e-5add-4607-95b6-ddc60d6c9ca8",
                column: "CreatedAt",
                value: "1401/2/2");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "70f20b22-620f-4dfc-9da8-561cd00d6cab",
                column: "CreatedAt",
                value: "1401/2/2");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "ae086c96-f400-4af7-b0bd-0e416e91c4c4",
                column: "CreatedAt",
                value: "1401/2/2");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "f839f213-d2be-4032-8dcc-586424c288e0",
                column: "CreatedAt",
                value: "1401/2/2");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "07171c7f-a97d-45f8-a76e-2df3398a7e8e",
                column: "ConcurrencyStamp",
                value: "6429cf33-0a06-4cf3-a6b6-7b528defdb73");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "19b499d6-8920-43c0-a6d7-bbe48c42f7b3",
                column: "ConcurrencyStamp",
                value: "fd1aeed0-2b26-4908-bd95-f47a7fcadb08");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ac0e1032-58c2-449a-8b47-7f6838386bc0",
                column: "ConcurrencyStamp",
                value: "e61a52cf-6c6a-48f3-a2d2-adcc3e479430");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ea345380-5af2-4d0c-a0e2-65f3eeabb898",
                column: "ConcurrencyStamp",
                value: "114bde0b-091b-4cb5-ac26-d94a70eeb8f9");
        }
    }
}
