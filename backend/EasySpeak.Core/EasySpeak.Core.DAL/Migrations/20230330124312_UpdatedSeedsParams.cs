using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class UpdatedSeedsParams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 1L, 2L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 2L, 3L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 2L, 4L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 3L, 5L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 3L, 6L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 4L, 7L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 4L, 8L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 5L, 9L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 5L, 10L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 6L, 11L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 6L, 12L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 7L, 13L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 7L, 14L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 8L, 15L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 8L, 16L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 9L, 17L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 9L, 18L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 10L, 19L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 10L, 20L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 4L, 1L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 7L, 2L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 8L, 2L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 10L, 3L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 11L, 3L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 12L, 3L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 13L, 4L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 14L, 4L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 15L, 4L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 16L, 4L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 17L, 5L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 18L, 5L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 19L, 5L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 20L, 5L });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.InsertData(
                table: "LessonTag",
                columns: new[] { "LessonsId", "TagsId" },
                values: new object[,]
                {
                    { 2L, 2L },
                    { 3L, 3L },
                    { 4L, 4L },
                    { 5L, 5L },
                    { 6L, 6L },
                    { 7L, 7L },
                    { 8L, 8L },
                    { 9L, 9L },
                    { 10L, 10L }
                });

            migrationBuilder.InsertData(
                table: "TagUser",
                columns: new[] { "TagsId", "UsersId" },
                values: new object[,]
                {
                    { 4L, 2L },
                    { 7L, 3L },
                    { 8L, 3L },
                    { 10L, 4L },
                    { 11L, 4L },
                    { 12L, 4L },
                    { 13L, 5L },
                    { 14L, 5L },
                    { 15L, 5L }
                });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 15, 43, 11, 769, DateTimeKind.Local).AddTicks(2010));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 4L, 4L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 5L, 5L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 6L, 6L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 7L, 7L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 8L, 8L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 9L, 9L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 10L, 10L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 4L, 2L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 7L, 3L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 8L, 3L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 10L, 4L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 11L, 4L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 12L, 4L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 13L, 5L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 14L, 5L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 15L, 5L });

            migrationBuilder.InsertData(
                table: "LessonTag",
                columns: new[] { "LessonsId", "TagsId" },
                values: new object[,]
                {
                    { 1L, 2L },
                    { 2L, 3L },
                    { 2L, 4L },
                    { 3L, 5L },
                    { 3L, 6L },
                    { 4L, 7L },
                    { 4L, 8L },
                    { 5L, 9L },
                    { 5L, 10L },
                    { 6L, 11L },
                    { 6L, 12L },
                    { 7L, 13L },
                    { 7L, 14L },
                    { 8L, 15L },
                    { 8L, 16L }
                });

            migrationBuilder.InsertData(
                table: "TagUser",
                columns: new[] { "TagsId", "UsersId" },
                values: new object[,]
                {
                    { 4L, 1L },
                    { 7L, 2L },
                    { 8L, 2L },
                    { 10L, 3L },
                    { 11L, 3L },
                    { 12L, 3L },
                    { 13L, 4L },
                    { 14L, 4L },
                    { 15L, 4L },
                    { 16L, 4L }
                });

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

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 17L, new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2057), "Cats" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 18L, new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2061), "Birds" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 19L, new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2062), "Soccer" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 20L, new DateTime(2023, 3, 30, 15, 23, 55, 994, DateTimeKind.Local).AddTicks(2064), "Basketball" });

            migrationBuilder.InsertData(
                table: "LessonTag",
                columns: new[] { "LessonsId", "TagsId" },
                values: new object[,]
                {
                    { 9L, 17L },
                    { 9L, 18L },
                    { 10L, 19L },
                    { 10L, 20L }
                });

            migrationBuilder.InsertData(
                table: "TagUser",
                columns: new[] { "TagsId", "UsersId" },
                values: new object[,]
                {
                    { 17L, 5L },
                    { 18L, 5L },
                    { 19L, 5L },
                    { 20L, 5L }
                });
        }
    }
}
