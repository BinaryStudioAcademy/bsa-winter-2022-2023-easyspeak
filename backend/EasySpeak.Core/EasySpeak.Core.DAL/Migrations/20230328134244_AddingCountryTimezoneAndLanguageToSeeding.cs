using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class AddingCountryTimezoneAndLanguageToSeeding : Migration
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
                columns: new[] { "Country", "Email", "FirstName", "ImagePath", "Language", "LastName", "Status", "Timezone" },
                values: new object[] { 215, "Georgia_Gorczany76@gmail.com", "Georgia", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/249.jpg", 103, "Gorczany", 1, 197 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Country", "Email", "FirstName", "ImagePath", "Language", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 68, "Jimmy89@hotmail.com", "Jimmy", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/306.jpg", 65, "Fritsch", 1, 2, 6 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Country", "Email", "FirstName", "ImagePath", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 42, "Raquel57@gmail.com", "Raquel", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/667.jpg", 21, 0, "Bartell", 1, 1, 71 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Country", "Email", "FirstName", "ImagePath", "IsSubscribed", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 86, "Kay.Botsford86@yahoo.com", "Kay", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/238.jpg", false, 1, 0, "Botsford", 1, 1, 21 });
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
                columns: new[] { "Country", "Email", "FirstName", "ImagePath", "Language", "LastName", "Status", "Timezone" },
                values: new object[] { 0, "Jon.Abshire@gmail.com", "Jon", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/949.jpg", 0, "Abshire", 3, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Country", "Email", "FirstName", "ImagePath", "Language", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 0, "Kurt.Gulgowski93@gmail.com", "Kurt", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1117.jpg", 0, "Gulgowski", 0, 3, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Country", "Email", "FirstName", "ImagePath", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 0, "Eduardo.Larson@gmail.com", "Eduardo", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1114.jpg", 0, 3, "Larson", 2, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Country", "Email", "FirstName", "ImagePath", "IsSubscribed", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 0, "Francis16@yahoo.com", "Francis", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/607.jpg", true, 0, 3, "Little", 0, 0, 0 });
        }
    }
}
