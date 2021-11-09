using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet_Core_webApi.Migrations
{
    public partial class bookauthorculumnremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                type: "text",
                nullable: true);
        }
    }
}
