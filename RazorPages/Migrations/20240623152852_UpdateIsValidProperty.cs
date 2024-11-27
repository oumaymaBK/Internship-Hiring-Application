using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIsValidProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<bool>(
                name: "IsValid",
                table: "Project",
                type: "bit", // Depending on your database provider, this might vary
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
        name: "IsValid",
        table: "Project",
        type: "int",
        nullable: false,
        oldClrType: typeof(bool),
        oldType: "bit");
        }
    }
}
