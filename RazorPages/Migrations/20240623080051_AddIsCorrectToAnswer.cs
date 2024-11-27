using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCorrectToAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
          name: "IsCorrect",
          table: "Answers",
          type: "bit",
          nullable: false,
          defaultValue: false);

            migrationBuilder.DropForeignKey(
             name: "FK_HrInterview_AspNetUsers_UserId",
             table: "HrInterview");

            // Drop the index
            migrationBuilder.DropIndex(
                name: "IX_HrInterview_UserId",
                table: "HrInterview");

            // Alter the column to make it nullable
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HrInterview",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            // Recreate the index
            migrationBuilder.CreateIndex(
                name: "IX_HrInterview_UserId",
                table: "HrInterview",
                column: "UserId");

            // Recreate the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_HrInterview_AspNetUsers_UserId",
                table: "HrInterview",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "IsCorrect",
            table: "Answers");

            migrationBuilder.DropForeignKey(
             name: "FK_HrInterview_AspNetUsers_UserId",
             table: "HrInterview");

            // Drop the index
            migrationBuilder.DropIndex(
                name: "IX_HrInterview_UserId",
                table: "HrInterview");

            // Alter the column to make it not nullable
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "HrInterview",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            // Recreate the index
            migrationBuilder.CreateIndex(
                name: "IX_HrInterview_UserId",
                table: "HrInterview",
                column: "UserId");

            // Recreate the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_HrInterview_AspNetUsers_UserId",
                table: "HrInterview",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
