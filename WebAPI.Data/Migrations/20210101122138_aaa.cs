using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class aaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "users",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "idUser",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af786429-68f4-4d64-8ec5-5342ad7a4ad4", "AQAAAAEAACcQAAAAEBy+Z/47JWNtasWgWAwOJwU+Ifjvn1R0yC+j9RthP0hn0JlnIldy4/tsKJQvm2Demg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "users",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "idUser",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dcd2b5ae-9906-4ca6-88ff-d0c875a7cfcf", "AQAAAAEAACcQAAAAEN4gO3645lzqTAc1CJghvXgVbqDDAyEZCw9V3l5ZOosmGc4r7QR+oZswUDIcVIddMw==" });
        }
    }
}
