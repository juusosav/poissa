using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoissaHR.Migrations
{
    /// <inheritdoc />
    public partial class FixDocumentIdentityNamingIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesDocument_Employees_EmployeeId",
                table: "EmployeesDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesDocument",
                table: "EmployeesDocument");

            migrationBuilder.RenameTable(
                name: "EmployeesDocument",
                newName: "EmployeeDocument");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeesDocument_EmployeeId",
                table: "EmployeeDocument",
                newName: "IX_EmployeeDocument_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDocument",
                table: "EmployeeDocument",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDocument_Employees_EmployeeId",
                table: "EmployeeDocument",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDocument_Employees_EmployeeId",
                table: "EmployeeDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDocument",
                table: "EmployeeDocument");

            migrationBuilder.RenameTable(
                name: "EmployeeDocument",
                newName: "EmployeesDocument");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDocument_EmployeeId",
                table: "EmployeesDocument",
                newName: "IX_EmployeesDocument_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesDocument",
                table: "EmployeesDocument",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesDocument_Employees_EmployeeId",
                table: "EmployeesDocument",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
