using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityAPI.Migrations
{
    /// <inheritdoc />
    public partial class Modified2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Courses_CourseID",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Professors_ProfessorID",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_CourseID",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_ProfessorID",
                table: "Sections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseID",
                table: "Sections",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ProfessorID",
                table: "Sections",
                column: "ProfessorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Courses_CourseID",
                table: "Sections",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Professors_ProfessorID",
                table: "Sections",
                column: "ProfessorID",
                principalTable: "Professors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
