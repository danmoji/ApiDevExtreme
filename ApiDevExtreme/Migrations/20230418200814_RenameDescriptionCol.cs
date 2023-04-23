using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDevExtreme.Migrations
{
    /// <inheritdoc />
    public partial class RenameDescriptionCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriptin",
                table: "Qualities",
                newName: "Description");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Qualities",
                newName: "Descriptin");
        }
    }
}
