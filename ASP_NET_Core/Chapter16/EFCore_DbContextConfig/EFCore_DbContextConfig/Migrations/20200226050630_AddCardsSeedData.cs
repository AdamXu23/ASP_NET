using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore_DbContextConfig.Migrations
{
    public partial class AddCardsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Brief = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    WikiUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Brief", "Name", "Photo", "WikiUrl" },
                values: new object[,]
                {
                    { 1, "特斯拉創辦人 伊隆·馬斯克", "Elon Musk", "ElonMusk.jpg", "https://goo.gl/46xeXx" },
                    { 2, "Facebook創辦人 馬克·祖伯克", "Mark Zuckerberg", "MarkZuckerberg.jpg", "https://goo.gl/BktGGA" },
                    { 3, "蘋果創辦人 史提夫·賈伯斯", "Steve Jobs", "SteveJobs.jpg", "https://goo.gl/nAiX0y" },
                    { 4, "帝國元帥  維達", "Vader", "Vader.jpg", "https://en.wikipedia.org/wiki/Darth_Vader" },
                    { 5, "星際大戰 達斯摩", "Darth Mual", "DarthMual.jpg", "https://goo.gl/5obLhX" },
                    { 6, "星際大戰 女絕地武士Twilek", "White Twilek", "WhiteTwilek.jpg", "https://goo.gl/reKzAu" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
