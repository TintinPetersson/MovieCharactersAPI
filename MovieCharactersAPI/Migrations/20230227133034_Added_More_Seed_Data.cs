using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCharactersAPI.Migrations
{
    /// <inheritdoc />
    public partial class Added_More_Seed_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: 0);
        }
    }
}
