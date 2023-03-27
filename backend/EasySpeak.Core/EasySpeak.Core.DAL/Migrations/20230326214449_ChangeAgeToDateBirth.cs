using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class ChangeAgeToDateBirth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "LanguageLevel", "Sex" },
                values: new object[] { new DateTime(2003, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BirthDate", "Email", "FirstName", "ImagePath", "LanguageLevel", "LastName", "Sex", "Status" },
                values: new object[] { new DateTime(2003, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jon.Abshire@gmail.com", "Jon", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/949.jpg", 1, "Abshire", 1, 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "BirthDate", "Email", "FirstName", "ImagePath", "IsBanned", "LanguageLevel", "LastName", "Sex", "Status" },
                values: new object[] { new DateTime(2003, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kurt.Gulgowski93@gmail.com", "Kurt", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1117.jpg", false, 3, "Gulgowski", 0, 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "BirthDate", "Email", "FirstName", "ImagePath", "LanguageLevel", "LastName", "Sex", "Status" },
                values: new object[] { new DateTime(2003, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduardo.Larson@gmail.com", "Eduardo", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1114.jpg", 3, "Larson", 2, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "BirthDate", "Email", "FirstName", "ImagePath", "LanguageLevel", "LastName", "Sex", "Status" },
                values: new object[] { new DateTime(2003, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Francis16@yahoo.com", "Francis", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/607.jpg", 3, "Little", 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Users");

            migrationBuilder.AddColumn<short>(
                name: "Age",
                table: "Users",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Age", "LanguageLevel", "Sex" },
                values: new object[] { (short)30, 4, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Age", "Email", "FirstName", "ImagePath", "LanguageLevel", "LastName", "Sex", "Status" },
                values: new object[] { (short)57, "Robert21@yahoo.com", "Robert", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/957.jpg", 2, "O'Hara", 2, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Age", "Email", "FirstName", "ImagePath", "IsBanned", "LanguageLevel", "LastName", "Sex", "Status" },
                values: new object[] { (short)16, "Rhonda74@gmail.com", "Rhonda", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1199.jpg", true, 4, "Kunze", 1, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Age", "Email", "FirstName", "ImagePath", "LanguageLevel", "LastName", "Sex", "Status" },
                values: new object[] { (short)57, "Myrtle70@yahoo.com", "Myrtle", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/37.jpg", 1, "Glover", 1, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Age", "Email", "FirstName", "ImagePath", "LanguageLevel", "LastName", "Sex", "Status" },
                values: new object[] { (short)18, "Ivan11@gmail.com", "Ivan", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/610.jpg", 0, "Heidenreich", 1, 1 });
        }
    }
}
