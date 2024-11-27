using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class UpdateValidate2Property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
             name: "Valid_Projet",
             table: "Project",
             type: "nvarchar(450)",
             nullable: true,
             defaultValue: "nv",
             oldClrType: typeof(int),
             oldType: "int",
             oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
             name: "Valid_Projet",
             table: "Project",
             type: "int",
             nullable: true,
             oldClrType: typeof(string),
             oldType: "nvarchar(450)",
             oldNullable: true);
        }
    }
}
