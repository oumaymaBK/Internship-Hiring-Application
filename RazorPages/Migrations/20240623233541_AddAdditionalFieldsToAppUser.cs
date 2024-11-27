using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalFieldsToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valid_Projet",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "CVFile",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faculte",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LetterMotivationFile",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Niveau",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVFile",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Faculte",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LetterMotivationFile",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Niveau",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Valid_Projet",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
