using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurguerMania.Migrations
{
    /// <inheritdoc />
    public partial class configProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BaseDescription",
                table: "Products",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "BaseDescription");
        }
    }
}
