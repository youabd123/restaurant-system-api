using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateMenuItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "MenuItems",
    columns: table => new
    {
        Id = table.Column<int>(nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        CategoryId = table.Column<int>(nullable: false),
        Name = table.Column<string>(nullable: false),
        Description = table.Column<string>(nullable: false),
        Price = table.Column<decimal>(nullable: false),
        IsAvailable = table.Column<bool>(nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_MenuItems", x => x.Id);
        table.ForeignKey(
            name: "FK_MenuItems_Categories_CategoryId",
            column: x => x.CategoryId,
            principalTable: "Categories",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "MenuItems");

        }
    }
}
