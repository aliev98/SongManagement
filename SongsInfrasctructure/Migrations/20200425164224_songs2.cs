using Microsoft.EntityFrameworkCore.Migrations;

namespace SongsInfrasctructure.Migrations
{
    public partial class songs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SongDetails",
                table: "SongDetails");

            migrationBuilder.RenameTable(
                name: "SongDetails",
                newName: "Songs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "ArtistName", "Length", "Title" },
                values: new object[] { 2, "Brock Lesnar", 15, "Hello" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "SongDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongDetails",
                table: "SongDetails",
                column: "Id");
        }
    }
}
