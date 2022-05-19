using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations
{
    public partial class AddStoreImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "96ca91a4-a494-4a95-b2f2-dd5074cd3086");

            migrationBuilder.AddColumn<string>(
                name: "StoreImage",
                table: "Store",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "CreatedAt", "Description", "Email", "IsDeleted", "PhoneNumber", "UpdatedAt" },
                values: new object[] { "0d0838fb-2e62-402e-876a-ca7830464438", "1401/1/15", "فروشگاه روبیک مارکت ", "mohammad98.master@gmail.com", false, "09918535698", null });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "0d0838fb-2e62-402e-876a-ca7830464438");

            migrationBuilder.DropColumn(
                name: "StoreImage",
                table: "Store");

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "CreatedAt", "Description", "Email", "IsDeleted", "PhoneNumber", "UpdatedAt" },
                values: new object[] { "96ca91a4-a494-4a95-b2f2-dd5074cd3086", "1401/1/15", "فروشگاه روبیک مارکت ", "mohammad98.master@gmail.com", false, "09918535698", null });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "07171c7f-a97d-45f8-a76e-2df3398a7e8e",
                column: "ConcurrencyStamp",
                value: "da002fe7-342f-4296-baae-97cbfcafbff7");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "19b499d6-8920-43c0-a6d7-bbe48c42f7b3",
                column: "ConcurrencyStamp",
                value: "4c3ab51e-e438-4bbd-8294-2293970f3ee5");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ac0e1032-58c2-449a-8b47-7f6838386bc0",
                column: "ConcurrencyStamp",
                value: "65799894-4e04-4d55-bd50-533cf56c766d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ea345380-5af2-4d0c-a0e2-65f3eeabb898",
                column: "ConcurrencyStamp",
                value: "8071b640-d863-40f6-a0e8-2a6252466f40");
        }
    }
}
