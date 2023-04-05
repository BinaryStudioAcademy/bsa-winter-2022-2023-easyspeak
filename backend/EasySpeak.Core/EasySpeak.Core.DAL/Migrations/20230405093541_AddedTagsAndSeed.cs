using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class AddedTagsAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonTag",
                columns: table => new
                {
                    LessonsId = table.Column<long>(type: "bigint", nullable: false),
                    TagsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTag", x => new { x.LessonsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_LessonTag_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagUser",
                columns: table => new
                {
                    TagsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagUser", x => new { x.TagsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TagUser_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6258), "ClassicalBuilding.svg", "Architecture" },
                    { 2L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6300), "ArtistPalette.svg", "Arts" },
                    { 3L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6303), "RacingCar.svg", "Cars" },
                    { 4L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6306), "Crown.svg", "Celebrities" },
                    { 5L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6309), "Cook.svg", "Cooking" },
                    { 6L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6314), "WomanDancing.svg", "Dancing" },
                    { 7L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6317), "FourLeafClover.svg", "Ecology" },
                    { 8L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6320), "Artist.svg", "Design" },
                    { 9L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6323), "CrossedSwords.svg", "History" },
                    { 10L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6365), "Dress.svg", "Fashion" },
                    { 11L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6368), "Pill.svg", "Medicine" },
                    { 12L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6371), "Robot.svg", "Technologies" },
                    { 13L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6374), "DogFace.svg", "Pets" },
                    { 14L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6377), "FaceWithMonocle.svg", "Philosophy" },
                    { 15L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6380), "Camera.svg", "Photography" },
                    { 16L, new DateTime(2023, 4, 5, 12, 35, 40, 127, DateTimeKind.Local).AddTicks(6383), "TopHat.svg", "Politics" }
                });

            migrationBuilder.InsertData(
                table: "LessonTag",
                columns: new[] { "LessonsId", "TagsId" },
                values: new object[,]
                {
                    { 1L, 1L },
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
                    { 1L, 1L },
                    { 2L, 1L },
                    { 3L, 2L },
                    { 4L, 2L },
                    { 5L, 3L },
                    { 6L, 3L },
                    { 7L, 4L },
                    { 8L, 4L },
                    { 9L, 5L },
                    { 10L, 5L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonTag_TagsId",
                table: "LessonTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_TagUser_UsersId",
                table: "TagUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonTag");

            migrationBuilder.DropTable(
                name: "TagUser");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
