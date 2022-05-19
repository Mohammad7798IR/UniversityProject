using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations
{
    public partial class EditProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "af01ddc7-d7bc-408b-98e8-ea02728381d8");

            migrationBuilder.AddColumn<decimal>(
                name: "SoldCount",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ViewCount",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "CreatedAt", "Description", "Email", "IsDeleted", "PhoneNumber", "UpdatedAt" },
                values: new object[] { "fce4c15f-df83-4dbb-bccb-7b6c4bc0f0f7", "1401/2/20", "فروشگاه روبیک مارکت ", "mohammad98.master@gmail.com", false, "09918535698", null });

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "00b8689e-5add-4607-95b6-ddc60d6c9ca8",
                column: "CreatedAt",
                value: "1401/2/20");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "70f20b22-620f-4dfc-9da8-561cd00d6cab",
                column: "CreatedAt",
                value: "1401/2/20");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "ae086c96-f400-4af7-b0bd-0e416e91c4c4",
                column: "CreatedAt",
                value: "1401/2/20");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "f839f213-d2be-4032-8dcc-586424c288e0",
                column: "CreatedAt",
                value: "1401/2/20");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "07171c7f-a97d-45f8-a76e-2df3398a7e8e",
                column: "ConcurrencyStamp",
                value: "cbf6868a-8813-47fb-9939-c8af4ebff669");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "19b499d6-8920-43c0-a6d7-bbe48c42f7b3",
                column: "ConcurrencyStamp",
                value: "1f26db59-c295-4ed7-b031-9c6f7933b18b");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ac0e1032-58c2-449a-8b47-7f6838386bc0",
                column: "ConcurrencyStamp",
                value: "58e97b98-4445-4209-be50-21a04b584709");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ea345380-5af2-4d0c-a0e2-65f3eeabb898",
                column: "ConcurrencyStamp",
                value: "9e3650d3-655d-43cd-876d-f3dcf0c7eabb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "fce4c15f-df83-4dbb-bccb-7b6c4bc0f0f7");

            migrationBuilder.DropColumn(
                name: "SoldCount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Product");

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
        }
    }
}
