using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SorveSoftApi.Migrations
{
    public partial class CreateTableEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Registration = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Employee", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Employee_Email",
                table: "TB_Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Employee_Registration",
                table: "TB_Employee",
                column: "Registration",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Employee");
        }
    }
}
