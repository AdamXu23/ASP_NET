using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMvc3_EFMigrations.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    City = table.Column<int>(nullable: false),
                    Commutermode = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Terms = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Mobile", "Name", "Title" },
                values: new object[,]
                {
                    { 1, "總經理室", "david@gmail.com", "0935-155222", "David", "CEO" },
                    { 2, "人事部", "mary@gmail.com", "0938-456889", "Mary", "管理師" },
                    { 4, "財務部", "joe@gmail.com", "0925-331225", "Joe", "經理" },
                    { 5, "業務部", "mark@gmail.com", "0935-863991", "Mark", "業務員" },
                    { 6, "資訊部", "rose@gmail.com", "0987-335668", "Rose", "工程師" }
                });

            migrationBuilder.InsertData(
                table: "Registers",
                columns: new[] { "Id", "City", "Comment", "Commutermode", "Email", "Gender", "Name", "Nickname", "Password", "Terms" },
                values: new object[] { 1, 4, "Nothing", "1", "dotnetcool@gmail.com", 1, "奚江華", "聖殿祭司", "myPassword*", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Registers");
        }
    }
}
