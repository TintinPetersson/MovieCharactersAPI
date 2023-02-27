using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieCharactersAPI.Migrations
{
    /// <inheritdoc />
    public partial class _202302271553_Add_Moviés : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "Photo" },
                values: new object[,]
                {
                    { 1, "FillePille", "Filip", 2, "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg" },
                    { 2, "TommyBoy", "Tommy", 0, "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "Picture", "ReleaseYear", "Title", "Trailer" },
                values: new object[,]
                {
                    { 1, "Tintin The Big", 1, "Action, Adventure", "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg", 2001, "Filips Adventure", "https://www.youtube.com/watch?v=OMGBIQHODhw" },
                    { 2, "Tintin The Big", 1, "Drama, Comedy", "https://i.ytimg.com/vi/OMGBIQHODhw/maxresdefault.jpg", 2010, "Tommy's Wedding", "https://www.youtube.com/watch?v=OMGBIQHODhw" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
