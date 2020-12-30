using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class aaas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "odersDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "idUser",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7bea5ff-9548-437c-8bf8-8b3bfd5ac028", "AQAAAAEAACcQAAAAEDYBCCRr9F7uhjlfXmSuzVKyd8Ot5Ikt9Xur6yyreNPYiOvCZQxLcqxYvFMsOn/pIA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "odersDetails",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "idUser",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7bee615b-6a13-4506-a3d5-baa793828a83", "AQAAAAEAACcQAAAAEPqPfNRd/sX8O7lQOKQETaZb8JpEvRBPO8qUcDillM/KpA71mSDQV93b3MpkgYh3KA==" });
        }
    }
}
