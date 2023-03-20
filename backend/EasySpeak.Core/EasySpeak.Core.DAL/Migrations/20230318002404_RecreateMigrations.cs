using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class RecreateMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LimitOfUsers = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Timezone = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<short>(type: "smallint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    LanguageLevel = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsSubscribed = table.Column<bool>(type: "bit", nullable: false),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<long>(type: "bigint", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calls_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<long>(type: "bigint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ChatUser",
                columns: table => new
                {
                    ChatsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUser", x => new { x.ChatsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ChatUser_Chats_ChatsId",
                        column: x => x.ChatsId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RequesterId = table.Column<long>(type: "bigint", nullable: false),
                    FriendshipStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonUser",
                columns: table => new
                {
                    LessonsId = table.Column<long>(type: "bigint", nullable: false),
                    SubscribersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonUser", x => new { x.LessonsId, x.SubscribersId });
                    table.ForeignKey(
                        name: "FK_LessonUser_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonUser_Users_SubscribersId",
                        column: x => x.SubscribersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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

            migrationBuilder.CreateTable(
                name: "Subquestions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subquestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subquestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "input Singapore Dollar functionalities" },
                    { 2L, "Versatile withdrawal" },
                    { 3L, "invoice actuating" },
                    { 4L, "Directives" },
                    { 5L, "neural-net" },
                    { 6L, "Platinum Thailand" },
                    { 7L, "Fresh" },
                    { 8L, "core" },
                    { 9L, "orange" },
                    { 10L, "Generic Concrete Shoes" },
                    { 11L, "channels Run Checking Account" },
                    { 12L, "Flat EXE" },
                    { 13L, "deposit" },
                    { 14L, "Shoes, Beauty & Games" },
                    { 15L, "Awesome" },
                    { 16L, "interactive parse GB" },
                    { 17L, "Health & Home" },
                    { 18L, "Intelligent Legacy" },
                    { 19L, "North Carolina indigo Sleek Wooden Car" },
                    { 20L, "strategy" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[,]
                {
                    { 1L, null, "Singapore Dollar functionalities Field Branding impactful invoice actuating lavender", 74, "https://picsum.photos/640/480/?image=202", "Mobility", new DateTime(2023, 4, 3, 19, 50, 29, 650, DateTimeKind.Utc).AddTicks(205) },
                    { 2L, null, "Thailand budgetary management SDD core Concrete complexity Generic Concrete Shoes navigating plum pixel", 123, "https://picsum.photos/640/480/?image=134", "Palau", new DateTime(2023, 4, 15, 17, 57, 57, 902, DateTimeKind.Utc).AddTicks(9337) },
                    { 3L, null, "deposit Advanced input", null, "https://picsum.photos/640/480/?image=545", "EXE", new DateTime(2023, 4, 3, 23, 3, 18, 306, DateTimeKind.Utc).AddTicks(6493) },
                    { 4L, null, "South Carolina Accountability Plastic Health & Home", 59, "https://picsum.photos/640/480/?image=376", "Ville", new DateTime(2023, 4, 1, 19, 45, 38, 148, DateTimeKind.Utc).AddTicks(2420) },
                    { 5L, null, "deposit auxiliary Avon Intelligent strategy Forint copy", null, "https://picsum.photos/640/480/?image=659", "input", new DateTime(2023, 4, 18, 19, 29, 4, 130, DateTimeKind.Utc).AddTicks(7404) },
                    { 6L, null, "Awesome Malta indigo XSS Texas interface Israel orchestrate", 139, "https://picsum.photos/640/480/?image=245", "front-end", new DateTime(2023, 4, 1, 0, 33, 57, 99, DateTimeKind.Utc).AddTicks(9638) },
                    { 7L, null, "B2C Platinum system bus channels", 133, "https://picsum.photos/640/480/?image=934", "Peso Uruguayo", new DateTime(2023, 4, 16, 11, 19, 31, 565, DateTimeKind.Utc).AddTicks(2009) },
                    { 8L, null, "white driver Usability Total Multi-tiered", 142, "https://picsum.photos/640/480/?image=266", "Bedfordshire", new DateTime(2023, 3, 31, 4, 21, 38, 476, DateTimeKind.Utc).AddTicks(9665) },
                    { 9L, null, "Multi-tiered hacking Seychelles", 56, "https://picsum.photos/640/480/?image=7", "Music", new DateTime(2023, 4, 9, 2, 18, 12, 41, DateTimeKind.Utc).AddTicks(4570) },
                    { 10L, null, "application cross-platform Corners niches bleeding-edge Sleek Frozen Hat 1080p Cambridgeshire dot-com Gorgeous", 29, "https://picsum.photos/640/480/?image=878", "USB", new DateTime(2023, 4, 14, 7, 44, 19, 22, DateTimeKind.Utc).AddTicks(6402) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Mobility" },
                    { 2L, "synthesize" },
                    { 3L, "card" },
                    { 4L, "brand" },
                    { 5L, "Versatile" },
                    { 6L, "withdrawal" },
                    { 7L, "Oman" },
                    { 8L, "Engineer" },
                    { 9L, "Intelligent Frozen Mouse" },
                    { 10L, "Incredible Metal Hat" },
                    { 11L, "Platinum" },
                    { 12L, "Thailand" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 13L, "budgetary management" },
                    { 14L, "SDD" },
                    { 15L, "core" },
                    { 16L, "Concrete" },
                    { 17L, "complexity" },
                    { 18L, "Generic Concrete Shoes" },
                    { 19L, "navigating" },
                    { 20L, "plum" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Country", "Email", "FirstName", "ImagePath", "IsBanned", "IsSubscribed", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[,]
                {
                    { 1L, (short)30, 0, "Della.Rosenbaum@yahoo.com", "Della", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/343.jpg", false, true, 0, 4, "Rosenbaum", 1, 3, 0 },
                    { 2L, (short)57, 0, "Robert21@yahoo.com", "Robert", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/957.jpg", false, true, 0, 2, "O'Hara", 2, 0, 0 },
                    { 3L, (short)16, 0, "Rhonda74@gmail.com", "Rhonda", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1199.jpg", true, true, 0, 4, "Kunze", 1, 2, 0 },
                    { 4L, (short)57, 0, "Myrtle70@yahoo.com", "Myrtle", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/37.jpg", false, true, 0, 1, "Glover", 1, 1, 0 },
                    { 5L, (short)18, 0, "Ivan11@gmail.com", "Ivan", "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/610.jpg", false, true, 0, 0, "Heidenreich", 1, 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Calls",
                columns: new[] { "Id", "ChatId", "CreatedAt", "CreatedBy", "FinishedAt", "StartedAt" },
                values: new object[,]
                {
                    { 1L, 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 14, 26, 33, 434, DateTimeKind.Utc).AddTicks(5987), new DateTime(2023, 3, 29, 12, 11, 17, 110, DateTimeKind.Utc).AddTicks(154) },
                    { 2L, 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 18, 35, 31, 975, DateTimeKind.Utc).AddTicks(2388), new DateTime(2023, 3, 29, 17, 41, 55, 56, DateTimeKind.Utc).AddTicks(3352) },
                    { 3L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 8, 43, 49, 598, DateTimeKind.Utc).AddTicks(8592), new DateTime(2023, 3, 30, 5, 50, 48, 472, DateTimeKind.Utc).AddTicks(1708) },
                    { 4L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 0, 50, 38, 838, DateTimeKind.Utc).AddTicks(6265), new DateTime(2023, 3, 29, 22, 49, 40, 541, DateTimeKind.Utc).AddTicks(2595) },
                    { 5L, 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 10, 0, 10, 657, DateTimeKind.Utc).AddTicks(9051), new DateTime(2023, 3, 30, 9, 25, 0, 982, DateTimeKind.Utc).AddTicks(1061) },
                    { 6L, 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 8, 24, 34, 334, DateTimeKind.Utc).AddTicks(2589), new DateTime(2023, 3, 30, 7, 30, 19, 11, DateTimeKind.Utc).AddTicks(6660) },
                    { 7L, 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 21, 33, 15, 710, DateTimeKind.Utc).AddTicks(304), new DateTime(2023, 3, 29, 18, 40, 48, 76, DateTimeKind.Utc).AddTicks(1597) },
                    { 8L, 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 3, 59, 21, 941, DateTimeKind.Utc).AddTicks(1908), new DateTime(2023, 3, 30, 3, 35, 7, 117, DateTimeKind.Utc).AddTicks(9355) },
                    { 9L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2023, 3, 30, 3, 21, 29, 243, DateTimeKind.Utc).AddTicks(7956) },
                    { 10L, 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2023, 3, 30, 3, 28, 0, 132, DateTimeKind.Utc).AddTicks(5627) },
                    { 11L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 8, 6, 45, 16, DateTimeKind.Utc).AddTicks(6326), new DateTime(2023, 3, 30, 6, 37, 47, 539, DateTimeKind.Utc).AddTicks(379) },
                    { 12L, 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 8, 29, 47, 433, DateTimeKind.Utc).AddTicks(9991), new DateTime(2023, 3, 30, 6, 41, 34, 852, DateTimeKind.Utc).AddTicks(4701) },
                    { 13L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 9, 39, 31, 443, DateTimeKind.Utc).AddTicks(6), new DateTime(2023, 3, 30, 8, 1, 46, 951, DateTimeKind.Utc).AddTicks(7384) },
                    { 14L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 15, 16, 40, 720, DateTimeKind.Utc).AddTicks(2498), new DateTime(2023, 3, 29, 13, 42, 8, 158, DateTimeKind.Utc).AddTicks(7855) },
                    { 15L, 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2023, 3, 30, 9, 19, 50, 80, DateTimeKind.Utc).AddTicks(2316) },
                    { 16L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 18, 7, 12, 46, DateTimeKind.Utc).AddTicks(5688), new DateTime(2023, 3, 29, 16, 36, 40, 789, DateTimeKind.Utc).AddTicks(6145) },
                    { 17L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 10, 44, 23, 732, DateTimeKind.Utc).AddTicks(9797), new DateTime(2023, 3, 30, 9, 1, 28, 118, DateTimeKind.Utc).AddTicks(4753) },
                    { 18L, 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 0, 27, 16, 695, DateTimeKind.Utc).AddTicks(9697), new DateTime(2023, 3, 29, 22, 5, 53, 13, DateTimeKind.Utc).AddTicks(4864) },
                    { 19L, 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2023, 3, 30, 7, 38, 51, 698, DateTimeKind.Utc).AddTicks(3241) },
                    { 20L, 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 0, 46, 0, 211, DateTimeKind.Utc).AddTicks(1848), new DateTime(2023, 3, 29, 23, 56, 10, 114, DateTimeKind.Utc).AddTicks(6730) },
                    { 21L, 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 8, 30, 13, 61, DateTimeKind.Utc).AddTicks(3295), new DateTime(2023, 3, 30, 5, 45, 0, 815, DateTimeKind.Utc).AddTicks(2755) },
                    { 22L, 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 23, 27, 4, 960, DateTimeKind.Utc).AddTicks(7554), new DateTime(2023, 3, 29, 21, 29, 30, 718, DateTimeKind.Utc).AddTicks(1004) },
                    { 23L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2023, 3, 30, 9, 59, 27, 748, DateTimeKind.Utc).AddTicks(5673) },
                    { 24L, 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 7, 28, 37, 281, DateTimeKind.Utc).AddTicks(218), new DateTime(2023, 3, 30, 6, 35, 54, 127, DateTimeKind.Utc).AddTicks(197) },
                    { 25L, 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 5, 1, 19, 258, DateTimeKind.Utc).AddTicks(6679), new DateTime(2023, 3, 30, 2, 44, 26, 789, DateTimeKind.Utc).AddTicks(4642) },
                    { 26L, 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2023, 3, 29, 19, 31, 1, 862, DateTimeKind.Utc).AddTicks(3087) },
                    { 27L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2023, 3, 29, 21, 2, 53, 964, DateTimeKind.Utc).AddTicks(8615) },
                    { 28L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 0, 8, 27, 519, DateTimeKind.Utc).AddTicks(4143), new DateTime(2023, 3, 29, 22, 30, 12, 796, DateTimeKind.Utc).AddTicks(6373) },
                    { 29L, 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 16, 33, 23, 960, DateTimeKind.Utc).AddTicks(292), new DateTime(2023, 3, 29, 13, 45, 19, 382, DateTimeKind.Utc).AddTicks(895) },
                    { 30L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 18, 19, 17, 272, DateTimeKind.Utc).AddTicks(9714), new DateTime(2023, 3, 29, 17, 10, 8, 565, DateTimeKind.Utc).AddTicks(6895) },
                    { 31L, 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 2, 33, 53, 237, DateTimeKind.Utc).AddTicks(1168), new DateTime(2023, 3, 30, 2, 4, 34, 205, DateTimeKind.Utc).AddTicks(8604) },
                    { 32L, 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 21, 49, 44, 615, DateTimeKind.Utc).AddTicks(1025), new DateTime(2023, 3, 29, 19, 11, 24, 720, DateTimeKind.Utc).AddTicks(7549) },
                    { 33L, 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 1, 20, 29, 357, DateTimeKind.Utc).AddTicks(3354), new DateTime(2023, 3, 30, 0, 21, 55, 496, DateTimeKind.Utc).AddTicks(9574) },
                    { 34L, 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 14, 19, 8, 285, DateTimeKind.Utc).AddTicks(9166), new DateTime(2023, 3, 29, 12, 6, 7, 251, DateTimeKind.Utc).AddTicks(1849) },
                    { 35L, 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 16, 4, 7, 596, DateTimeKind.Utc).AddTicks(5818), new DateTime(2023, 3, 29, 14, 48, 13, 217, DateTimeKind.Utc).AddTicks(4657) },
                    { 36L, 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 23, 15, 50, 767, DateTimeKind.Utc).AddTicks(7714), new DateTime(2023, 3, 29, 21, 23, 20, 947, DateTimeKind.Utc).AddTicks(8266) },
                    { 37L, 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 4, 51, 59, 469, DateTimeKind.Utc).AddTicks(8512), new DateTime(2023, 3, 30, 3, 51, 51, 340, DateTimeKind.Utc).AddTicks(7328) },
                    { 38L, 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 29, 17, 5, 25, 147, DateTimeKind.Utc).AddTicks(6934), new DateTime(2023, 3, 29, 17, 1, 39, 455, DateTimeKind.Utc).AddTicks(9583) },
                    { 39L, 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 7, 50, 35, 166, DateTimeKind.Utc).AddTicks(6321), new DateTime(2023, 3, 30, 5, 9, 43, 906, DateTimeKind.Utc).AddTicks(2578) },
                    { 40L, 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 3, 30, 5, 10, 42, 787, DateTimeKind.Utc).AddTicks(6775), new DateTime(2023, 3, 30, 5, 6, 22, 377, DateTimeKind.Utc).AddTicks(3568) }
                });

            migrationBuilder.InsertData(
                table: "ChatUser",
                columns: new[] { "ChatsId", "UsersId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L }
                });

            migrationBuilder.InsertData(
                table: "ChatUser",
                columns: new[] { "ChatsId", "UsersId" },
                values: new object[,]
                {
                    { 3L, 1L },
                    { 4L, 1L },
                    { 5L, 2L },
                    { 6L, 2L },
                    { 7L, 2L },
                    { 8L, 2L },
                    { 9L, 3L },
                    { 10L, 3L },
                    { 11L, 3L },
                    { 12L, 3L },
                    { 13L, 4L },
                    { 14L, 4L },
                    { 15L, 4L },
                    { 16L, 4L },
                    { 17L, 5L },
                    { 18L, 5L },
                    { 19L, 5L },
                    { 20L, 5L }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "FriendshipStatus", "RequesterId", "UserId" },
                values: new object[,]
                {
                    { 1L, 2, 4L, 3L },
                    { 2L, 2, 5L, 1L },
                    { 3L, 2, 3L, 2L },
                    { 4L, 2, 2L, 4L },
                    { 5L, 2, 4L, 3L },
                    { 6L, 0, 1L, 3L },
                    { 7L, 1, 1L, 5L },
                    { 8L, 1, 2L, 1L },
                    { 9L, 0, 1L, 2L },
                    { 10L, 2, 2L, 2L },
                    { 11L, 1, 3L, 5L },
                    { 12L, 0, 3L, 2L },
                    { 13L, 1, 4L, 4L },
                    { 14L, 2, 2L, 5L },
                    { 15L, 2, 2L, 5L },
                    { 16L, 0, 5L, 1L },
                    { 17L, 0, 4L, 3L },
                    { 18L, 0, 5L, 2L },
                    { 19L, 2, 3L, 1L },
                    { 20L, 0, 2L, 5L }
                });

            migrationBuilder.InsertData(
                table: "LessonTag",
                columns: new[] { "LessonsId", "TagsId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 1L, 2L },
                    { 2L, 3L },
                    { 2L, 4L }
                });

            migrationBuilder.InsertData(
                table: "LessonTag",
                columns: new[] { "LessonsId", "TagsId" },
                values: new object[,]
                {
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
                    { 8L, 16L },
                    { 9L, 17L },
                    { 9L, 18L },
                    { 10L, 19L },
                    { 10L, 20L }
                });

            migrationBuilder.InsertData(
                table: "LessonUser",
                columns: new[] { "LessonsId", "SubscribersId" },
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

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "CreatedAt", "CreatedBy", "IsDeleted", "Text" },
                values: new object[,]
                {
                    { 1L, 16L, new DateTime(2023, 3, 26, 23, 58, 21, 254, DateTimeKind.Utc).AddTicks(6980), null, false, "input Singapore Dollar functionalities Field Branding impactful invoice actuating lavender purple neural-net Palau Operations SQL Fresh Incredible Customer-focused orange green Savings Account" },
                    { 2L, 17L, new DateTime(2023, 3, 26, 18, 45, 36, 557, DateTimeKind.Utc).AddTicks(9989), null, false, "Run Checking Account New Hampshire Team-oriented" },
                    { 3L, 19L, new DateTime(2023, 3, 26, 22, 30, 49, 610, DateTimeKind.Utc).AddTicks(5596), null, false, "Advanced input" },
                    { 4L, 17L, new DateTime(2023, 3, 24, 23, 1, 53, 780, DateTimeKind.Utc).AddTicks(9359), null, false, "Ville interactive" },
                    { 5L, 14L, new DateTime(2023, 3, 29, 21, 45, 21, 98, DateTimeKind.Utc).AddTicks(7435), null, false, "ability withdrawal even-keeled" },
                    { 6L, 2L, new DateTime(2023, 3, 24, 12, 28, 11, 306, DateTimeKind.Utc).AddTicks(3253), null, false, "quantify deposit auxiliary Avon Intelligent strategy Forint copy Credit Card Account Avon front-end Bahraini Dinar Mount Georgia optical Infrastructure" },
                    { 7L, 16L, new DateTime(2023, 3, 26, 23, 37, 58, 715, DateTimeKind.Utc).AddTicks(4827), null, false, "Islands Intelligent Steel Tuna SMTP indexing B2C Platinum system bus channels COM Money Market Account" },
                    { 8L, 19L, new DateTime(2023, 3, 25, 16, 50, 41, 835, DateTimeKind.Utc).AddTicks(9482), null, false, "Reduced Industrial, Computers & Outdoors Multi-tiered Ameliorated" },
                    { 9L, 17L, new DateTime(2023, 3, 25, 20, 45, 10, 973, DateTimeKind.Utc).AddTicks(6040), null, false, "Concrete Multi-tiered hacking Seychelles Electronics" },
                    { 10L, 4L, new DateTime(2023, 3, 25, 11, 46, 20, 369, DateTimeKind.Utc).AddTicks(685), null, false, "application cross-platform Corners niches bleeding-edge Sleek Frozen Hat 1080p Cambridgeshire dot-com Gorgeous online Handmade Frozen Chair Auto Loan Account Burgs Borders Estonia value-added Crossing" },
                    { 11L, 15L, new DateTime(2023, 3, 26, 14, 50, 26, 296, DateTimeKind.Utc).AddTicks(7278), null, false, "calculate" },
                    { 12L, 20L, new DateTime(2023, 3, 25, 10, 29, 35, 692, DateTimeKind.Utc).AddTicks(6543), null, false, "transmitter Egypt online Creative Credit Card Account Fantastic Soft Soap TCP Industrial & Toys brand client-server compress drive" },
                    { 13L, 17L, new DateTime(2023, 3, 27, 0, 53, 3, 699, DateTimeKind.Utc).AddTicks(2571), null, false, "backing up Licensed Granite Bike back up back-end e-enable Specialist Games alarm orange Savings Account interactive web-enabled Colorado Ergonomic Concrete Shoes" },
                    { 14L, 17L, new DateTime(2023, 3, 26, 21, 52, 39, 39, DateTimeKind.Utc).AddTicks(760), null, false, "Awesome quantify Integration SDD reinvent Bedfordshire Generic Frozen Cheese Electronics & Sports open-source Licensed Concrete Sausages Practical Wooden Shirt" },
                    { 15L, 9L, new DateTime(2023, 3, 26, 20, 35, 54, 517, DateTimeKind.Utc).AddTicks(2778), null, false, "Intelligent Fresh Soap strategize e-business Rustic Frozen Gloves Awesome Wooden Table Avon functionalities program implement clicks-and-mortar Practical Frozen Chips Syrian Pound Paradigm Pennsylvania Markets Consultant" },
                    { 16L, 19L, new DateTime(2023, 3, 26, 15, 25, 37, 728, DateTimeKind.Utc).AddTicks(3260), null, false, "reboot Investor non-volatile Identity Graphic Interface Sports compressing facilitate AGP turquoise Grass-roots matrix relationships Rustic Rubber Shirt Soft enhance partnerships Estate green hierarchy" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "CreatedAt", "CreatedBy", "IsDeleted", "Text" },
                values: new object[,]
                {
                    { 17L, 4L, new DateTime(2023, 3, 25, 15, 47, 35, 138, DateTimeKind.Utc).AddTicks(1191), null, false, "Rustic Investment Account Money Market Account EXE New Hampshire Generic Fresh Mouse CSS Armenian Dram AI Pine compressing International Rustic Wooden Cheese online Investment Account experiences Idaho application Human" },
                    { 18L, 6L, new DateTime(2023, 3, 27, 15, 29, 43, 577, DateTimeKind.Utc).AddTicks(2038), null, true, "workforce yellow generate web services Berkshire frame Uganda paradigm drive synthesize Coordinator reboot withdrawal asynchronous Borders Lead approach" },
                    { 19L, 17L, new DateTime(2023, 3, 25, 12, 51, 44, 274, DateTimeKind.Utc).AddTicks(6024), null, true, "Books" },
                    { 20L, 8L, new DateTime(2023, 3, 28, 3, 54, 37, 636, DateTimeKind.Utc).AddTicks(691), null, false, "magenta online tan Senior static Dynamic Multi-channelled database bleeding-edge COM actuating Mountain Re-engineered" },
                    { 21L, 12L, new DateTime(2023, 3, 26, 18, 43, 33, 844, DateTimeKind.Utc).AddTicks(4821), null, false, "exuding compressing Buckinghamshire Pines asymmetric Books, Electronics & Health calculating Road Handmade Concrete Keyboard viral Concrete data-warehouse Bedfordshire Generic Rubber Towels" },
                    { 22L, 19L, new DateTime(2023, 3, 28, 15, 5, 23, 276, DateTimeKind.Utc).AddTicks(3731), null, false, "South Carolina microchip multi-byte value-added Assimilated implement protocol Villages Beauty National Avon wireless Internal bleeding-edge invoice Buckinghamshire Savings Account Visionary Incredible Soft Chair Small" },
                    { 23L, 19L, new DateTime(2023, 3, 29, 13, 16, 32, 28, DateTimeKind.Utc).AddTicks(7141), null, false, "Rustic Home Loan Account systemic Movies & Baby seize USB Planner Center Future" },
                    { 24L, 2L, new DateTime(2023, 3, 30, 4, 1, 11, 490, DateTimeKind.Utc).AddTicks(988), null, false, "Factors circuit grid-enabled Central interactive microchip primary Nepalese Rupee matrix Generic Credit Card Account Burg Health & Electronics Manager conglomeration Technician Inlet Wooden benchmark capacitor" },
                    { 25L, 17L, new DateTime(2023, 3, 24, 14, 51, 7, 944, DateTimeKind.Utc).AddTicks(8222), null, false, "connect envisioneer Burkina Faso multi-byte B2B Buckinghamshire USB Developer Avon sky blue yellow Grenada Borders Investment Account SMTP Checking Account Intelligent Soft Chips" },
                    { 26L, 7L, new DateTime(2023, 3, 25, 23, 53, 31, 897, DateTimeKind.Utc).AddTicks(640), null, true, "portals B2C ADP motivating" },
                    { 27L, 18L, new DateTime(2023, 3, 30, 8, 52, 26, 964, DateTimeKind.Utc).AddTicks(4600), null, false, "Multi-channelled Credit Card Account Supervisor programming French Southern Territories feed Investment Account payment Strategist IB synergies Refined digital Avon website transmitting Re-contextualized multi-byte Colorado" },
                    { 28L, 8L, new DateTime(2023, 3, 29, 4, 25, 33, 646, DateTimeKind.Utc).AddTicks(3207), null, true, "deposit payment withdrawal calculate payment Generic Granite Bike wireless synthesizing South Carolina Mount Turnpike experiences deposit Refined Associate Garden & Industrial" },
                    { 29L, 3L, new DateTime(2023, 3, 25, 20, 31, 21, 27, DateTimeKind.Utc).AddTicks(9142), null, false, "open system concept" },
                    { 30L, 20L, new DateTime(2023, 3, 29, 0, 21, 12, 74, DateTimeKind.Utc).AddTicks(4610), null, false, "real-time dedicated 4th generation yellow payment Reduced feed Somalia deposit Summit copying Credit Card Account" },
                    { 31L, 3L, new DateTime(2023, 3, 28, 3, 39, 36, 238, DateTimeKind.Utc).AddTicks(9462), null, false, "white Robust deposit virtual Oregon mobile Ford magnetic Forward seamless Sleek Rubber Hat Fantastic Metal Salad Awesome Steel Bacon Finland Regional Berkshire Generic Fresh Mouse upward-trending" },
                    { 32L, 18L, new DateTime(2023, 3, 26, 0, 51, 40, 606, DateTimeKind.Utc).AddTicks(445), null, false, "Shoes infrastructures SMS Seychelles Rupee Saint Helena Pound functionalities Corporate Developer Architect Incredible Frozen Sausages Run monitor Engineer" },
                    { 33L, 11L, new DateTime(2023, 3, 26, 6, 3, 54, 892, DateTimeKind.Utc).AddTicks(6894), null, true, "Refined Creative payment payment magenta 1080p compress Solutions content-based e-business Front-line Gorgeous monitoring orchestrate connect Sleek encryption application De-engineered Jewelery" },
                    { 34L, 20L, new DateTime(2023, 3, 27, 17, 3, 49, 552, DateTimeKind.Utc).AddTicks(2553), null, false, "matrix Buckinghamshire Metrics" },
                    { 35L, 1L, new DateTime(2023, 3, 26, 22, 55, 25, 693, DateTimeKind.Utc).AddTicks(4411), null, false, "1080p firewall Specialist Buckinghamshire alarm help-desk Cambridgeshire SAS Intelligent Fantastic Rubber Mouse SDD Ridge PCI online Balboa Beauty & Home" },
                    { 36L, 12L, new DateTime(2023, 3, 27, 21, 54, 27, 996, DateTimeKind.Utc).AddTicks(5217), null, false, "productivity" },
                    { 37L, 14L, new DateTime(2023, 3, 23, 22, 38, 4, 423, DateTimeKind.Utc).AddTicks(3693), null, false, "Borders Corporate CSS programming Rubber HDD" },
                    { 38L, 7L, new DateTime(2023, 3, 26, 10, 35, 26, 459, DateTimeKind.Utc).AddTicks(78), null, false, "Automotive Som Division" },
                    { 39L, 3L, new DateTime(2023, 3, 25, 20, 55, 47, 217, DateTimeKind.Utc).AddTicks(9102), null, false, "Small Fresh Pizza demand-driven cohesive bleeding-edge" },
                    { 40L, 4L, new DateTime(2023, 3, 28, 10, 52, 43, 915, DateTimeKind.Utc).AddTicks(8232), null, false, "Cotton District USB quantify ivory Metal Unbranded Rubber Computer next-generation Brooks optical optimizing Money Market Account deposit Handcrafted benchmark Tunnel" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedAt", "IsRead", "Text", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Facere possimus eligendi quisquam ullam iure praesentium numquam sapiente distinctio.", 1, 5L },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Voluptatibus ad et adipisci hic amet ratione corporis.", 1, 5L },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "A provident rerum nemo dolores debitis dicta voluptatem.", 0, 5L },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ipsam adipisci illo quidem.", 0, 1L },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ea dolor animi quod laborum quia perspiciatis sunt tempora.", 1, 2L },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Est quasi incidunt perferendis.", 1, 3L },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Voluptatem beatae vitae sunt a ut sed.", 1, 1L },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Eos enim consequatur et praesentium ad ut beatae eius.", 1, 5L },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Error et velit autem ipsa atque consequuntur vitae sit.", 1, 3L },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Nisi omnis quia est facilis rem architecto laboriosam.", 1, 4L },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "In occaecati perspiciatis.", 1, 4L },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Recusandae perspiciatis pariatur quod eum sint molestiae quis neque tempora.", 1, 5L },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Nobis nulla dignissimos voluptas nemo cumque tenetur quod et placeat.", 0, 2L },
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Eos similique fuga enim.", 0, 5L },
                    { 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Velit magnam placeat voluptatem itaque.", 0, 4L },
                    { 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ut atque dolore accusantium soluta cumque perferendis labore magni adipisci.", 0, 1L },
                    { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ratione et quibusdam consequatur voluptatem velit expedita eos maxime.", 1, 2L },
                    { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Quia nobis iusto aspernatur nihil iure ut blanditiis veritatis.", 1, 4L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedAt", "IsRead", "Text", "Type", "UserId" },
                values: new object[,]
                {
                    { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Illum quod atque nulla voluptas quos beatae.", 1, 1L },
                    { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ab placeat tenetur perferendis et omnis.", 0, 4L },
                    { 21L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Deserunt sint enim ex sit culpa.", 1, 3L },
                    { 22L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Necessitatibus doloremque omnis facilis unde exercitationem consectetur culpa porro.", 1, 2L },
                    { 23L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Vel rem rerum eum harum.", 0, 2L },
                    { 24L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Est officia accusamus doloremque perferendis ea.", 1, 2L },
                    { 25L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Laudantium ut amet repellendus enim consequatur.", 1, 4L },
                    { 26L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Sed expedita dolorem aperiam ipsa omnis.", 0, 4L },
                    { 27L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ipsa quia cupiditate iure necessitatibus asperiores corporis doloremque corporis.", 1, 4L },
                    { 28L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Consectetur enim rerum consectetur magnam perspiciatis ut rem.", 0, 2L },
                    { 29L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Aut modi corrupti corrupti.", 1, 4L },
                    { 30L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Explicabo provident omnis culpa earum modi eos.", 0, 1L },
                    { 31L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Deleniti labore veritatis dolorum.", 1, 1L },
                    { 32L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ut sit nulla.", 0, 5L },
                    { 33L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Voluptas ut itaque nesciunt.", 0, 2L },
                    { 34L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Molestias porro exercitationem omnis et eius.", 1, 5L },
                    { 35L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Esse sit quia dolorem sequi.", 0, 2L },
                    { 36L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Perspiciatis qui dignissimos.", 0, 1L },
                    { 37L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Saepe facere eos eum perferendis nisi.", 0, 3L },
                    { 38L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Repudiandae ut nobis voluptas rerum ullam.", 1, 2L },
                    { 39L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ea voluptatibus voluptas sint et et asperiores omnis recusandae saepe.", 0, 1L },
                    { 40L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Non consequatur voluptatem in aut quia quo quo.", 0, 1L }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "LessonId", "Topic" },
                values: new object[,]
                {
                    { 1L, 7L, "input Singapore Dollar functionalities Field Branding impactful" },
                    { 2L, 2L, "Engineer Intelligent Frozen Mouse Incredible Metal Hat Platinum Thailand" },
                    { 3L, 10L, "Fresh Incredible" },
                    { 4L, 2L, "Concrete complexity" },
                    { 5L, 7L, "Savings Account" },
                    { 6L, 2L, "navigating plum pixel" },
                    { 7L, 7L, "New Hampshire" },
                    { 8L, 7L, "EXE olive" },
                    { 9L, 9L, "Advanced" },
                    { 10L, 4L, "generate Ergonomic Steel Towels Functionality South Carolina Accountability" },
                    { 11L, 7L, "ability" },
                    { 12L, 5L, "Gardens revolutionary Universal input" },
                    { 13L, 5L, "deposit auxiliary Avon Intelligent" },
                    { 14L, 2L, "SMTP enterprise" },
                    { 15L, 8L, "Credit Card Account Avon" },
                    { 16L, 6L, "Ridges Awesome Malta" },
                    { 17L, 6L, "optical Infrastructure" },
                    { 18L, 7L, "interface Israel orchestrate Balanced invoice Peso Uruguayo" },
                    { 19L, 5L, "B2C Platinum system" },
                    { 20L, 7L, "navigating fuchsia New York hybrid flexibility" }
                });

            migrationBuilder.InsertData(
                table: "TagUser",
                columns: new[] { "TagsId", "UsersId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L },
                    { 3L, 1L },
                    { 4L, 1L },
                    { 5L, 2L },
                    { 6L, 2L },
                    { 7L, 2L },
                    { 8L, 2L },
                    { 9L, 3L },
                    { 10L, 3L },
                    { 11L, 3L },
                    { 12L, 3L },
                    { 13L, 4L },
                    { 14L, 4L },
                    { 15L, 4L },
                    { 16L, 4L },
                    { 17L, 5L },
                    { 18L, 5L },
                    { 19L, 5L },
                    { 20L, 5L }
                });

            migrationBuilder.InsertData(
                table: "Subquestions",
                columns: new[] { "Id", "CreatedAt", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20L, "Possimus eligendi quisquam ullam iure praesentium numquam sapiente distinctio.\nMolestias tempore voluptatibus ad et.\nHic amet ratione corporis.\nCupiditate soluta a provident rerum nemo dolores debitis.\nVoluptatem labore dolores." },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, "Adipisci illo quidem sit dolores." },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Dolor animi quod laborum quia perspiciatis.\nTempora rerum cupiditate velit est quasi incidunt.\nOmnis voluptas quas.\nBeatae vitae sunt a.\nSed repellendus sapiente accusamus eos." },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Et praesentium ad.\nBeatae eius sint omnis voluptas." },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Velit autem ipsa atque consequuntur vitae sit nostrum.\nSoluta nisi omnis quia est facilis rem architecto laboriosam.\nCumque dicta in occaecati perspiciatis amet autem." },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17L, "Perspiciatis pariatur quod eum sint molestiae quis neque tempora ab.\nAut nobis nulla dignissimos voluptas nemo cumque tenetur.\nEt placeat voluptas nihil sit eos similique fuga.\nDolores ullam suscipit velit magnam.\nVoluptatem itaque sapiente et saepe ut atque dolore." },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, "Cumque perferendis labore magni adipisci labore corrupti quo." },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Quibusdam consequatur voluptatem velit expedita eos maxime." },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Facere quia nobis iusto aspernatur nihil iure ut.\nVeritatis quas hic et illum quod.\nNulla voluptas quos beatae quaerat consequatur.\nAb placeat tenetur perferendis et omnis.\nDoloremque corrupti deserunt sint enim ex sit." },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16L, "Impedit aut necessitatibus doloremque.\nFacilis unde exercitationem consectetur culpa porro consequatur sed aliquam.\nRem rerum eum harum est ratione voluptate est officia." },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Perferendis ea maiores.\nIure laudantium ut amet repellendus enim consequatur.\nPorro voluptate sed expedita dolorem aperiam ipsa omnis dolores.\nOmnis ipsa quia cupiditate.\nNecessitatibus asperiores corporis doloremque corporis nesciunt." },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20L, "Consectetur enim rerum consectetur magnam perspiciatis ut rem.\nOdit dolorem aut modi corrupti corrupti qui.\nPerspiciatis explicabo provident omnis culpa earum modi eos.\nAutem consectetur deleniti." },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Dolorum ut omnis.\nUt sit nulla." },
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18L, "Voluptatem voluptas ut itaque.\nEsse neque ea molestias.\nExercitationem omnis et eius pariatur est consequatur esse.\nQuia dolorem sequi doloribus corporis." },
                    { 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Qui dignissimos voluptatum qui in saepe facere." },
                    { 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Perferendis nisi alias et ducimus repudiandae.\nNobis voluptas rerum ullam omnis placeat non ea voluptatibus voluptas.\nEt et asperiores omnis recusandae saepe laborum.\nPorro non consequatur voluptatem in.\nQuia quo quo." },
                    { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Aliquid aut quaerat adipisci rem.\nEa maxime doloribus qui." },
                    { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Nesciunt quidem vel.\nQuibusdam iure labore velit.\nQui dolor velit." },
                    { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Ducimus perspiciatis nostrum ut repudiandae." },
                    { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Et velit harum ex." },
                    { 21L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Omnis in voluptatem dolorum debitis velit eos.\nSoluta voluptatem officiis voluptate.\nMollitia at aliquam ut nihil veritatis.\nSequi omnis vel qui.\nDeleniti nihil non perspiciatis modi placeat dolor molestiae." },
                    { 22L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20L, "Quo a eum corporis repellat dolor fugit voluptas.\nEsse itaque laudantium dolores quis ea excepturi.\nNostrum quo consequatur est omnis cumque reiciendis qui omnis non.\nPraesentium enim explicabo atque culpa repudiandae perferendis ullam.\nEa et aut." },
                    { 23L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Quis aperiam nihil." },
                    { 24L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Rerum sit impedit illum corrupti non et voluptates architecto quaerat." },
                    { 25L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Modi magnam qui corporis magnam quia blanditiis rerum qui ad.\nDignissimos non tempora.\nVoluptas omnis rem nam ad vel pariatur nostrum.\nFacere blanditiis id enim vitae alias.\nIpsa eius dolores nulla est officia quo eaque quo dolore." },
                    { 26L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, "Consequatur quia ut nostrum voluptatem." },
                    { 27L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Voluptatem id deserunt in.\nQuis a aut unde quibusdam quisquam sit.\nCulpa suscipit voluptatem modi doloremque eum perferendis quod ab." },
                    { 28L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Doloremque magnam quas molestiae ex corrupti neque laboriosam et voluptates.\nSuscipit ducimus facilis ut rem assumenda laborum neque labore.\nEt voluptas omnis doloremque aut ipsa voluptatem aut praesentium et." },
                    { 29L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Rerum unde ad accusamus." },
                    { 30L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16L, "Veritatis quidem eum eum saepe minus repellat." },
                    { 31L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Veritatis voluptates dolore magni rerum velit sapiente.\nEt quod saepe aliquam dignissimos ut praesentium laboriosam deleniti placeat.\nAut aspernatur optio animi." },
                    { 32L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19L, "Aspernatur animi est soluta iusto doloremque doloremque non laudantium velit.\nNumquam corporis numquam ut soluta qui aliquid magni eos commodi.\nId et ipsa velit maiores eum assumenda.\nConsequatur enim excepturi eos temporibus mollitia." },
                    { 33L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19L, "Corrupti impedit eos qui voluptatibus.\nCorrupti consequuntur dolor provident velit consequuntur excepturi nisi." },
                    { 34L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Fuga deleniti et nobis rerum voluptatem quae.\nOmnis voluptatibus fugiat distinctio.\nNeque molestiae autem quia corporis et quam minima." },
                    { 35L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Eaque iusto repudiandae ut qui et rerum ut.\nVoluptas sint excepturi.\nQui tempore rerum laudantium nam.\nDelectus repellat et eum nihil perferendis odit dolorem." },
                    { 36L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19L, "Deleniti ab ipsam maiores.\nEum magnam est temporibus mollitia sunt sed perferendis vel.\nRepellendus et sed facilis et distinctio in possimus et.\nRerum ipsum id corrupti eius nisi aut voluptas.\nPerspiciatis temporibus animi cupiditate laudantium ut quam repudiandae tempore." },
                    { 37L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18L, "Pariatur maiores illo." },
                    { 38L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13L, "Commodi maiores sit voluptatem omnis beatae nostrum cumque." },
                    { 39L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13L, "Expedita facilis labore sunt.\nVoluptas minima aliquam ut doloremque." },
                    { 40L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17L, "Expedita quod incidunt maxime." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calls_ChatId",
                table: "Calls",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUser_UsersId",
                table: "ChatUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_RequesterId",
                table: "Friends",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTag_TagsId",
                table: "LessonTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonUser_SubscribersId",
                table: "LessonUser",
                column: "SubscribersId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LessonId",
                table: "Questions",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Subquestions_QuestionId",
                table: "Subquestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TagUser_UsersId",
                table: "TagUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "ChatUser");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "LessonTag");

            migrationBuilder.DropTable(
                name: "LessonUser");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Subquestions");

            migrationBuilder.DropTable(
                name: "TagUser");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Lessons");
        }
    }
}
