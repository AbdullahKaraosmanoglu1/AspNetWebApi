using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsHomePageForBookEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Books");
        }
    }
}
