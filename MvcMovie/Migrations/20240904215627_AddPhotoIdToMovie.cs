using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoIdToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Movie_MovieId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_MovieId",
                table: "Photo");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosterPhotoPhotoId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_PosterPhotoPhotoId",
                table: "Movie",
                column: "PosterPhotoPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Photo_PosterPhotoPhotoId",
                table: "Movie",
                column: "PosterPhotoPhotoId",
                principalTable: "Photo",
                principalColumn: "PhotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Photo_PosterPhotoPhotoId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_PosterPhotoPhotoId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "PosterPhotoPhotoId",
                table: "Movie");

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
    }
}
