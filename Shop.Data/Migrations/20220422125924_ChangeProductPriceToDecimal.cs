using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations
{
    public partial class ChangeProductPriceToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "90305855-2ba1-4c07-b044-1a47ba22e1c6");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "403388dc-91e3-46a1-9a58-74ed23387843");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
        }
    }
}
