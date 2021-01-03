using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvalTask.Data.Migrations
{
    public partial class ProductAndCatigoriesAuditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Category",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "Category",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Category",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0ed6a80b-f50e-4a6e-8fe9-a7242f78cf1e", 0, "df823769-f912-4490-b683-9dd411eb5c3a", "admin@et.com", false, false, null, "ADMIN@ET.COM", "ADMIN", "AQAAAAEAACcQAAAAEHbdZG98rdwPUP87OZHtLhzegOGb+tUgA+jT6tG0/ILYLLb/lSGTLkZShY8t4yUx5Q==", "+79999999999", false, "6b17f3df-3ff8-45c0-ba6a-46b5f2a2bfaf", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("012ee0ef-e051-4e04-acc9-07ee03898f93"),
                columns: new[] { "CreatedByUserId", "CreatedDate" },
                values: new object[] { "0ed6a80b-f50e-4a6e-8fe9-a7242f78cf1e", new DateTime(2021, 1, 3, 20, 24, 49, 136, DateTimeKind.Local).AddTicks(5706) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e0bc9e7a-67e1-4d46-9605-13daa1908a86"),
                columns: new[] { "CreatedByUserId", "CreatedDate" },
                values: new object[] { "0ed6a80b-f50e-4a6e-8fe9-a7242f78cf1e", new DateTime(2021, 1, 3, 20, 24, 49, 139, DateTimeKind.Local).AddTicks(2090) });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatedByUserId",
                table: "Product",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UpdatedByUserId",
                table: "Product",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CreatedByUserId",
                table: "Category",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_UpdatedByUserId",
                table: "Category",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_AspNetUsers_CreatedByUserId",
                table: "Category",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_AspNetUsers_UpdatedByUserId",
                table: "Category",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_CreatedByUserId",
                table: "Product",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_UpdatedByUserId",
                table: "Product",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_AspNetUsers_CreatedByUserId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_AspNetUsers_UpdatedByUserId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_CreatedByUserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_UpdatedByUserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CreatedByUserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UpdatedByUserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Category_CreatedByUserId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_UpdatedByUserId",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ed6a80b-f50e-4a6e-8fe9-a7242f78cf1e");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Category");
        }
    }
}
