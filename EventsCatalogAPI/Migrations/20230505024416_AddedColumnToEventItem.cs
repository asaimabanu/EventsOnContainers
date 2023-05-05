using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsCatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnToEventItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventCategoryName",
                table: "EventItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventCategoryName",
                table: "EventItems");
        }
    }
}
