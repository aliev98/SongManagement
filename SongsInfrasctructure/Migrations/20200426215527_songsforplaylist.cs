using Microsoft.EntityFrameworkCore.Migrations;

namespace SongsInfrasctructure.Migrations
{
    public partial class songsforplaylist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Playlists_PlaylistDetailsId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_PlaylistDetailsId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PlaylistDetailsId",
                table: "Songs");

            migrationBuilder.CreateTable(
                name: "songForPlaylists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongDetailsId = table.Column<int>(nullable: false),
                    PlaylistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_songForPlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_songForPlaylists_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_songForPlaylists_Songs_SongDetailsId",
                        column: x => x.SongDetailsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "MMA stuff", "UFC" },
                    { 2, "Wrestling stuff", "WWE" }
                });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "John Cena");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Brock Lesnar");

            migrationBuilder.InsertData(
                table: "songForPlaylists",
                columns: new[] { "Id", "PlaylistId", "SongDetailsId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_songForPlaylists_PlaylistId",
                table: "songForPlaylists",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_songForPlaylists_SongDetailsId",
                table: "songForPlaylists",
                column: "SongDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "songForPlaylists");

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "PlaylistDetailsId",
                table: "Songs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Hello world");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Hello");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistDetailsId",
                table: "Songs",
                column: "PlaylistDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Playlists_PlaylistDetailsId",
                table: "Songs",
                column: "PlaylistDetailsId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
