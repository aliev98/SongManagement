using Microsoft.EntityFrameworkCore.Migrations;

namespace SongsInfrasctructure.Migrations
{
    public partial class playlists1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaylistDetailsId",
                table: "Songs",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
