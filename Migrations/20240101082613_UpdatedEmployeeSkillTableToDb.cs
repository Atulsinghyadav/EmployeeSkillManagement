using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSkillManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEmployeeSkillTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Employee_EmployeeId",
                table: "EmployeeSkill");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSkill_EmployeeId",
                table: "EmployeeSkill");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_EmployeeId",
                table: "EmployeeSkill",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Employee_EmployeeId",
                table: "EmployeeSkill",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
