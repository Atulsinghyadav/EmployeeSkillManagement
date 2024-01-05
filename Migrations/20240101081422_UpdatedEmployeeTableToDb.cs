using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSkillManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEmployeeTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Employee_EmployeeId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_EmployeeId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Skills");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Skills",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmployeeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmployeeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmployeeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_EmployeeId",
                table: "Skills",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Employee_EmployeeId",
                table: "Skills",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
