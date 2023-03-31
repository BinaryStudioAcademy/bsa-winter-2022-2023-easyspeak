using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class UpdateLessonFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YoutubeVideoId",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZoomMeetingLink",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "YoutubeVideoId", "ZoomMeetingLink" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "YoutubeVideoId", "ZoomMeetingLink" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "YoutubeVideoId", "ZoomMeetingLink" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "YoutubeVideoId", "ZoomMeetingLink" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "YoutubeVideoId", "ZoomMeetingLink" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "YoutubeVideoId", "ZoomMeetingLink" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "YoutubeVideoId", "ZoomMeetingLink" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "YoutubeVideoId", "ZoomMeetingLink" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "YoutubeVideoId", "ZoomMeetingLink" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "YoutubeVideoId", "ZoomMeetingLink" },
                values: new object[] { "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YoutubeVideoId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ZoomMeetingLink",
                table: "Lessons");
        }
    }
}
