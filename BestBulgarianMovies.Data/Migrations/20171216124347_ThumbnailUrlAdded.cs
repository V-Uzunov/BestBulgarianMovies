using Microsoft.EntityFrameworkCore.Migrations;

namespace BestBulgarianMovies.Data.Migrations
{
    public partial class ThumbnailUrlAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Articles");
        }
    }
}