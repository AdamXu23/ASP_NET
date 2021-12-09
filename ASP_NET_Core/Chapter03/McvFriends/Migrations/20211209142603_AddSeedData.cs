using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McvFriends.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "id", "Email", "Mobile", "Name" },
                values: new object[] { 1, "Mary@gmail.com", "0922-355822", "Mary" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "id", "Email", "Mobile", "Name" },
                values: new object[] { 2, "David@gmail.com", "0933-123456", "David" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "id", "Email", "Mobile", "Name" },
                values: new object[] { 3, "Rose@gmail.com", "0955-888-163", "Rose" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
