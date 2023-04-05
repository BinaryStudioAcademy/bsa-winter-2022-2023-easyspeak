using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class AddedAdminStatusForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "IsAdmin", "Sex" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Email", "FirstName", "IsAdmin", "LastName" },
                values: new object[] { "Randall_Hegmann56@hotmail.com", "Randall", true, "Hegmann" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Email", "FirstName", "IsAdmin", "LastName", "Sex" },
                values: new object[] { "Alfred89@hotmail.com", "Alfred", true, "Rohan", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Email", "FirstName", "IsAdmin", "LastName", "Sex" },
                values: new object[] { "Sandra57@gmail.com", "Sandra", true, "Satterfield", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Country", "Email", "FirstName", "IsSubscribed", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 236, "Frances.Lemke37@gmail.com", "Frances", true, 55, 3, "Lemke", 2, 3, 175 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Sex",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "Georgia_Gorczany76@gmail.com", "Georgia", "Gorczany" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Email", "FirstName", "LastName", "Sex" },
                values: new object[] { "Jimmy89@hotmail.com", "Jimmy", "Fritsch", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Email", "FirstName", "LastName", "Sex" },
                values: new object[] { "Raquel57@gmail.com", "Raquel", "Bartell", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Country", "Email", "FirstName", "IsSubscribed", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { 86, "Kay.Botsford86@yahoo.com", "Kay", false, 1, 0, "Botsford", 1, 1, 21 });
        }
    }
}
