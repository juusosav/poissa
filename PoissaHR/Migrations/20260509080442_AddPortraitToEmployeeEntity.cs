using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoissaHR.Migrations
{
    /// <inheritdoc />
    public partial class AddPortraitToEmployeeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Portrait",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Portrait",
                table: "Employees");
        }
    }
}
