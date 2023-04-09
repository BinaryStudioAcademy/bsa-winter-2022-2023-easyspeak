using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class AddedCanceledFlagToLessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Lessons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "SQL Fresh Incredible Customer-focused orange green", 109, "https://picsum.photos/640/480/?image=689", "Platinum", new DateTime(2023, 4, 4, 22, 6, 13, 828, DateTimeKind.Utc).AddTicks(8633) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "Checking Account New Hampshire Team-oriented Congo deposit Advanced input Cameroon", 123, "https://picsum.photos/640/480/?image=86", "plum", new DateTime(2023, 4, 1, 22, 15, 56, 445, DateTimeKind.Utc).AddTicks(7397) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "GB ability withdrawal even-keeled Intelligent Legacy quantify deposit auxiliary Avon", 73, "https://picsum.photos/640/480/?image=89", "South Carolina", new DateTime(2023, 4, 4, 23, 2, 56, 189, DateTimeKind.Utc).AddTicks(4085) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Description", "MediaPath", "Name", "StartAt" },
                values: new object[] { "Credit Card Account Avon front-end Bahraini Dinar", "https://picsum.photos/640/480/?image=623", "enterprise", new DateTime(2023, 4, 15, 1, 53, 36, 100, DateTimeKind.Utc).AddTicks(8801) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "calculating synthesize Islands Intelligent Steel Tuna SMTP indexing", 146, "https://picsum.photos/640/480/?image=353", "XSS", new DateTime(2023, 4, 8, 16, 13, 58, 711, DateTimeKind.Utc).AddTicks(2243) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "channels COM Money Market Account Bedfordshire mission-critical Reduced Industrial, Computers & Outdoors Multi-tiered Ameliorated", 22, "https://picsum.photos/640/480/?image=737", "Shoals", new DateTime(2023, 4, 20, 12, 13, 26, 410, DateTimeKind.Utc).AddTicks(7424) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "hacking Seychelles Electronics invoice circuit application", null, "https://picsum.photos/640/480/?image=352", "white", new DateTime(2023, 4, 19, 22, 34, 30, 975, DateTimeKind.Utc).AddTicks(3618) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "Sleek Frozen Hat 1080p Cambridgeshire dot-com Gorgeous online", null, "https://picsum.photos/640/480/?image=54", "harness", new DateTime(2023, 4, 21, 22, 42, 52, 795, DateTimeKind.Utc).AddTicks(8548) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "Borders Estonia", null, "https://picsum.photos/640/480/?image=384", "quantify", new DateTime(2023, 3, 31, 0, 38, 55, 435, DateTimeKind.Utc).AddTicks(3806) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Lessons");

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
                columns: new[] { "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[] { "deposit Advanced input", null, "https://picsum.photos/640/480/?image=545", "EXE", new DateTime(2023, 4, 3, 23, 3, 18, 306, DateTimeKind.Utc).AddTicks(6493) });

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
