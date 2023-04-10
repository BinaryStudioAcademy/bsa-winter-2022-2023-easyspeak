using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class TagSeedingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ArtistPalette.svg", "Arts" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Briefcase.svg", "Business" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClassicalBuilding.svg", "Culture" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "GraduationCap.svg", "Education" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kite.svg", "Environment" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dress.svg", "Fashion" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sandwich.svg", "Food" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dna.svg", "Health" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CrossedSwords.svg" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Books.svg", "Literature" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClapperBoard.svg", "Movies" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drum.svg", "Music" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FourLeafClover.svg", "Nature" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FaceWithMonocle.svg" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TopHat.svg", "Politics" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestTube.svg", "Science" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 17L, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "MobilePhone.svg", "Social Media" },
                    { 18L, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "BoxingGlove.svg", "Storts" },
                    { 19L, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robot.svg", "Technologies" },
                    { 20L, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "DesertIsland.svg", "Travel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Tags");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Architecture" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Arts" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Cars" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Celebrities" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Cooking" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Dancing" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Ecology" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Design" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Fashion" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Medicine" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Technologies" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Pets" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Photography" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2023, 3, 30, 11, 0, 0, 0, DateTimeKind.Utc), "Politics" });
        }
    }
}
