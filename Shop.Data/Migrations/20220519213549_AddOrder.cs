using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations
{
    public partial class AddOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "fce4c15f-df83-4dbb-bccb-7b6c4bc0f0f7");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    TracingCode = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_User_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "CreatedAt", "Description", "Email", "IsDeleted", "PhoneNumber", "UpdatedAt" },
                values: new object[] { "27ba6aa8-e5b3-4d10-9689-9f313b86f5aa", "1401/2/30", "فروشگاه روبیک مارکت ", "mohammad98.master@gmail.com", false, "09918535698", null });

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "00b8689e-5add-4607-95b6-ddc60d6c9ca8",
                column: "CreatedAt",
                value: "1401/2/30");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "70f20b22-620f-4dfc-9da8-561cd00d6cab",
                column: "CreatedAt",
                value: "1401/2/30");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "ae086c96-f400-4af7-b0bd-0e416e91c4c4",
                column: "CreatedAt",
                value: "1401/2/30");

            migrationBuilder.UpdateData(
                table: "QA",
                keyColumn: "Id",
                keyValue: "f839f213-d2be-4032-8dcc-586424c288e0",
                column: "CreatedAt",
                value: "1401/2/30");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "07171c7f-a97d-45f8-a76e-2df3398a7e8e",
                column: "ConcurrencyStamp",
                value: "02a130bb-f6a2-4b62-95cc-a624fd653214");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "19b499d6-8920-43c0-a6d7-bbe48c42f7b3",
                column: "ConcurrencyStamp",
                value: "0aad42f4-3220-4ec3-9ad0-adbe019bae3b");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ac0e1032-58c2-449a-8b47-7f6838386bc0",
                column: "ConcurrencyStamp",
                value: "4bb59d66-fbec-4d8d-868e-ebcec7cb65d4");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ea345380-5af2-4d0c-a0e2-65f3eeabb898",
                column: "ConcurrencyStamp",
                value: "b4713df5-1c0a-41e4-a1c1-2d7c11f55f3b");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "AboutUs",
                keyColumn: "Id",
                keyValue: "27ba6aa8-e5b3-4d10-9689-9f313b86f5aa");

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
    }
}
