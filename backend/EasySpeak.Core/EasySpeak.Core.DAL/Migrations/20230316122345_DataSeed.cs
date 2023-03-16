using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samples");

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
                columns: new[] { "Id", "Description", "LimitOfUsers", "MediaPath", "Name", "StartAt" },
                values: new object[,]
                {
                    { 1L, "Singapore Dollar functionalities Field Branding impactful invoice actuating lavender", 74, "https://picsum.photos/640/480/?image=202", "Mobility", new DateTime(2023, 3, 20, 23, 14, 14, 647, DateTimeKind.Local).AddTicks(3315) },
                    { 2L, "Thailand budgetary management SDD core Concrete complexity Generic Concrete Shoes navigating plum pixel", 123, "https://picsum.photos/640/480/?image=134", "Palau", new DateTime(2023, 4, 1, 21, 21, 42, 900, DateTimeKind.Local).AddTicks(2627) },
                    { 3L, "deposit Advanced input", null, "https://picsum.photos/640/480/?image=545", "EXE", new DateTime(2023, 3, 21, 2, 27, 3, 303, DateTimeKind.Local).AddTicks(9823) },
                    { 4L, "South Carolina Accountability Plastic Health & Home", 59, "https://picsum.photos/640/480/?image=376", "Ville", new DateTime(2023, 3, 18, 23, 9, 23, 145, DateTimeKind.Local).AddTicks(5810) },
                    { 5L, "deposit auxiliary Avon Intelligent strategy Forint copy", null, "https://picsum.photos/640/480/?image=659", "input", new DateTime(2023, 4, 4, 22, 52, 49, 128, DateTimeKind.Local).AddTicks(854) },
                    { 6L, "Awesome Malta indigo XSS Texas interface Israel orchestrate", 139, "https://picsum.photos/640/480/?image=245", "front-end", new DateTime(2023, 3, 18, 3, 57, 42, 97, DateTimeKind.Local).AddTicks(3138) },
                    { 7L, "B2C Platinum system bus channels", 133, "https://picsum.photos/640/480/?image=934", "Peso Uruguayo", new DateTime(2023, 4, 2, 14, 43, 16, 562, DateTimeKind.Local).AddTicks(5569) },
                    { 8L, "white driver Usability Total Multi-tiered", 142, "https://picsum.photos/640/480/?image=266", "Bedfordshire", new DateTime(2023, 3, 17, 7, 45, 23, 474, DateTimeKind.Local).AddTicks(3265) },
                    { 9L, "Multi-tiered hacking Seychelles", 56, "https://picsum.photos/640/480/?image=7", "Music", new DateTime(2023, 3, 26, 5, 41, 57, 38, DateTimeKind.Local).AddTicks(8190) },
                    { 10L, "application cross-platform Corners niches bleeding-edge Sleek Frozen Hat 1080p Cambridgeshire dot-com Gorgeous", 29, "https://picsum.photos/640/480/?image=878", "USB", new DateTime(2023, 3, 31, 11, 8, 4, 20, DateTimeKind.Local).AddTicks(92) }
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
                columns: new[] { "Id", "ChatId", "FinishedAt", "StartedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 3, 15, 17, 50, 18, 440, DateTimeKind.Local).AddTicks(7257), new DateTime(2023, 3, 15, 15, 35, 2, 116, DateTimeKind.Local).AddTicks(1424) },
                    { 2L, 2L, new DateTime(2023, 3, 15, 21, 59, 16, 981, DateTimeKind.Local).AddTicks(3798), new DateTime(2023, 3, 15, 21, 5, 40, 62, DateTimeKind.Local).AddTicks(4762) },
                    { 3L, 15L, new DateTime(2023, 3, 16, 12, 7, 34, 605, DateTimeKind.Local).AddTicks(12), new DateTime(2023, 3, 16, 9, 14, 33, 478, DateTimeKind.Local).AddTicks(3128) },
                    { 4L, 19L, new DateTime(2023, 3, 16, 4, 14, 23, 844, DateTimeKind.Local).AddTicks(7695), new DateTime(2023, 3, 16, 2, 13, 25, 547, DateTimeKind.Local).AddTicks(4025) },
                    { 5L, 9L, new DateTime(2023, 3, 16, 13, 23, 55, 664, DateTimeKind.Local).AddTicks(491), new DateTime(2023, 3, 16, 12, 48, 45, 988, DateTimeKind.Local).AddTicks(2501) },
                    { 6L, 1L, new DateTime(2023, 3, 16, 11, 48, 19, 340, DateTimeKind.Local).AddTicks(4029), new DateTime(2023, 3, 16, 10, 54, 4, 17, DateTimeKind.Local).AddTicks(8100) },
                    { 7L, 18L, new DateTime(2023, 3, 16, 0, 57, 0, 716, DateTimeKind.Local).AddTicks(1754), new DateTime(2023, 3, 15, 22, 4, 33, 82, DateTimeKind.Local).AddTicks(3047) },
                    { 8L, 13L, new DateTime(2023, 3, 16, 7, 23, 6, 947, DateTimeKind.Local).AddTicks(3368), new DateTime(2023, 3, 16, 6, 58, 52, 124, DateTimeKind.Local).AddTicks(815) },
                    { 9L, 17L, null, new DateTime(2023, 3, 16, 6, 45, 14, 249, DateTimeKind.Local).AddTicks(9416) },
                    { 10L, 14L, null, new DateTime(2023, 3, 16, 6, 51, 45, 138, DateTimeKind.Local).AddTicks(7097) },
                    { 11L, 18L, new DateTime(2023, 3, 16, 11, 30, 30, 22, DateTimeKind.Local).AddTicks(7806), new DateTime(2023, 3, 16, 10, 1, 32, 545, DateTimeKind.Local).AddTicks(1859) },
                    { 12L, 1L, new DateTime(2023, 3, 16, 11, 53, 32, 440, DateTimeKind.Local).AddTicks(1471), new DateTime(2023, 3, 16, 10, 5, 19, 858, DateTimeKind.Local).AddTicks(6181) },
                    { 13L, 18L, new DateTime(2023, 3, 16, 13, 3, 16, 449, DateTimeKind.Local).AddTicks(1496), new DateTime(2023, 3, 16, 11, 25, 31, 957, DateTimeKind.Local).AddTicks(8874) },
                    { 14L, 14L, new DateTime(2023, 3, 15, 18, 40, 25, 726, DateTimeKind.Local).AddTicks(3998), new DateTime(2023, 3, 15, 17, 5, 53, 164, DateTimeKind.Local).AddTicks(9355) },
                    { 15L, 3L, null, new DateTime(2023, 3, 16, 12, 43, 35, 86, DateTimeKind.Local).AddTicks(3816) },
                    { 16L, 2L, new DateTime(2023, 3, 15, 21, 30, 57, 52, DateTimeKind.Local).AddTicks(7198), new DateTime(2023, 3, 15, 20, 0, 25, 795, DateTimeKind.Local).AddTicks(7655) },
                    { 17L, 18L, new DateTime(2023, 3, 16, 14, 8, 8, 739, DateTimeKind.Local).AddTicks(1317), new DateTime(2023, 3, 16, 12, 25, 13, 124, DateTimeKind.Local).AddTicks(6273) },
                    { 18L, 11L, new DateTime(2023, 3, 16, 3, 51, 1, 702, DateTimeKind.Local).AddTicks(1217), new DateTime(2023, 3, 16, 1, 29, 38, 19, DateTimeKind.Local).AddTicks(6384) },
                    { 19L, 16L, null, new DateTime(2023, 3, 16, 11, 2, 36, 704, DateTimeKind.Local).AddTicks(4771) },
                    { 20L, 14L, new DateTime(2023, 3, 16, 4, 9, 45, 217, DateTimeKind.Local).AddTicks(3388), new DateTime(2023, 3, 16, 3, 19, 55, 120, DateTimeKind.Local).AddTicks(8270) },
                    { 21L, 18L, new DateTime(2023, 3, 16, 11, 53, 58, 67, DateTimeKind.Local).AddTicks(4835), new DateTime(2023, 3, 16, 9, 8, 45, 821, DateTimeKind.Local).AddTicks(4295) },
                    { 22L, 14L, new DateTime(2023, 3, 16, 2, 50, 49, 966, DateTimeKind.Local).AddTicks(9104), new DateTime(2023, 3, 16, 0, 53, 15, 724, DateTimeKind.Local).AddTicks(2554) },
                    { 23L, 16L, null, new DateTime(2023, 3, 16, 13, 23, 12, 754, DateTimeKind.Local).AddTicks(7223) },
                    { 24L, 17L, new DateTime(2023, 3, 16, 10, 52, 22, 287, DateTimeKind.Local).AddTicks(1778), new DateTime(2023, 3, 16, 9, 59, 39, 133, DateTimeKind.Local).AddTicks(1757) },
                    { 25L, 8L, new DateTime(2023, 3, 16, 8, 25, 4, 264, DateTimeKind.Local).AddTicks(8249), new DateTime(2023, 3, 16, 6, 8, 11, 795, DateTimeKind.Local).AddTicks(6212) },
                    { 26L, 17L, null, new DateTime(2023, 3, 15, 22, 54, 46, 868, DateTimeKind.Local).AddTicks(4657) },
                    { 27L, 12L, null, new DateTime(2023, 3, 16, 0, 26, 38, 971, DateTimeKind.Local).AddTicks(195) },
                    { 28L, 1L, new DateTime(2023, 3, 16, 3, 32, 12, 525, DateTimeKind.Local).AddTicks(5733), new DateTime(2023, 3, 16, 1, 53, 57, 802, DateTimeKind.Local).AddTicks(7963) },
                    { 29L, 7L, new DateTime(2023, 3, 15, 19, 57, 8, 966, DateTimeKind.Local).AddTicks(1882), new DateTime(2023, 3, 15, 17, 9, 4, 388, DateTimeKind.Local).AddTicks(2485) },
                    { 30L, 14L, new DateTime(2023, 3, 15, 21, 43, 2, 279, DateTimeKind.Local).AddTicks(1314), new DateTime(2023, 3, 15, 20, 33, 53, 571, DateTimeKind.Local).AddTicks(8495) },
                    { 31L, 10L, new DateTime(2023, 3, 16, 5, 57, 38, 243, DateTimeKind.Local).AddTicks(2778), new DateTime(2023, 3, 16, 5, 28, 19, 212, DateTimeKind.Local).AddTicks(214) },
                    { 32L, 19L, new DateTime(2023, 3, 16, 1, 13, 29, 621, DateTimeKind.Local).AddTicks(2635), new DateTime(2023, 3, 15, 22, 35, 9, 726, DateTimeKind.Local).AddTicks(9159) },
                    { 33L, 1L, new DateTime(2023, 3, 16, 4, 44, 14, 363, DateTimeKind.Local).AddTicks(4974), new DateTime(2023, 3, 16, 3, 45, 40, 503, DateTimeKind.Local).AddTicks(1194) },
                    { 34L, 19L, new DateTime(2023, 3, 15, 17, 42, 53, 292, DateTimeKind.Local).AddTicks(796), new DateTime(2023, 3, 15, 15, 29, 52, 257, DateTimeKind.Local).AddTicks(3479) },
                    { 35L, 7L, new DateTime(2023, 3, 15, 19, 27, 52, 602, DateTimeKind.Local).AddTicks(7448), new DateTime(2023, 3, 15, 18, 11, 58, 223, DateTimeKind.Local).AddTicks(6287) },
                    { 36L, 4L, new DateTime(2023, 3, 16, 2, 39, 35, 773, DateTimeKind.Local).AddTicks(9354), new DateTime(2023, 3, 16, 0, 47, 5, 953, DateTimeKind.Local).AddTicks(9906) },
                    { 37L, 8L, new DateTime(2023, 3, 16, 8, 15, 44, 476, DateTimeKind.Local).AddTicks(162), new DateTime(2023, 3, 16, 7, 15, 36, 346, DateTimeKind.Local).AddTicks(8978) },
                    { 38L, 11L, new DateTime(2023, 3, 15, 20, 29, 10, 153, DateTimeKind.Local).AddTicks(8584), new DateTime(2023, 3, 15, 20, 25, 24, 462, DateTimeKind.Local).AddTicks(1233) },
                    { 39L, 5L, new DateTime(2023, 3, 16, 11, 14, 20, 172, DateTimeKind.Local).AddTicks(7981), new DateTime(2023, 3, 16, 8, 33, 28, 912, DateTimeKind.Local).AddTicks(4238) },
                    { 40L, 10L, new DateTime(2023, 3, 16, 8, 34, 27, 793, DateTimeKind.Local).AddTicks(8445), new DateTime(2023, 3, 16, 8, 30, 7, 383, DateTimeKind.Local).AddTicks(5238) }
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
                    { 1L, 2, 2L, 4L },
                    { 2L, 2, 1L, 2L },
                    { 3L, 2, 1L, 2L },
                    { 4L, 2, 4L, 3L },
                    { 5L, 2, 1L, 1L },
                    { 6L, 0, 3L, 2L },
                    { 7L, 1, 3L, 3L },
                    { 8L, 1, 2L, 4L },
                    { 9L, 0, 1L, 3L },
                    { 10L, 2, 3L, 1L },
                    { 11L, 1, 3L, 2L },
                    { 12L, 0, 3L, 1L },
                    { 13L, 1, 2L, 1L },
                    { 14L, 2, 4L, 4L },
                    { 15L, 2, 1L, 2L },
                    { 16L, 0, 4L, 3L },
                    { 17L, 0, 3L, 2L },
                    { 18L, 0, 2L, 2L },
                    { 19L, 2, 1L, 4L },
                    { 20L, 0, 1L, 2L }
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
                columns: new[] { "Id", "ChatId", "CreatedAt", "IsDeleted", "Text" },
                values: new object[,]
                {
                    { 1L, 16L, new DateTime(2023, 3, 13, 3, 22, 6, 262, DateTimeKind.Local).AddTicks(490), false, "input Singapore Dollar functionalities Field Branding impactful invoice actuating lavender purple neural-net Palau Operations SQL Fresh Incredible Customer-focused orange green Savings Account" },
                    { 2L, 2L, new DateTime(2023, 3, 12, 22, 9, 21, 565, DateTimeKind.Local).AddTicks(3699), false, "Run Checking Account New Hampshire Team-oriented" },
                    { 3L, 9L, new DateTime(2023, 3, 13, 1, 54, 34, 617, DateTimeKind.Local).AddTicks(9326), false, "Advanced input" },
                    { 4L, 1L, new DateTime(2023, 3, 11, 2, 25, 38, 788, DateTimeKind.Local).AddTicks(3109), false, "Ville interactive" },
                    { 5L, 19L, new DateTime(2023, 3, 16, 1, 9, 6, 106, DateTimeKind.Local).AddTicks(1205), false, "ability withdrawal even-keeled" },
                    { 6L, 9L, new DateTime(2023, 3, 10, 15, 51, 56, 313, DateTimeKind.Local).AddTicks(7103), false, "quantify deposit auxiliary Avon Intelligent strategy Forint copy Credit Card Account Avon front-end Bahraini Dinar Mount Georgia optical Infrastructure" },
                    { 7L, 7L, new DateTime(2023, 3, 13, 3, 1, 43, 722, DateTimeKind.Local).AddTicks(8747), false, "Islands Intelligent Steel Tuna SMTP indexing B2C Platinum system bus channels COM Money Market Account" },
                    { 8L, 17L, new DateTime(2023, 3, 11, 20, 14, 26, 843, DateTimeKind.Local).AddTicks(3452), false, "Reduced Industrial, Computers & Outdoors Multi-tiered Ameliorated" },
                    { 9L, 16L, new DateTime(2023, 3, 12, 0, 8, 55, 981, DateTimeKind.Local).AddTicks(40), false, "Concrete Multi-tiered hacking Seychelles Electronics" },
                    { 10L, 16L, new DateTime(2023, 3, 11, 15, 10, 5, 376, DateTimeKind.Local).AddTicks(4775), false, "application cross-platform Corners niches bleeding-edge Sleek Frozen Hat 1080p Cambridgeshire dot-com Gorgeous online Handmade Frozen Chair Auto Loan Account Burgs Borders Estonia value-added Crossing" },
                    { 11L, 8L, new DateTime(2023, 3, 12, 18, 14, 11, 304, DateTimeKind.Local).AddTicks(1388), false, "calculate" },
                    { 12L, 18L, new DateTime(2023, 3, 11, 13, 53, 20, 700, DateTimeKind.Local).AddTicks(723), false, "transmitter Egypt online Creative Credit Card Account Fantastic Soft Soap TCP Industrial & Toys brand client-server compress drive" },
                    { 13L, 2L, new DateTime(2023, 3, 13, 4, 16, 48, 706, DateTimeKind.Local).AddTicks(6841), false, "backing up Licensed Granite Bike back up back-end e-enable Specialist Games alarm orange Savings Account interactive web-enabled Colorado Ergonomic Concrete Shoes" },
                    { 14L, 17L, new DateTime(2023, 3, 13, 1, 16, 24, 46, DateTimeKind.Local).AddTicks(5110), false, "Awesome quantify Integration SDD reinvent Bedfordshire Generic Frozen Cheese Electronics & Sports open-source Licensed Concrete Sausages Practical Wooden Shirt" },
                    { 15L, 9L, new DateTime(2023, 3, 12, 23, 59, 39, 524, DateTimeKind.Local).AddTicks(7228), false, "Intelligent Fresh Soap strategize e-business Rustic Frozen Gloves Awesome Wooden Table Avon functionalities program implement clicks-and-mortar Practical Frozen Chips Syrian Pound Paradigm Pennsylvania Markets Consultant" },
                    { 16L, 3L, new DateTime(2023, 3, 12, 18, 49, 22, 735, DateTimeKind.Local).AddTicks(7810), false, "reboot Investor non-volatile Identity Graphic Interface Sports compressing facilitate AGP turquoise Grass-roots matrix relationships Rustic Rubber Shirt Soft enhance partnerships Estate green hierarchy" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "CreatedAt", "IsDeleted", "Text" },
                values: new object[,]
                {
                    { 17L, 13L, new DateTime(2023, 3, 11, 19, 11, 20, 145, DateTimeKind.Local).AddTicks(5841), false, "Rustic Investment Account Money Market Account EXE New Hampshire Generic Fresh Mouse CSS Armenian Dram AI Pine compressing International Rustic Wooden Cheese online Investment Account experiences Idaho application Human" },
                    { 18L, 6L, new DateTime(2023, 3, 13, 18, 53, 28, 584, DateTimeKind.Local).AddTicks(6758), true, "workforce yellow generate web services Berkshire frame Uganda paradigm drive synthesize Coordinator reboot withdrawal asynchronous Borders Lead approach" },
                    { 19L, 16L, new DateTime(2023, 3, 11, 16, 15, 29, 282, DateTimeKind.Local).AddTicks(754), true, "Books" },
                    { 20L, 7L, new DateTime(2023, 3, 14, 7, 18, 22, 643, DateTimeKind.Local).AddTicks(5481), false, "magenta online tan Senior static Dynamic Multi-channelled database bleeding-edge COM actuating Mountain Re-engineered" },
                    { 21L, 19L, new DateTime(2023, 3, 12, 22, 7, 18, 851, DateTimeKind.Local).AddTicks(9701), false, "exuding compressing Buckinghamshire Pines asymmetric Books, Electronics & Health calculating Road Handmade Concrete Keyboard viral Concrete data-warehouse Bedfordshire Generic Rubber Towels" },
                    { 22L, 2L, new DateTime(2023, 3, 14, 18, 29, 8, 283, DateTimeKind.Local).AddTicks(8701), false, "South Carolina microchip multi-byte value-added Assimilated implement protocol Villages Beauty National Avon wireless Internal bleeding-edge invoice Buckinghamshire Savings Account Visionary Incredible Soft Chair Small" },
                    { 23L, 12L, new DateTime(2023, 3, 15, 16, 40, 17, 36, DateTimeKind.Local).AddTicks(2161), false, "Rustic Home Loan Account systemic Movies & Baby seize USB Planner Center Future" },
                    { 24L, 2L, new DateTime(2023, 3, 16, 7, 24, 56, 497, DateTimeKind.Local).AddTicks(6098), false, "Factors circuit grid-enabled Central interactive microchip primary Nepalese Rupee matrix Generic Credit Card Account Burg Health & Electronics Manager conglomeration Technician Inlet Wooden benchmark capacitor" },
                    { 25L, 5L, new DateTime(2023, 3, 10, 18, 14, 52, 952, DateTimeKind.Local).AddTicks(3412), false, "connect envisioneer Burkina Faso multi-byte B2B Buckinghamshire USB Developer Avon sky blue yellow Grenada Borders Investment Account SMTP Checking Account Intelligent Soft Chips" },
                    { 26L, 12L, new DateTime(2023, 3, 12, 3, 17, 16, 904, DateTimeKind.Local).AddTicks(5860), true, "portals B2C ADP motivating" },
                    { 27L, 7L, new DateTime(2023, 3, 16, 12, 16, 11, 971, DateTimeKind.Local).AddTicks(9900), false, "Multi-channelled Credit Card Account Supervisor programming French Southern Territories feed Investment Account payment Strategist IB synergies Refined digital Avon website transmitting Re-contextualized multi-byte Colorado" },
                    { 28L, 12L, new DateTime(2023, 3, 15, 7, 49, 18, 653, DateTimeKind.Local).AddTicks(8587), true, "deposit payment withdrawal calculate payment Generic Granite Bike wireless synthesizing South Carolina Mount Turnpike experiences deposit Refined Associate Garden & Industrial" },
                    { 29L, 12L, new DateTime(2023, 3, 11, 23, 55, 6, 35, DateTimeKind.Local).AddTicks(4552), false, "open system concept" },
                    { 30L, 7L, new DateTime(2023, 3, 15, 3, 44, 57, 82, DateTimeKind.Local).AddTicks(70), false, "real-time dedicated 4th generation yellow payment Reduced feed Somalia deposit Summit copying Credit Card Account" },
                    { 31L, 4L, new DateTime(2023, 3, 14, 7, 3, 21, 246, DateTimeKind.Local).AddTicks(5022), false, "white Robust deposit virtual Oregon mobile Ford magnetic Forward seamless Sleek Rubber Hat Fantastic Metal Salad Awesome Steel Bacon Finland Regional Berkshire Generic Fresh Mouse upward-trending" },
                    { 32L, 9L, new DateTime(2023, 3, 12, 4, 15, 25, 613, DateTimeKind.Local).AddTicks(6075), false, "Shoes infrastructures SMS Seychelles Rupee Saint Helena Pound functionalities Corporate Developer Architect Incredible Frozen Sausages Run monitor Engineer" },
                    { 33L, 7L, new DateTime(2023, 3, 12, 9, 27, 39, 900, DateTimeKind.Local).AddTicks(2614), true, "Refined Creative payment payment magenta 1080p compress Solutions content-based e-business Front-line Gorgeous monitoring orchestrate connect Sleek encryption application De-engineered Jewelery" },
                    { 34L, 11L, new DateTime(2023, 3, 13, 20, 27, 34, 559, DateTimeKind.Local).AddTicks(8283), false, "matrix Buckinghamshire Metrics" },
                    { 35L, 2L, new DateTime(2023, 3, 13, 2, 19, 10, 701, DateTimeKind.Local).AddTicks(221), false, "1080p firewall Specialist Buckinghamshire alarm help-desk Cambridgeshire SAS Intelligent Fantastic Rubber Mouse SDD Ridge PCI online Balboa Beauty & Home" },
                    { 36L, 13L, new DateTime(2023, 3, 14, 1, 18, 13, 4, DateTimeKind.Local).AddTicks(1047), false, "productivity" },
                    { 37L, 19L, new DateTime(2023, 3, 10, 2, 1, 49, 430, DateTimeKind.Local).AddTicks(9553), false, "Borders Corporate CSS programming Rubber HDD" },
                    { 38L, 11L, new DateTime(2023, 3, 12, 13, 59, 11, 466, DateTimeKind.Local).AddTicks(5958), false, "Automotive Som Division" },
                    { 39L, 7L, new DateTime(2023, 3, 12, 0, 19, 32, 225, DateTimeKind.Local).AddTicks(5012), false, "Small Fresh Pizza demand-driven cohesive bleeding-edge" },
                    { 40L, 17L, new DateTime(2023, 3, 14, 14, 16, 28, 923, DateTimeKind.Local).AddTicks(4232), false, "Cotton District USB quantify ivory Metal Unbranded Rubber Computer next-generation Brooks optical optimizing Money Market Account deposit Handcrafted benchmark Tunnel" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "IsRead", "Text", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, false, "Facere possimus eligendi quisquam ullam iure praesentium numquam sapiente distinctio.", 1, 3L },
                    { 2L, false, "Voluptatibus ad et adipisci hic amet ratione corporis.", 1, 4L },
                    { 3L, false, "A provident rerum nemo dolores debitis dicta voluptatem.", 0, 2L },
                    { 4L, false, "Ipsam adipisci illo quidem.", 0, 2L },
                    { 5L, false, "Ea dolor animi quod laborum quia perspiciatis sunt tempora.", 1, 2L },
                    { 6L, false, "Est quasi incidunt perferendis.", 1, 2L },
                    { 7L, false, "Voluptatem beatae vitae sunt a ut sed.", 1, 2L },
                    { 8L, false, "Eos enim consequatur et praesentium ad ut beatae eius.", 1, 2L },
                    { 9L, false, "Error et velit autem ipsa atque consequuntur vitae sit.", 1, 2L },
                    { 10L, false, "Nisi omnis quia est facilis rem architecto laboriosam.", 1, 3L },
                    { 11L, false, "In occaecati perspiciatis.", 1, 4L },
                    { 12L, true, "Recusandae perspiciatis pariatur quod eum sint molestiae quis neque tempora.", 1, 2L },
                    { 13L, false, "Nobis nulla dignissimos voluptas nemo cumque tenetur quod et placeat.", 0, 1L },
                    { 14L, false, "Eos similique fuga enim.", 0, 1L },
                    { 15L, false, "Velit magnam placeat voluptatem itaque.", 0, 3L },
                    { 16L, false, "Ut atque dolore accusantium soluta cumque perferendis labore magni adipisci.", 0, 4L },
                    { 17L, false, "Ratione et quibusdam consequatur voluptatem velit expedita eos maxime.", 1, 4L },
                    { 18L, false, "Quia nobis iusto aspernatur nihil iure ut blanditiis veritatis.", 1, 3L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "IsRead", "Text", "Type", "UserId" },
                values: new object[,]
                {
                    { 19L, false, "Illum quod atque nulla voluptas quos beatae.", 1, 3L },
                    { 20L, false, "Ab placeat tenetur perferendis et omnis.", 0, 1L },
                    { 21L, true, "Deserunt sint enim ex sit culpa.", 1, 1L },
                    { 22L, false, "Necessitatibus doloremque omnis facilis unde exercitationem consectetur culpa porro.", 1, 1L },
                    { 23L, false, "Vel rem rerum eum harum.", 0, 3L },
                    { 24L, false, "Est officia accusamus doloremque perferendis ea.", 1, 3L },
                    { 25L, false, "Laudantium ut amet repellendus enim consequatur.", 1, 3L },
                    { 26L, false, "Sed expedita dolorem aperiam ipsa omnis.", 0, 4L },
                    { 27L, false, "Ipsa quia cupiditate iure necessitatibus asperiores corporis doloremque corporis.", 1, 1L },
                    { 28L, false, "Consectetur enim rerum consectetur magnam perspiciatis ut rem.", 0, 2L },
                    { 29L, false, "Aut modi corrupti corrupti.", 1, 2L },
                    { 30L, true, "Explicabo provident omnis culpa earum modi eos.", 0, 1L },
                    { 31L, false, "Deleniti labore veritatis dolorum.", 1, 2L },
                    { 32L, false, "Ut sit nulla.", 0, 3L },
                    { 33L, false, "Voluptas ut itaque nesciunt.", 0, 1L },
                    { 34L, false, "Molestias porro exercitationem omnis et eius.", 1, 1L },
                    { 35L, false, "Esse sit quia dolorem sequi.", 0, 1L },
                    { 36L, false, "Perspiciatis qui dignissimos.", 0, 2L },
                    { 37L, true, "Saepe facere eos eum perferendis nisi.", 0, 4L },
                    { 38L, false, "Repudiandae ut nobis voluptas rerum ullam.", 1, 2L },
                    { 39L, false, "Ea voluptatibus voluptas sint et et asperiores omnis recusandae saepe.", 0, 1L },
                    { 40L, false, "Non consequatur voluptatem in aut quia quo quo.", 0, 4L }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "LessonId", "Topic" },
                values: new object[,]
                {
                    { 1L, 3L, "input Singapore Dollar functionalities Field Branding impactful" },
                    { 2L, 6L, "Engineer Intelligent Frozen Mouse Incredible Metal Hat Platinum Thailand" },
                    { 3L, 2L, "Fresh Incredible" },
                    { 4L, 8L, "Concrete complexity" },
                    { 5L, 6L, "Savings Account" },
                    { 6L, 1L, "navigating plum pixel" },
                    { 7L, 7L, "New Hampshire" },
                    { 8L, 3L, "EXE olive" },
                    { 9L, 8L, "Advanced" },
                    { 10L, 8L, "generate Ergonomic Steel Towels Functionality South Carolina Accountability" },
                    { 11L, 7L, "ability" },
                    { 12L, 2L, "Gardens revolutionary Universal input" },
                    { 13L, 5L, "deposit auxiliary Avon Intelligent" },
                    { 14L, 2L, "SMTP enterprise" },
                    { 15L, 4L, "Credit Card Account Avon" },
                    { 16L, 6L, "Ridges Awesome Malta" },
                    { 17L, 5L, "optical Infrastructure" },
                    { 18L, 2L, "interface Israel orchestrate Balanced invoice Peso Uruguayo" },
                    { 19L, 4L, "B2C Platinum system" },
                    { 20L, 8L, "navigating fuchsia New York hybrid flexibility" }
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
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1L, 6L, "Possimus eligendi quisquam ullam iure praesentium numquam sapiente distinctio.\nMolestias tempore voluptatibus ad et.\nHic amet ratione corporis.\nCupiditate soluta a provident rerum nemo dolores debitis.\nVoluptatem labore dolores." },
                    { 2L, 10L, "Adipisci illo quidem sit dolores." },
                    { 3L, 13L, "Dolor animi quod laborum quia perspiciatis.\nTempora rerum cupiditate velit est quasi incidunt.\nOmnis voluptas quas.\nBeatae vitae sunt a.\nSed repellendus sapiente accusamus eos." },
                    { 4L, 7L, "Et praesentium ad.\nBeatae eius sint omnis voluptas." },
                    { 5L, 18L, "Velit autem ipsa atque consequuntur vitae sit nostrum.\nSoluta nisi omnis quia est facilis rem architecto laboriosam.\nCumque dicta in occaecati perspiciatis amet autem." },
                    { 6L, 11L, "Perspiciatis pariatur quod eum sint molestiae quis neque tempora ab.\nAut nobis nulla dignissimos voluptas nemo cumque tenetur.\nEt placeat voluptas nihil sit eos similique fuga.\nDolores ullam suscipit velit magnam.\nVoluptatem itaque sapiente et saepe ut atque dolore." },
                    { 7L, 6L, "Cumque perferendis labore magni adipisci labore corrupti quo." },
                    { 8L, 15L, "Quibusdam consequatur voluptatem velit expedita eos maxime." },
                    { 9L, 6L, "Facere quia nobis iusto aspernatur nihil iure ut.\nVeritatis quas hic et illum quod.\nNulla voluptas quos beatae quaerat consequatur.\nAb placeat tenetur perferendis et omnis.\nDoloremque corrupti deserunt sint enim ex sit." },
                    { 10L, 10L, "Impedit aut necessitatibus doloremque.\nFacilis unde exercitationem consectetur culpa porro consequatur sed aliquam.\nRem rerum eum harum est ratione voluptate est officia." },
                    { 11L, 1L, "Perferendis ea maiores.\nIure laudantium ut amet repellendus enim consequatur.\nPorro voluptate sed expedita dolorem aperiam ipsa omnis dolores.\nOmnis ipsa quia cupiditate.\nNecessitatibus asperiores corporis doloremque corporis nesciunt." },
                    { 12L, 7L, "Consectetur enim rerum consectetur magnam perspiciatis ut rem.\nOdit dolorem aut modi corrupti corrupti qui.\nPerspiciatis explicabo provident omnis culpa earum modi eos.\nAutem consectetur deleniti." },
                    { 13L, 13L, "Dolorum ut omnis.\nUt sit nulla." },
                    { 14L, 7L, "Voluptatem voluptas ut itaque.\nEsse neque ea molestias.\nExercitationem omnis et eius pariatur est consequatur esse.\nQuia dolorem sequi doloribus corporis." },
                    { 15L, 11L, "Qui dignissimos voluptatum qui in saepe facere." },
                    { 16L, 10L, "Perferendis nisi alias et ducimus repudiandae.\nNobis voluptas rerum ullam omnis placeat non ea voluptatibus voluptas.\nEt et asperiores omnis recusandae saepe laborum.\nPorro non consequatur voluptatem in.\nQuia quo quo." },
                    { 17L, 15L, "Aliquid aut quaerat adipisci rem.\nEa maxime doloribus qui." },
                    { 18L, 4L, "Nesciunt quidem vel.\nQuibusdam iure labore velit.\nQui dolor velit." },
                    { 19L, 4L, "Ducimus perspiciatis nostrum ut repudiandae." },
                    { 20L, 1L, "Et velit harum ex." },
                    { 21L, 3L, "Omnis in voluptatem dolorum debitis velit eos.\nSoluta voluptatem officiis voluptate.\nMollitia at aliquam ut nihil veritatis.\nSequi omnis vel qui.\nDeleniti nihil non perspiciatis modi placeat dolor molestiae." },
                    { 22L, 6L, "Quo a eum corporis repellat dolor fugit voluptas.\nEsse itaque laudantium dolores quis ea excepturi.\nNostrum quo consequatur est omnis cumque reiciendis qui omnis non.\nPraesentium enim explicabo atque culpa repudiandae perferendis ullam.\nEa et aut." },
                    { 23L, 12L, "Quis aperiam nihil." },
                    { 24L, 8L, "Rerum sit impedit illum corrupti non et voluptates architecto quaerat." },
                    { 25L, 5L, "Modi magnam qui corporis magnam quia blanditiis rerum qui ad.\nDignissimos non tempora.\nVoluptas omnis rem nam ad vel pariatur nostrum.\nFacere blanditiis id enim vitae alias.\nIpsa eius dolores nulla est officia quo eaque quo dolore." },
                    { 26L, 18L, "Consequatur quia ut nostrum voluptatem." },
                    { 27L, 2L, "Voluptatem id deserunt in.\nQuis a aut unde quibusdam quisquam sit.\nCulpa suscipit voluptatem modi doloremque eum perferendis quod ab." },
                    { 28L, 9L, "Doloremque magnam quas molestiae ex corrupti neque laboriosam et voluptates.\nSuscipit ducimus facilis ut rem assumenda laborum neque labore.\nEt voluptas omnis doloremque aut ipsa voluptatem aut praesentium et." },
                    { 29L, 10L, "Rerum unde ad accusamus." },
                    { 30L, 4L, "Veritatis quidem eum eum saepe minus repellat." },
                    { 31L, 3L, "Veritatis voluptates dolore magni rerum velit sapiente.\nEt quod saepe aliquam dignissimos ut praesentium laboriosam deleniti placeat.\nAut aspernatur optio animi." },
                    { 32L, 17L, "Aspernatur animi est soluta iusto doloremque doloremque non laudantium velit.\nNumquam corporis numquam ut soluta qui aliquid magni eos commodi.\nId et ipsa velit maiores eum assumenda.\nConsequatur enim excepturi eos temporibus mollitia." },
                    { 33L, 16L, "Corrupti impedit eos qui voluptatibus.\nCorrupti consequuntur dolor provident velit consequuntur excepturi nisi." },
                    { 34L, 18L, "Fuga deleniti et nobis rerum voluptatem quae.\nOmnis voluptatibus fugiat distinctio.\nNeque molestiae autem quia corporis et quam minima." },
                    { 35L, 14L, "Eaque iusto repudiandae ut qui et rerum ut.\nVoluptas sint excepturi.\nQui tempore rerum laudantium nam.\nDelectus repellat et eum nihil perferendis odit dolorem." },
                    { 36L, 2L, "Deleniti ab ipsam maiores.\nEum magnam est temporibus mollitia sunt sed perferendis vel.\nRepellendus et sed facilis et distinctio in possimus et.\nRerum ipsum id corrupti eius nisi aut voluptas.\nPerspiciatis temporibus animi cupiditate laudantium ut quam repudiandae tempore." },
                    { 37L, 13L, "Pariatur maiores illo." },
                    { 38L, 6L, "Commodi maiores sit voluptatem omnis beatae nostrum cumque." },
                    { 39L, 8L, "Expedita facilis labore sunt.\nVoluptas minima aliquam ut doloremque." },
                    { 40L, 2L, "Expedita quod incidunt maxime." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 3L, 1L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 4L, 1L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 5L, 2L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 6L, 2L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 7L, 2L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 8L, 2L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 9L, 3L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 10L, 3L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 11L, 3L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 12L, 3L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 13L, 4L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 14L, 4L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 15L, 4L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 16L, 4L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 17L, 5L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 18L, 5L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 19L, 5L });

            migrationBuilder.DeleteData(
                table: "ChatUser",
                keyColumns: new[] { "ChatsId", "UsersId" },
                keyValues: new object[] { 20L, 5L });

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { 1L, 1L });

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
                table: "LessonUser",
                keyColumns: new[] { "LessonsId", "SubscribersId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "LessonUser",
                keyColumns: new[] { "LessonsId", "SubscribersId" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                table: "LessonUser",
                keyColumns: new[] { "LessonsId", "SubscribersId" },
                keyValues: new object[] { 3L, 2L });

            migrationBuilder.DeleteData(
                table: "LessonUser",
                keyColumns: new[] { "LessonsId", "SubscribersId" },
                keyValues: new object[] { 4L, 2L });

            migrationBuilder.DeleteData(
                table: "LessonUser",
                keyColumns: new[] { "LessonsId", "SubscribersId" },
                keyValues: new object[] { 5L, 3L });

            migrationBuilder.DeleteData(
                table: "LessonUser",
                keyColumns: new[] { "LessonsId", "SubscribersId" },
                keyValues: new object[] { 6L, 3L });

            migrationBuilder.DeleteData(
                table: "LessonUser",
                keyColumns: new[] { "LessonsId", "SubscribersId" },
                keyValues: new object[] { 7L, 4L });

            migrationBuilder.DeleteData(
                table: "LessonUser",
                keyColumns: new[] { "LessonsId", "SubscribersId" },
                keyValues: new object[] { 8L, 4L });

            migrationBuilder.DeleteData(
                table: "LessonUser",
                keyColumns: new[] { "LessonsId", "SubscribersId" },
                keyValues: new object[] { 9L, 5L });

            migrationBuilder.DeleteData(
                table: "LessonUser",
                keyColumns: new[] { "LessonsId", "SubscribersId" },
                keyValues: new object[] { 10L, 5L });

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Subquestions",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 3L, 1L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 4L, 1L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 5L, 2L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 6L, 2L });

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
                keyValues: new object[] { 9L, 3L });

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
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16L);

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

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Samples",
                columns: new[] { "Id", "Body", "CreatedAt", "CreatedBy", "Title" },
                values: new object[,]
                {
                    { 2L, "Eligendi quisquam ullam iure praesentium numquam sapiente distinctio ad. Tempore voluptatibus ad et adipisci hic amet. Corporis soluta cupiditate soluta. Provident rerum nemo dolores debitis dicta voluptatem labore dolores adipisci. Adipisci illo quidem sit dolores. Ea dolor animi quod laborum quia perspiciatis sunt tempora.", new DateTime(2020, 7, 1, 1, 14, 20, 556, DateTimeKind.Unspecified).AddTicks(7372), 5L, "hic" },
                    { 3L, "Incidunt perferendis omnis. Quas voluptatem beatae vitae sunt a ut sed repellendus. Accusamus eos enim consequatur et praesentium ad ut beatae eius. Omnis voluptas error et velit autem ipsa atque consequuntur vitae. Nostrum accusamus soluta nisi.", new DateTime(2020, 11, 26, 1, 10, 54, 982, DateTimeKind.Unspecified).AddTicks(9175), 4L, "velit" },
                    { 4L, "Architecto laboriosam culpa cumque dicta in. Perspiciatis amet autem rerum recusandae perspiciatis pariatur. Eum sint molestiae quis neque tempora ab distinctio. Nobis nulla dignissimos voluptas nemo cumque tenetur quod et placeat. Nihil sit eos similique fuga enim dolores ullam suscipit.", new DateTime(2021, 1, 18, 12, 14, 38, 642, DateTimeKind.Unspecified).AddTicks(7703), 1L, "est" },
                    { 5L, "Sapiente et saepe ut atque dolore accusantium soluta cumque perferendis. Magni adipisci labore corrupti. Ratione et quibusdam consequatur voluptatem velit expedita eos maxime.", new DateTime(2020, 2, 2, 15, 3, 56, 551, DateTimeKind.Unspecified).AddTicks(1864), 5L, "placeat" },
                    { 6L, "Iusto aspernatur nihil iure ut blanditiis veritatis quas. Et illum quod atque nulla voluptas quos beatae quaerat consequatur. Ab placeat tenetur perferendis et omnis. Doloremque corrupti deserunt sint enim ex sit.", new DateTime(2021, 4, 7, 16, 50, 6, 239, DateTimeKind.Unspecified).AddTicks(5929), 3L, "facere" },
                    { 7L, "Doloremque omnis facilis unde exercitationem consectetur culpa porro consequatur sed. Vel rem rerum eum harum. Ratione voluptate est officia accusamus doloremque perferendis ea. Unde iure laudantium ut amet repellendus enim consequatur dolor porro. Sed expedita dolorem aperiam ipsa omnis. Ut omnis ipsa quia cupiditate iure.", new DateTime(2019, 7, 23, 7, 33, 40, 245, DateTimeKind.Unspecified).AddTicks(9313), 5L, "impedit" },
                    { 8L, "Nesciunt placeat et consectetur enim. Consectetur magnam perspiciatis ut rem perspiciatis odit dolorem. Modi corrupti corrupti.", new DateTime(2020, 1, 27, 9, 1, 30, 801, DateTimeKind.Unspecified).AddTicks(8159), 3L, "corporis" },
                    { 9L, "Omnis culpa earum modi eos beatae autem. Deleniti labore veritatis dolorum. Omnis perferendis ut sit nulla autem ut voluptatem voluptas ut.", new DateTime(2021, 3, 25, 21, 11, 5, 602, DateTimeKind.Unspecified).AddTicks(6614), 5L, "perspiciatis" },
                    { 10L, "Molestias porro exercitationem omnis et eius. Est consequatur esse sit quia dolorem sequi doloribus corporis. Perspiciatis qui dignissimos.", new DateTime(2021, 4, 7, 22, 46, 32, 439, DateTimeKind.Unspecified).AddTicks(5958), 3L, "esse" },
                    { 11L, "Eos eum perferendis nisi alias et ducimus repudiandae ut. Voluptas rerum ullam omnis placeat non ea voluptatibus. Sint et et asperiores omnis recusandae saepe laborum enim. Non consequatur voluptatem in aut quia quo quo. Commodi aliquid aut quaerat adipisci. Modi ea maxime doloribus qui sint.", new DateTime(2021, 3, 24, 14, 25, 37, 776, DateTimeKind.Unspecified).AddTicks(56), 1L, "in" }
                });
        }
    }
}
