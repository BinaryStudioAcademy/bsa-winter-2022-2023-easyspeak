using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class UpdatedUserSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2043));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Country", "Language" },
                values: new object[] { 196, 175 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LastName", "Status" },
                values: new object[] { 215, "Angelo91@gmail.com", "Angelo", 103, "Koepp", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LanguageLevel", "LastName", "Sex" },
                values: new object[] { 4, "Leo_Donnelly24@gmail.com", "Leo", 112, 3, "Donnelly", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Country", "Language", "Status" },
                values: new object[] { 48, 56, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LastName", "Status" },
                values: new object[] { 36, "Yvonne22@gmail.com", "Yvonne", 81, "Kovacek", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 29, 21, 31, 15, 323, DateTimeKind.Local).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Country", "Language" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LastName", "Status" },
                values: new object[] { 0, "Jon.Abshire@gmail.com", "Jon", 0, "Abshire", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LanguageLevel", "LastName", "Sex" },
                values: new object[] { 0, "Kurt.Gulgowski93@gmail.com", "Kurt", 0, 2, "Gulgowski", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Country", "Language", "Status" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Country", "Email", "FirstName", "Language", "LastName", "Status" },
                values: new object[] { 0, "Francis16@yahoo.com", "Francis", 0, "Little", 0 });
        }
    }
}
