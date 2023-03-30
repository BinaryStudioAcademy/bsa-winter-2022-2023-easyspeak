using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class Updateseedstags : Migration
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
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4737), "Architecture" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4783), "Arts" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4787), "Cars" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4790), "Celebrities" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4793), "Cooking" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4799), "Dancing" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4804), "Ecology" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4806), "Design" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4810), "History" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4814), "Fashion" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4818), "Medicine" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4821), "Technologies" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4825), "Pets" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4828), "Philosophy" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4831), "Photography" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 22, 46, 38, 684, DateTimeKind.Local).AddTicks(4834), "Politics" });
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
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobility" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "synthesize" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "card" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "brand" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Versatile" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "withdrawal" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oman" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engineer" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intelligent Frozen Mouse" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incredible Metal Hat" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Platinum" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thailand" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "budgetary management" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SDD" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "core" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concrete" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "complexity" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Generic Concrete Shoes" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "navigating" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "plum" });

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
