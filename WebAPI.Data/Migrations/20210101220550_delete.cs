using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photoReview",
                table: "odersDetails");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "idUser",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22f5c605-27e6-4ff1-8feb-e45b8b0f91f4", "AQAAAAEAACcQAAAAEBYICRAzGfoEGewFTxCUTgEAyN6g891/MPIpfRXMHiO11Yw6mVYJqalUaKJdeEfupA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
