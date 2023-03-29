using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class AddedTimezoneCountryLanguageSeedingForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Country", "Language", "Status", "Timezone" },
                values: new object[] { 196, 175, 0, 275 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LastName", "Status", "Timezone" },
                values: new object[] { 215, "Georgia_Gorczany76@gmail.com", "Georgia", 103, "Gorczany", 1, 197 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 68, "Jimmy89@hotmail.com", "Jimmy", 65, "Fritsch", 1, 2, 6 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 42, "Raquel57@gmail.com", "Raquel", 21, 0, "Bartell", 1, 1, 71 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Country", "Email", "FirstName", "IsSubscribed", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 86, "Kay.Botsford86@yahoo.com", "Kay", false, 1, 0, "Botsford", 1, 1, 21 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Country", "Language", "Status", "Timezone" },
                values: new object[] { 0, 0, 3, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LastName", "Status", "Timezone" },
                values: new object[] { 0, "Jon.Abshire@gmail.com", "Jon", 0, "Abshire", 3, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 0, "Kurt.Gulgowski93@gmail.com", "Kurt", 0, "Gulgowski", 0, 3, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 0, "Eduardo.Larson@gmail.com", "Eduardo", 0, 2, "Larson", 2, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Country", "Email", "FirstName", "IsSubscribed", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 0, "Francis16@yahoo.com", "Francis", true, 0, 2, "Little", 0, 0, 0 });
        }
    }
}
