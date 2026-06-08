using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoissaHR.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employments_CompanyId",
                table: "Employments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_CompanyId",
                table: "Absences",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Companies_CompanyId",
                table: "Absences",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Companies_CompanyId",
                table: "Employments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Companies_CompanyId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Companies_CompanyId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_CompanyId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Absences_CompanyId",
                table: "Absences");
        }
    }
}
