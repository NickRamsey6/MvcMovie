using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDirectorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Director_DirectorId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_DirectorId",
                table: "Movie",
                column: "DirectorId",
                principalTable: "Director",
                principalColumn: "DirectorId");
        }
    }
}
