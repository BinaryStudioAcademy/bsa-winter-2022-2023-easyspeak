using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class UpdatedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageLevel",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CreatedBy",
                table: "Lessons",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Users_CreatedBy",
                table: "Lessons",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Users_CreatedBy",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_CreatedBy",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LanguageLevel",
                table: "Lessons");
        }
    }
}
