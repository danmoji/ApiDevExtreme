using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDevExtreme.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Revenue",
                table: "Projects",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Revenue",
                table: "Projects");
        }
    }
}
