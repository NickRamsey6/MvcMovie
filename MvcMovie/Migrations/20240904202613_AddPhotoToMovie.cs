using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Photo_MovieId",
                table: "Photo",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Movie_MovieId",
                table: "Photo",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Movie_MovieId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_MovieId",
                table: "Photo");
        }
    }
}
