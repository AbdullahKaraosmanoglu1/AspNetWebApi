using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsApprovedForBookEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Books");
        }
    }
}
