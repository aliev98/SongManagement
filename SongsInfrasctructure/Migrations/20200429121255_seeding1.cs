using Microsoft.EntityFrameworkCore.Migrations;

namespace SongsInfrasctructure.Migrations
{
    public partial class seeding1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Songs I like", "Favourites" });

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "a form of popular music originating in the rural southern US. It is a mixture of ballads and dance tunes played characteristically on fiddle, banjo, guitar, and pedal steel guitar.", "Country music" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArtistName", "Title" },
                values: new object[] { "Avicii", "Without you" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArtistName", "Title" },
                values: new object[] { "Avicii", "The nights" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "ArtistName", "Length", "Title" },
                values: new object[,]
                {
                    { 3, "Avicii", 12, "Waiting for love" },
                    { 4, "Eminem", 11, "Beautiful" },
                    { 5, "Eminem", 19, "Lose Yourself" },
                    { 6, "Marren Morris", 25, "The Bones" },
                    { 7, "Randy Travis", 20, "Forever And Ever" }
                });

            migrationBuilder.UpdateData(
                table: "songForPlaylists",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlaylistId",
                value: 1);

            migrationBuilder.InsertData(
                table: "songForPlaylists",
                columns: new[] { "Id", "PlaylistId", "SongDetailsId" },
                values: new object[,]
                {
                    { 2, 1, 4 },
                    { 3, 1, 5 },
                    { 4, 2, 6 },
                    { 5, 2, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "songForPlaylists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "songForPlaylists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "songForPlaylists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "songForPlaylists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "MMA stuff", "UFC" });

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Wrestling stuff", "WWE" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArtistName", "Title" },
                values: new object[] { "John Cena", "John Cena" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArtistName", "Title" },
                values: new object[] { "Brock Lesnar", "Brock Lesnar" });

            migrationBuilder.UpdateData(
                table: "songForPlaylists",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlaylistId",
                value: 2);
        }
    }
}
