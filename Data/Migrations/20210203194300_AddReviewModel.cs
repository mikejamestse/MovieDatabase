using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Data.Migrations
{
    public partial class AddReviewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reviews",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "ReviewsID",
                table: "Movie",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserReview = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ReviewsID",
                table: "Movie",
                column: "ReviewsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Review_ReviewsID",
                table: "Movie",
                column: "ReviewsID",
                principalTable: "Review",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Review_ReviewsID",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ReviewsID",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ReviewsID",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "Reviews",
                table: "Movie",
                type: "TEXT",
                maxLength: 1000,
                nullable: true);
        }
    }
}
