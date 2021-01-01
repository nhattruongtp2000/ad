using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "photoReview",
                table: "odersDetails",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "idUser",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bcbbf782-f085-42b7-8d96-060e12c2602b", "AQAAAAEAACcQAAAAEISQI8LNO44l1DyOnP1bnecyY52UPWSvdbNmaugI8IROr/luUP5QK2erjg8USQ9Orw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photoReview",
                table: "odersDetails");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "idUser",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af786429-68f4-4d64-8ec5-5342ad7a4ad4", "AQAAAAEAACcQAAAAEBy+Z/47JWNtasWgWAwOJwU+Ifjvn1R0yC+j9RthP0hn0JlnIldy4/tsKJQvm2Demg==" });
        }
    }
}
