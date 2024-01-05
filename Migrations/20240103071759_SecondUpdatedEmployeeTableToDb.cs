using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSkillManagement.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdatedEmployeeTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Employee",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Employee");
        }
    }
}
