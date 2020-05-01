using Microsoft.EntityFrameworkCore.Migrations;

namespace SongsInfrasctructure.Migrations
{
    public partial class songs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SongDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ArtistName = table.Column<string>(nullable: true),
                    Length = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SongDetails",
                columns: new[] { "Id", "ArtistName", "Length", "Title" },
                values: new object[] { 1, "John Cena", 10, "Hello world" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongDetails");
        }
    }
}
