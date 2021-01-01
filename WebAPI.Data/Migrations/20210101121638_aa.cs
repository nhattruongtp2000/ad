using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalPrice",
                table: "odersDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "expiredDate",
                table: "vouchers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "totalPrice",
                table: "odersList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "idUser",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dcd2b5ae-9906-4ca6-88ff-d0c875a7cfcf", "AQAAAAEAACcQAAAAEN4gO3645lzqTAc1CJghvXgVbqDDAyEZCw9V3l5ZOosmGc4r7QR+oZswUDIcVIddMw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalPrice",
                table: "odersList");

            migrationBuilder.AlterColumn<string>(
                name: "expiredDate",
                table: "vouchers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "totalPrice",
                table: "odersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "idUser",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af463510-7266-4d0f-94cd-eb363135d8e3", "AQAAAAEAACcQAAAAEPU6AStYblm936kq5uekgc1NsqsSSVqJ0o9Nd0toE0EU9WCaFP4iR6+YVyFCCHB90Q==" });
        }
    }
}
