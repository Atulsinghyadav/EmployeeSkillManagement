using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeSkillManagement.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DOJ = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillId = table.Column<int>(type: "INTEGER", nullable: true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Expert_Level = table.Column<string>(type: "TEXT", nullable: false),
                    Experience = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillName = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "EmployeeId", "SkillName" },
                values: new object[,]
                {
                    { 1, null, "Java" },
                    { 2, null, "React" },
                    { 3, null, "C++" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_EmployeeId",
                table: "EmployeeSkill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_EmployeeId",
                table: "Skills",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSkill");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
