using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class RemovedLessonDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Lessons");

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "LimitOfUsers", "MediaPath", "StartAt" },
                values: new object[] { 150, "https://picsum.photos/640/480/?image=822", new DateTime(2023, 4, 20, 5, 39, 54, 568, DateTimeKind.Utc).AddTicks(9782) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { 139, "https://picsum.photos/640/480/?image=232", "brand", new DateTime(2023, 4, 28, 7, 4, 30, 405, DateTimeKind.Utc).AddTicks(2189) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "MediaPath", "Name", "StartAt" },
                values: new object[] { "https://picsum.photos/640/480/?image=1065", "Oman", new DateTime(2023, 4, 7, 17, 24, 52, 871, DateTimeKind.Utc).AddTicks(8972) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { 143, "https://picsum.photos/640/480/?image=157", "Directives", new DateTime(2023, 4, 8, 12, 1, 17, 422, DateTimeKind.Utc).AddTicks(3002) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "MediaPath", "Name", "StartAt" },
                values: new object[] { "https://picsum.photos/640/480/?image=576", "Platinum", new DateTime(2023, 4, 25, 23, 15, 50, 87, DateTimeKind.Utc).AddTicks(5649) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { null, "https://picsum.photos/640/480/?image=345", "SDD", new DateTime(2023, 4, 6, 15, 15, 36, 36, DateTimeKind.Utc).AddTicks(7593) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { 52, "https://picsum.photos/640/480/?image=60", "complexity", new DateTime(2023, 4, 18, 12, 32, 59, 586, DateTimeKind.Utc).AddTicks(5964) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { 153, "https://picsum.photos/640/480/?image=194", "navigating", new DateTime(2023, 4, 17, 11, 50, 19, 566, DateTimeKind.Utc).AddTicks(9665) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { 180, "https://picsum.photos/640/480/?image=620", "Granite", new DateTime(2023, 4, 6, 5, 31, 35, 722, DateTimeKind.Utc).AddTicks(2772) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { 22, "https://picsum.photos/640/480/?image=75", "olive", new DateTime(2023, 4, 6, 9, 54, 33, 817, DateTimeKind.Utc).AddTicks(7535) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "StartAt" },
                values: new object[] { "Singapore Dollar functionalities Field Branding impactful invoice actuating lavender", 74, "https://picsum.photos/640/480/?image=202", new DateTime(2023, 4, 3, 19, 50, 29, 650, DateTimeKind.Utc).AddTicks(205) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "Thailand budgetary management SDD core Concrete complexity Generic Concrete Shoes navigating plum pixel", 123, "https://picsum.photos/640/480/?image=134", "Palau", new DateTime(2023, 4, 15, 17, 57, 57, 902, DateTimeKind.Utc).AddTicks(9337) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Description", "MediaPath", "Name", "StartAt" },
                values: new object[] { "deposit Advanced input", "https://picsum.photos/640/480/?image=545", "EXE", new DateTime(2023, 4, 3, 23, 3, 18, 306, DateTimeKind.Utc).AddTicks(6493) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "South Carolina Accountability Plastic Health & Home", 59, "https://picsum.photos/640/480/?image=376", "Ville", new DateTime(2023, 4, 1, 19, 45, 38, 148, DateTimeKind.Utc).AddTicks(2420) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Description", "MediaPath", "Name", "StartAt" },
                values: new object[] { "deposit auxiliary Avon Intelligent strategy Forint copy", "https://picsum.photos/640/480/?image=659", "input", new DateTime(2023, 4, 18, 19, 29, 4, 130, DateTimeKind.Utc).AddTicks(7404) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "Awesome Malta indigo XSS Texas interface Israel orchestrate", 139, "https://picsum.photos/640/480/?image=245", "front-end", new DateTime(2023, 4, 1, 0, 33, 57, 99, DateTimeKind.Utc).AddTicks(9638) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "B2C Platinum system bus channels", 133, "https://picsum.photos/640/480/?image=934", "Peso Uruguayo", new DateTime(2023, 4, 16, 11, 19, 31, 565, DateTimeKind.Utc).AddTicks(2009) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "white driver Usability Total Multi-tiered", 142, "https://picsum.photos/640/480/?image=266", "Bedfordshire", new DateTime(2023, 3, 31, 4, 21, 38, 476, DateTimeKind.Utc).AddTicks(9665) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "Multi-tiered hacking Seychelles", 56, "https://picsum.photos/640/480/?image=7", "Music", new DateTime(2023, 4, 9, 2, 18, 12, 41, DateTimeKind.Utc).AddTicks(4570) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "application cross-platform Corners niches bleeding-edge Sleek Frozen Hat 1080p Cambridgeshire dot-com Gorgeous", 29, "https://picsum.photos/640/480/?image=878", "USB", new DateTime(2023, 4, 14, 7, 44, 19, 22, DateTimeKind.Utc).AddTicks(6402) });
        }
    }
}
