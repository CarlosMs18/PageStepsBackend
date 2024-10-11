using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PagePasosBack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionSegundaFase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Provinces_ProvinceId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "Companies",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_ProvinceId",
                table: "Companies",
                newName: "IX_Companies_DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Provinces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_DepartmentId",
                table: "Provinces",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Departments_DepartmentId",
                table: "Companies",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Departments_DepartmentId",
                table: "Provinces",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Departments_DepartmentId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Departments_DepartmentId",
                table: "Provinces");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Provinces_DepartmentId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Provinces");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Companies",
                newName: "ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_DepartmentId",
                table: "Companies",
                newName: "IX_Companies_ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Provinces_ProvinceId",
                table: "Companies",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
