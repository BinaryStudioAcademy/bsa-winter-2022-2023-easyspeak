using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class SeedingUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Lessons_LessonId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_LessonId",
                table: "Questions");

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
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15L);

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
                keyValues: new object[] { 4L, 2L });

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
                keyValues: new object[] { 7L, 3L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 8L, 3L });

            migrationBuilder.DeleteData(
                table: "TagUser",
                keyColumns: new[] { "TagsId", "UsersId" },
                keyValues: new object[] { 9L, 3L });

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
                keyValue: 3L);

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
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

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

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "Questions",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsCalculated", "IsCanceled", "LanguageLevel", "LimitOfUsers", "MediaPath", "Name", "Questions", "StartAt", "YoutubeVideoId", "ZoomMeetingLink", "ZoomMeetingLinkHost" },
                values: new object[,]
                {
                    { -80L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 150, "https://picsum.photos/640/480/?image=822", "Mobility", "Versatile withdrawal Oman", new DateTime(2023, 4, 21, 2, 2, 34, 750, DateTimeKind.Utc).AddTicks(123), "2eRtd_-WVkM", "", "" },
                    { -79L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=71", "Engineer", "Kyat Platinum", new DateTime(2023, 4, 6, 15, 57, 24, 785, DateTimeKind.Utc).AddTicks(3654), "y_IeU_ut2z4", "", "" },
                    { -78L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=335", "Thailand", "Concrete complexity", new DateTime(2023, 4, 4, 21, 45, 18, 995, DateTimeKind.Utc).AddTicks(2261), "2UHU93KF9k", "", "" },
                    { -77L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 52, "https://picsum.photos/640/480/?image=911", "Generic Concrete Shoes", "Granite Flat EXE olive", new DateTime(2023, 4, 12, 17, 56, 37, 239, DateTimeKind.Utc).AddTicks(3113), "Rl298m9JZ9M", "", "" },
                    { -76L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=831", "Intelligent Steel Cheese", "Functionality South Carolina Accountability Plastic", new DateTime(2023, 4, 15, 14, 0, 51, 613, DateTimeKind.Utc).AddTicks(3961), "oGQzYnkYwBs", "", "" },
                    { -75L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 59, "https://picsum.photos/640/480/?image=376", "Health & Home", "North Carolina indigo Sleek Wooden Car orange SMTP", new DateTime(2023, 4, 3, 6, 52, 6, 876, DateTimeKind.Utc).AddTicks(6340), "RGrL8lqg-AU", "", "" },
                    { -74L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 136, "https://picsum.photos/640/480/?image=350", "enterprise", "Ridges Awesome Malta", new DateTime(2023, 4, 18, 14, 55, 6, 713, DateTimeKind.Utc).AddTicks(3438), "oGQzYnkYwBs", "", "" },
                    { -73L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 118, "https://picsum.photos/640/480/?image=960", "indigo", "Israel orchestrate Balanced", new DateTime(2023, 4, 28, 1, 53, 42, 82, DateTimeKind.Utc).AddTicks(101), "Rl298m9JZ9M", "", "" },
                    { -72L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 100, "https://picsum.photos/640/480/?image=744", "invoice", "Mobility Shoals navigating fuchsia New York", new DateTime(2023, 4, 25, 13, 22, 9, 20, DateTimeKind.Utc).AddTicks(1188), "2UHU93KF9k", "", "" },
                    { -71L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 55, "https://picsum.photos/640/480/?image=322", "hybrid", "Usability", new DateTime(2023, 4, 10, 16, 31, 25, 955, DateTimeKind.Utc).AddTicks(4657), "Rl298m9JZ9M", "", "" },
                    { -70L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=255", "Total", "Music white Cambridgeshire Sleek Soft Chair complexity", new DateTime(2023, 4, 14, 23, 38, 30, 741, DateTimeKind.Utc).AddTicks(5730), "iXEqUxwTraI", "", "" },
                    { -69L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 152, "https://picsum.photos/640/480/?image=810", "invoice", "Corners niches bleeding-edge Sleek Frozen Hat 1080p", new DateTime(2023, 4, 26, 19, 42, 26, 478, DateTimeKind.Utc).AddTicks(7843), "2UHU93KF9k", "", "" },
                    { -68L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 33, "https://picsum.photos/640/480/?image=355", "Cambridgeshire", "Handmade Frozen Chair Auto Loan Account Burgs", new DateTime(2023, 4, 15, 7, 11, 12, 507, DateTimeKind.Utc).AddTicks(6364), "SmtkrruHmAM", "", "" },
                    { -67L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=559", "Borders", "Trinidad and Tobago Dollar", new DateTime(2023, 4, 8, 19, 24, 17, 116, DateTimeKind.Utc).AddTicks(5172), "fjWd1qZW6ng", "", "" },
                    { -66L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 119, "https://picsum.photos/640/480/?image=844", "TCP", "transmitter Egypt online Creative", new DateTime(2023, 4, 19, 15, 33, 16, 487, DateTimeKind.Utc).AddTicks(2055), "vx_SFqP75hY", "", "" },
                    { -65L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 160, "https://picsum.photos/640/480/?image=158", "Credit Card Account", "Industrial & Toys", new DateTime(2023, 4, 12, 20, 6, 8, 946, DateTimeKind.Utc).AddTicks(3058), "SJ854on-V2I", "", "" },
                    { -64L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 161, "https://picsum.photos/640/480/?image=289", "brand", "interface olive backing up Licensed Granite Bike back up", new DateTime(2023, 4, 6, 9, 50, 20, 230, DateTimeKind.Utc).AddTicks(3053), "2eRtd_-WVkM", "", "" },
                    { -63L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 200, "https://picsum.photos/640/480/?image=419", "back-end", "Handmade Rubber Mouse model", new DateTime(2023, 4, 26, 20, 11, 55, 298, DateTimeKind.Utc).AddTicks(8430), "GZb6LNwAeRQ", "", "" },
                    { -62L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 105, "https://picsum.photos/640/480/?image=589", "white", "Concrete", new DateTime(2023, 4, 11, 1, 56, 17, 774, DateTimeKind.Utc).AddTicks(7082), "y_IeU_ut2z4", "", "" },
                    { -61L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=633", "Berkshire", "Views Synergistic Fantastic turquoise Business-focused", new DateTime(2023, 4, 22, 9, 47, 13, 59, DateTimeKind.Utc).AddTicks(8459), "INatfKtRXKc", "", "" },
                    { -60L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=844", "Personal Loan Account", "Customizable compress Marketing initiatives convergence", new DateTime(2023, 4, 1, 8, 24, 30, 802, DateTimeKind.Utc).AddTicks(3898), "SmtkrruHmAM", "", "" },
                    { -59L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 59, "https://picsum.photos/640/480/?image=826", "card", "e-services Rustic Wooden Chips alliance", new DateTime(2023, 4, 2, 21, 51, 45, 125, DateTimeKind.Utc).AddTicks(9825), "9OnINP-fGm4", "", "" },
                    { -58L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 45, "https://picsum.photos/640/480/?image=483", "Delaware", "AI Books & Movies Unions Developer parse", new DateTime(2023, 4, 14, 18, 2, 39, 875, DateTimeKind.Utc).AddTicks(432), "SJ854on-V2I", "", "" },
                    { -57L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 93, "https://picsum.photos/640/480/?image=813", "knowledge user", "Checking Account Consultant Interactions Money Market Account", new DateTime(2023, 4, 27, 22, 32, 12, 119, DateTimeKind.Utc).AddTicks(3373), "RGrL8lqg-AU", "", "" },
                    { -56L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=396", "capacitor", "compressing facilitate AGP turquoise Grass-roots matrix", new DateTime(2023, 4, 10, 4, 54, 5, 339, DateTimeKind.Utc).AddTicks(4227), "N1urEuxzH34", "", "" },
                    { -55L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 134, "https://picsum.photos/640/480/?image=76", "relationships", "enhance partnerships Estate green hierarchy", new DateTime(2023, 4, 5, 15, 46, 40, 279, DateTimeKind.Utc).AddTicks(7481), "y_IeU_ut2z4", "", "" },
                    { -54L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=378", "Iowa", "Money Market Account EXE New Hampshire", new DateTime(2023, 4, 27, 11, 53, 24, 487, DateTimeKind.Utc).AddTicks(4197), "9OnINP-fGm4", "", "" },
                    { -53L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=933", "Generic Fresh Mouse", "Pine compressing International", new DateTime(2023, 4, 6, 22, 45, 19, 750, DateTimeKind.Utc).AddTicks(7122), "SJ854on-V2I", "", "" },
                    { -52L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 136, "https://picsum.photos/640/480/?image=882", "Rustic Wooden Cheese", "Idaho application Human US Dollar Creative workforce", new DateTime(2023, 4, 14, 2, 57, 39, 252, DateTimeKind.Utc).AddTicks(2671), "Fx9dLmhl7nY", "", "" },
                    { -51L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 95, "https://picsum.photos/640/480/?image=828", "yellow", "frame Uganda paradigm", new DateTime(2023, 4, 16, 5, 15, 20, 193, DateTimeKind.Utc).AddTicks(2205), "Eg0-a22-XBM", "", "" },
                    { -50L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 197, "https://picsum.photos/640/480/?image=826", "drive", "withdrawal asynchronous Borders Lead approach paradigms", new DateTime(2023, 4, 21, 6, 38, 51, 855, DateTimeKind.Utc).AddTicks(8402), "RGrL8lqg-AU", "", "" },
                    { -49L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 26, "https://picsum.photos/640/480/?image=14", "Supervisor", "Savings Account Tanzanian Shilling Bedfordshire Cambridgeshire Gorgeous programming", new DateTime(2023, 4, 9, 8, 48, 17, 860, DateTimeKind.Utc).AddTicks(7534), "GZb6LNwAeRQ", "", "" },
                    { -48L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 65, "https://picsum.photos/640/480/?image=491", "Ergonomic", "Garden Practical Granite Bike card connect withdrawal generate", new DateTime(2023, 4, 9, 18, 31, 59, 258, DateTimeKind.Utc).AddTicks(5809), "Eg0-a22-XBM", "", "" },
                    { -47L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 129, "https://picsum.photos/640/480/?image=817", "info-mediaries", "Program", new DateTime(2023, 4, 14, 3, 54, 29, 527, DateTimeKind.Utc).AddTicks(5953), "oGQzYnkYwBs", "", "" },
                    { -46L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 126, "https://picsum.photos/640/480/?image=915", "Networked", "Customer-focused viral Concrete data-warehouse Bedfordshire", new DateTime(2023, 4, 22, 1, 20, 47, 904, DateTimeKind.Utc).AddTicks(3849), "GZb6LNwAeRQ", "", "" },
                    { -45L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 193, "https://picsum.photos/640/480/?image=570", "Generic Rubber Towels", "microchip multi-byte value-added Assimilated implement", new DateTime(2023, 4, 11, 19, 36, 22, 273, DateTimeKind.Utc).AddTicks(9200), "INatfKtRXKc", "", "" },
                    { -44L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 25, "https://picsum.photos/640/480/?image=473", "protocol", "interactive Incredible Soft Salad copying Port Architect calculate", new DateTime(2023, 4, 28, 14, 45, 40, 761, DateTimeKind.Utc).AddTicks(4747), "INatfKtRXKc", "", "" },
                    { -43L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=355", "Gorgeous Frozen Car", "RSS Corners", new DateTime(2023, 4, 23, 3, 4, 0, 529, DateTimeKind.Utc).AddTicks(7003), "GZb6LNwAeRQ", "", "" },
                    { -42L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=943", "Generic Rubber Ball", "e-enable matrix Pass", new DateTime(2023, 4, 1, 23, 24, 11, 361, DateTimeKind.Utc).AddTicks(6433), "9OnINP-fGm4", "", "" },
                    { -41L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 194, "https://picsum.photos/640/480/?image=962", "Unbranded Concrete Keyboard", "Future Turnpike Hills Buckinghamshire Licensed Wooden Chicken", new DateTime(2023, 4, 6, 17, 27, 27, 660, DateTimeKind.Utc).AddTicks(8301), "7B60bwTXFNc", "", "" },
                    { -40L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 128, "https://picsum.photos/640/480/?image=1075", "Rue", "Beauty Fall Manager", new DateTime(2023, 4, 3, 21, 18, 14, 898, DateTimeKind.Utc).AddTicks(1404), "iXEqUxwTraI", "", "" },
                    { -39L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 125, "https://picsum.photos/640/480/?image=1051", "conglomeration", "benchmark", new DateTime(2023, 4, 20, 16, 42, 56, 591, DateTimeKind.Utc).AddTicks(1084), "y_IeU_ut2z4", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsCalculated", "IsCanceled", "LanguageLevel", "LimitOfUsers", "MediaPath", "Name", "Questions", "StartAt", "YoutubeVideoId", "ZoomMeetingLink", "ZoomMeetingLinkHost" },
                values: new object[,]
                {
                    { -38L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 198, "https://picsum.photos/640/480/?image=45", "capacitor", "envisioneer Burkina Faso multi-byte", new DateTime(2023, 4, 12, 22, 59, 55, 555, DateTimeKind.Utc).AddTicks(9401), "RGrL8lqg-AU", "", "" },
                    { -37L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 176, "https://picsum.photos/640/480/?image=528", "B2B", "Avon sky blue yellow Grenada Borders", new DateTime(2023, 4, 21, 13, 46, 38, 374, DateTimeKind.Utc).AddTicks(6119), "zIfHrp2REWY", "", "" },
                    { -36L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=939", "Investment Account", "parse quantifying", new DateTime(2023, 4, 20, 20, 3, 15, 612, DateTimeKind.Utc).AddTicks(3837), "GZb6LNwAeRQ", "", "" },
                    { -35L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 78, "https://picsum.photos/640/480/?image=462", "Chilean Peso", "motivating Checking Account Unions", new DateTime(2023, 4, 11, 20, 13, 42, 699, DateTimeKind.Utc).AddTicks(9100), "SJ854on-V2I", "", "" },
                    { -34L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=683", "Multi-channelled", "French Southern Territories feed Investment Account payment Strategist IB", new DateTime(2023, 4, 19, 14, 37, 5, 942, DateTimeKind.Utc).AddTicks(4201), "SmtkrruHmAM", "", "" },
                    { -33L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 165, "https://picsum.photos/640/480/?image=115", "synergies", "website", new DateTime(2023, 4, 24, 22, 51, 50, 512, DateTimeKind.Utc).AddTicks(5438), "Eg0-a22-XBM", "", "" },
                    { -32L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 162, "https://picsum.photos/640/480/?image=270", "transmitting", "Sports, Jewelery & Baby", new DateTime(2023, 4, 22, 1, 26, 13, 452, DateTimeKind.Utc).AddTicks(8506), "fjWd1qZW6ng", "", "" },
                    { -31L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 92, "https://picsum.photos/640/480/?image=708", "Metal", "Savings Account Meadows Future-proofed optical generate", new DateTime(2023, 4, 20, 3, 36, 2, 330, DateTimeKind.Utc).AddTicks(4621), "9OnINP-fGm4", "", "" },
                    { -30L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 183, "https://picsum.photos/640/480/?image=568", "multi-byte", "Ergonomic Fresh Chips Small Metal Pants Officer Awesome Steel Gloves Guyana Dollar", new DateTime(2023, 4, 14, 9, 43, 2, 332, DateTimeKind.Utc).AddTicks(1774), "7B60bwTXFNc", "", "" },
                    { -29L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 123, "https://picsum.photos/640/480/?image=699", "olive", "demand-driven Music", new DateTime(2023, 4, 7, 20, 58, 38, 324, DateTimeKind.Utc).AddTicks(7992), "RGrL8lqg-AU", "", "" },
                    { -28L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 151, "https://picsum.photos/640/480/?image=251", "payment", "deposit Summit copying Credit Card Account turquoise", new DateTime(2023, 4, 22, 14, 34, 35, 690, DateTimeKind.Utc).AddTicks(7707), "INatfKtRXKc", "", "" },
                    { -27L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 64, "https://picsum.photos/640/480/?image=224", "Cambridgeshire", "virtual", new DateTime(2023, 4, 8, 10, 46, 8, 43, DateTimeKind.Utc).AddTicks(6911), "iXEqUxwTraI", "", "" },
                    { -26L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 101, "https://picsum.photos/640/480/?image=854", "Oregon", "Forward seamless Sleek Rubber Hat", new DateTime(2023, 4, 29, 9, 51, 20, 215, DateTimeKind.Utc).AddTicks(1741), "2UHU93KF9k", "", "" },
                    { -25L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 28, "https://picsum.photos/640/480/?image=156", "Fantastic Metal Salad", "Regional Berkshire", new DateTime(2023, 4, 18, 1, 15, 38, 314, DateTimeKind.Utc).AddTicks(8349), "INatfKtRXKc", "", "" },
                    { -24L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 79, "https://picsum.photos/640/480/?image=272", "Generic Fresh Mouse", "Shoes infrastructures SMS Seychelles Rupee", new DateTime(2023, 4, 27, 17, 13, 7, 916, DateTimeKind.Utc).AddTicks(6296), "2eRtd_-WVkM", "", "" },
                    { -23L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=316", "Saint Helena Pound", "Architect Incredible Frozen Sausages Run monitor Engineer", new DateTime(2023, 4, 12, 6, 18, 54, 860, DateTimeKind.Utc).AddTicks(8436), "zIfHrp2REWY", "", "" },
                    { -22L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 37, "https://picsum.photos/640/480/?image=472", "Savings Account", "payment payment magenta 1080p compress", new DateTime(2023, 4, 29, 16, 54, 3, 593, DateTimeKind.Utc).AddTicks(1236), "zIfHrp2REWY", "", "" },
                    { -21L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=290", "Solutions", "Gorgeous monitoring", new DateTime(2023, 4, 7, 22, 33, 11, 348, DateTimeKind.Utc).AddTicks(5875), "N1urEuxzH34", "", "" },
                    { -20L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 33, "https://picsum.photos/640/480/?image=814", "orchestrate", "application De-engineered", new DateTime(2023, 4, 14, 13, 46, 18, 336, DateTimeKind.Utc).AddTicks(2977), "vaeoTDOnRsE", "", "" },
                    { -19L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=651", "Jewelery", "Buckinghamshire Metrics transition radical 1080p firewall", new DateTime(2023, 4, 4, 0, 49, 39, 195, DateTimeKind.Utc).AddTicks(9925), "Rl298m9JZ9M", "", "" },
                    { -18L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 154, "https://picsum.photos/640/480/?image=528", "Specialist", "Cambridgeshire SAS Intelligent", new DateTime(2023, 4, 24, 14, 31, 11, 351, DateTimeKind.Utc).AddTicks(8669), "2UHU93KF9k", "", "" },
                    { -17L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 124, "https://picsum.photos/640/480/?image=948", "Fantastic Rubber Mouse", "online Balboa Beauty & Home", new DateTime(2023, 4, 3, 21, 23, 28, 27, DateTimeKind.Utc).AddTicks(6028), "SJ854on-V2I", "", "" },
                    { -16L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 76, "https://picsum.photos/640/480/?image=48", "Northern Mariana Islands", "compressing Borders Corporate CSS", new DateTime(2023, 4, 1, 1, 39, 15, 413, DateTimeKind.Utc).AddTicks(7675), "2eRtd_-WVkM", "", "" },
                    { -15L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 180, "https://picsum.photos/640/480/?image=137", "programming", "infrastructures Automotive", new DateTime(2023, 4, 17, 23, 39, 18, 527, DateTimeKind.Utc).AddTicks(7552), "7B60bwTXFNc", "", "" },
                    { -14L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 123, "https://picsum.photos/640/480/?image=1009", "Som", "Small Fresh Pizza", new DateTime(2023, 4, 13, 14, 30, 47, 970, DateTimeKind.Utc).AddTicks(7425), "Fx9dLmhl7nY", "", "" },
                    { -13L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 80, "https://picsum.photos/640/480/?image=301", "demand-driven", "Buckinghamshire Cotton District USB", new DateTime(2023, 4, 7, 0, 38, 32, 120, DateTimeKind.Utc).AddTicks(5922), "iXEqUxwTraI", "", "" },
                    { -12L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 40, "https://picsum.photos/640/480/?image=206", "quantify", "Connecticut next-generation Brooks optical optimizing Money Market Account", new DateTime(2023, 4, 23, 10, 14, 30, 948, DateTimeKind.Utc).AddTicks(457), "vx_SFqP75hY", "", "" },
                    { -11L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 84, "https://picsum.photos/640/480/?image=82", "deposit", "instruction set Canada models vortals SDD pixel", new DateTime(2023, 4, 20, 12, 29, 23, 140, DateTimeKind.Utc).AddTicks(6084), "Eg0-a22-XBM", "", "" },
                    { -10L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 40, "https://picsum.photos/640/480/?image=703", "Fantastic", "Music Licensed Granite Car payment", new DateTime(2023, 4, 7, 4, 14, 57, 663, DateTimeKind.Utc).AddTicks(2800), "vx_SFqP75hY", "", "" },
                    { -9L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 68, "https://picsum.photos/640/480/?image=522", "Iraq", "maroon pixel holistic red", new DateTime(2023, 4, 6, 22, 24, 28, 417, DateTimeKind.Utc).AddTicks(1248), "GZb6LNwAeRQ", "", "" },
                    { -8L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 121, "https://picsum.photos/640/480/?image=470", "Computers", "TCP harness customized Credit Card Account Tactics deposit", new DateTime(2023, 4, 26, 0, 57, 39, 358, DateTimeKind.Utc).AddTicks(5865), "Eg0-a22-XBM", "", "" },
                    { -7L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 129, "https://picsum.photos/640/480/?image=862", "applications", "quantifying system engine Licensed Plastic Bacon", new DateTime(2023, 4, 18, 11, 56, 2, 700, DateTimeKind.Utc).AddTicks(4019), "2eRtd_-WVkM", "", "" },
                    { -6L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 24, "https://picsum.photos/640/480/?image=1037", "Profound", "withdrawal connecting Unbranded systems", new DateTime(2023, 4, 26, 6, 4, 48, 158, DateTimeKind.Utc).AddTicks(3346), "2eRtd_-WVkM", "", "" },
                    { -5L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 104, "https://picsum.photos/640/480/?image=642", "South Carolina", "Small Wooden Bike Tenge sky blue Auto Loan Account", new DateTime(2023, 4, 12, 23, 16, 53, 941, DateTimeKind.Utc).AddTicks(424), "vaeoTDOnRsE", "", "" },
                    { -4L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, null, "https://picsum.photos/640/480/?image=421", "Bedfordshire", "Tactics Refined", new DateTime(2023, 4, 23, 18, 29, 42, 10, DateTimeKind.Utc).AddTicks(8843), "Eg0-a22-XBM", "", "" },
                    { -3L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 86, "https://picsum.photos/640/480/?image=256", "compelling", "best-of-breed e-services driver Rustic SSL Incredible", new DateTime(2023, 4, 20, 1, 48, 18, 719, DateTimeKind.Utc).AddTicks(9739), "N1urEuxzH34", "", "" },
                    { -2L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 65, "https://picsum.photos/640/480/?image=419", "Product", "Functionality Chief Indiana", new DateTime(2023, 4, 5, 0, 51, 47, 429, DateTimeKind.Utc).AddTicks(7368), "fjWd1qZW6ng", "", "" },
                    { -1L, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1L, false, false, 0, 35, "https://picsum.photos/640/480/?image=1083", "deposit", "Common HTTP Intelligent Wooden Gloves parallelism regional", new DateTime(2023, 4, 2, 11, 40, 44, 643, DateTimeKind.Utc).AddTicks(7435), "2UHU93KF9k", "", "" }
                });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedAt",
                value: new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "Country", "CreatedAt", "Email", "FirstName", "IsSubscribed", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { new DateTime(1998, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), 6, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc), "easymeats.service@gmail.com", "Fred", false, 55, 3, "Pitt", 0, 1, 96 });

            migrationBuilder.InsertData(
                table: "LessonTag",
                columns: new[] { "LessonsId", "TagsId" },
                values: new object[,]
                {
                    { -80L, 1L },
                    { -79L, 1L },
                    { -78L, 1L },
                    { -77L, 2L },
                    { -76L, 2L },
                    { -75L, 2L },
                    { -74L, 3L },
                    { -73L, 3L },
                    { -72L, 3L },
                    { -71L, 4L },
                    { -70L, 4L },
                    { -69L, 4L },
                    { -68L, 5L },
                    { -67L, 5L },
                    { -66L, 5L },
                    { -65L, 6L },
                    { -64L, 6L },
                    { -63L, 6L },
                    { -62L, 7L },
                    { -61L, 7L },
                    { -60L, 7L },
                    { -59L, 8L },
                    { -58L, 8L },
                    { -57L, 8L },
                    { -56L, 9L },
                    { -55L, 9L },
                    { -54L, 9L },
                    { -53L, 10L },
                    { -52L, 10L },
                    { -51L, 10L },
                    { -50L, 11L },
                    { -49L, 11L },
                    { -48L, 11L },
                    { -47L, 12L },
                    { -46L, 12L },
                    { -45L, 12L },
                    { -44L, 13L },
                    { -43L, 13L },
                    { -42L, 13L },
                    { -41L, 14L },
                    { -40L, 14L },
                    { -39L, 14L }
                });

            migrationBuilder.InsertData(
                table: "LessonTag",
                columns: new[] { "LessonsId", "TagsId" },
                values: new object[,]
                {
                    { -38L, 15L },
                    { -37L, 15L },
                    { -36L, 15L },
                    { -35L, 16L },
                    { -34L, 16L },
                    { -33L, 16L },
                    { -32L, 17L },
                    { -31L, 17L },
                    { -30L, 17L },
                    { -29L, 18L },
                    { -28L, 18L },
                    { -27L, 18L },
                    { -26L, 19L },
                    { -25L, 19L },
                    { -24L, 19L },
                    { -23L, 20L },
                    { -22L, 20L },
                    { -21L, 20L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -80L, 1L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -79L, 1L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -78L, 1L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -77L, 2L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -76L, 2L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -75L, 2L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -74L, 3L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -73L, 3L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -72L, 3L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -71L, 4L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -70L, 4L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -69L, 4L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -68L, 5L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -67L, 5L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -66L, 5L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -65L, 6L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -64L, 6L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -63L, 6L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -62L, 7L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -61L, 7L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -60L, 7L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -59L, 8L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -58L, 8L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -57L, 8L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -56L, 9L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -55L, 9L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -54L, 9L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -53L, 10L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -52L, 10L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -51L, 10L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -50L, 11L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -49L, 11L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -48L, 11L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -47L, 12L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -46L, 12L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -45L, 12L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -44L, 13L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -43L, 13L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -42L, 13L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -41L, 14L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -40L, 14L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -39L, 14L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -38L, 15L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -37L, 15L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -36L, 15L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -35L, 16L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -34L, 16L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -33L, 16L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -32L, 17L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -31L, 17L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -30L, 17L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -29L, 18L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -28L, 18L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -27L, 18L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -26L, 19L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -25L, 19L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -24L, 19L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -23L, 20L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -22L, 20L });

            migrationBuilder.DeleteData(
                table: "LessonTag",
                keyColumns: new[] { "LessonsId", "TagsId" },
                keyValues: new object[] { -21L, 20L });

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -20L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -19L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -18L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -17L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -16L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -15L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -14L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -13L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -12L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -11L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -10L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -9L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -8L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -7L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -6L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -5L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -4L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -3L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -2L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -1L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -80L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -79L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -78L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -77L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -76L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -75L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -74L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -73L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -72L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -71L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -70L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -69L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -68L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -67L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -66L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -65L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -64L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -63L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -62L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -61L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -60L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -59L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -58L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -57L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -56L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -55L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -54L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -53L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -52L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -51L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -50L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -49L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -48L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -47L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -46L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -45L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -44L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -43L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -42L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -41L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -40L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -39L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -38L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -37L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -36L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -35L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -34L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -33L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -32L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -31L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -30L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -29L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -28L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -27L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -26L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -25L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -24L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -23L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -22L);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: -21L);

            migrationBuilder.DropColumn(
                name: "Questions",
                table: "Lessons");

            migrationBuilder.AddColumn<long>(
                name: "LessonId",
                table: "Questions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "CreatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "CreatedAt", "FriendshipStatus", "RequesterId", "UserId" },
                values: new object[,]
                {
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1L, 1L },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1L, 1L }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsCanceled", "LanguageLevel", "LimitOfUsers", "MediaPath", "Name", "StartAt", "YoutubeVideoId", "ZoomMeetingLink", "ZoomMeetingLinkHost" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, false, 0, 150, "https://picsum.photos/640/480/?image=822", "Mobility", new DateTime(2023, 4, 20, 5, 39, 54, 568, DateTimeKind.Utc).AddTicks(9782), "", "", "" },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, false, 0, 139, "https://picsum.photos/640/480/?image=232", "brand", new DateTime(2023, 4, 28, 7, 4, 30, 405, DateTimeKind.Utc).AddTicks(2189), "", "", "" },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, false, 0, 52, "https://picsum.photos/640/480/?image=60", "complexity", new DateTime(2023, 4, 18, 12, 32, 59, 586, DateTimeKind.Utc).AddTicks(5964), "", "", "" },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, false, 0, 180, "https://picsum.photos/640/480/?image=620", "Granite", new DateTime(2023, 4, 6, 5, 31, 35, 722, DateTimeKind.Utc).AddTicks(2772), "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedAt", "IsRead", "RelatedTo", "Text", "Type", "UserId" },
                values: new object[,]
                {
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Voluptatibus ad et adipisci hic amet ratione corporis.", 3, 1L },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Voluptatem beatae vitae sunt a ut sed.", 4, 1L },
                    { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Ratione et quibusdam consequatur voluptatem velit expedita eos maxime.", 3, 1L },
                    { 23L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Vel rem rerum eum harum.", 1, 1L },
                    { 32L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Ut sit nulla.", 1, 1L },
                    { 34L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Molestias porro exercitationem omnis et eius.", 3, 1L },
                    { 35L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Esse sit quia dolorem sequi.", 2, 1L },
                    { 38L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Repudiandae ut nobis voluptas rerum ullam.", 4, 1L }
                });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "Country", "CreatedAt", "Email", "FirstName", "IsSubscribed", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[] { new DateTime(2003, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Della.Rosenbaum@yahoo.com", "Della", true, 175, 2, "Rosenbaum", 1, 0, 275 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Country", "CreatedAt", "Email", "EmojiName", "FirstName", "ImageId", "IsAdmin", "IsBanned", "IsSubscribed", "Language", "LanguageLevel", "LastName", "Sex", "Status", "Timezone" },
                values: new object[,]
                {
                    { 2L, new DateTime(2003, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Randall_Hegmann56@hotmail.com", "", "Randall", null, true, false, true, 103, 0, "Hegmann", 1, 1, 197 },
                    { 3L, new DateTime(2003, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alfred89@hotmail.com", "", "Alfred", null, true, false, true, 65, 2, "Rohan", 2, 2, 6 },
                    { 4L, new DateTime(2003, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sandra57@gmail.com", "", "Sandra", null, true, false, true, 21, 0, "Satterfield", 2, 1, 71 },
                    { 5L, new DateTime(2003, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 236, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frances.Lemke37@gmail.com", "", "Frances", null, false, false, true, 55, 3, "Lemke", 2, 3, 175 }
                });

            migrationBuilder.InsertData(
                table: "ChatUser",
                columns: new[] { "ChatsId", "UsersId" },
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
                table: "Friends",
                columns: new[] { "Id", "CreatedAt", "FriendshipStatus", "RequesterId", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3L, 3L },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1L, 4L },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2L, 3L },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3L, 5L },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5L, 2L },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3L, 3L },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5L, 5L },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4L, 5L },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3L, 3L },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1L, 3L },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5L, 5L },
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1L, 5L },
                    { 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3L, 2L },
                    { 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5L, 4L },
                    { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4L, 5L },
                    { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2L, 2L },
                    { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5L, 3L },
                    { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5L, 2L }
                });

            migrationBuilder.InsertData(
                table: "LessonTag",
                columns: new[] { "LessonsId", "TagsId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 2L },
                    { 7L, 7L },
                    { 9L, 9L }
                });

            migrationBuilder.InsertData(
                table: "LessonUser",
                columns: new[] { "LessonsId", "SubscribersId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L },
                    { 7L, 4L },
                    { 9L, 5L }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsCanceled", "LanguageLevel", "LimitOfUsers", "MediaPath", "Name", "StartAt", "YoutubeVideoId", "ZoomMeetingLink", "ZoomMeetingLinkHost" },
                values: new object[,]
                {
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, false, 0, null, "https://picsum.photos/640/480/?image=1065", "Oman", new DateTime(2023, 4, 7, 17, 24, 52, 871, DateTimeKind.Utc).AddTicks(8972), "", "", "" },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, false, 0, 143, "https://picsum.photos/640/480/?image=157", "Directives", new DateTime(2023, 4, 8, 12, 1, 17, 422, DateTimeKind.Utc).AddTicks(3002), "", "", "" },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, false, 0, null, "https://picsum.photos/640/480/?image=576", "Platinum", new DateTime(2023, 4, 25, 23, 15, 50, 87, DateTimeKind.Utc).AddTicks(5649), "", "", "" },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, false, 0, null, "https://picsum.photos/640/480/?image=345", "SDD", new DateTime(2023, 4, 6, 15, 15, 36, 36, DateTimeKind.Utc).AddTicks(7593), "", "", "" },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, false, 0, 153, "https://picsum.photos/640/480/?image=194", "navigating", new DateTime(2023, 4, 17, 11, 50, 19, 566, DateTimeKind.Utc).AddTicks(9665), "", "", "" },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, false, 0, 22, "https://picsum.photos/640/480/?image=75", "olive", new DateTime(2023, 4, 6, 9, 54, 33, 817, DateTimeKind.Utc).AddTicks(7535), "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedAt", "IsRead", "RelatedTo", "Text", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Facere possimus eligendi quisquam ullam iure praesentium numquam sapiente distinctio.", 3, 4L },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "A provident rerum nemo dolores debitis dicta voluptatem.", 1, 2L },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Ipsam adipisci illo quidem.", 2, 2L },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Ea dolor animi quod laborum quia perspiciatis sunt tempora.", 3, 5L },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Est quasi incidunt perferendis.", 4, 4L },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Eos enim consequatur et praesentium ad ut beatae eius.", 4, 3L },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Error et velit autem ipsa atque consequuntur vitae sit.", 4, 5L },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Nisi omnis quia est facilis rem architecto laboriosam.", 3, 5L },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "In occaecati perspiciatis.", 4, 4L },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0L, "Recusandae perspiciatis pariatur quod eum sint molestiae quis neque tempora.", 3, 5L },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Nobis nulla dignissimos voluptas nemo cumque tenetur quod et placeat.", 2, 5L },
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Eos similique fuga enim.", 2, 3L },
                    { 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Velit magnam placeat voluptatem itaque.", 1, 5L },
                    { 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Ut atque dolore accusantium soluta cumque perferendis labore magni adipisci.", 2, 5L },
                    { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Quia nobis iusto aspernatur nihil iure ut blanditiis veritatis.", 4, 3L },
                    { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Illum quod atque nulla voluptas quos beatae.", 4, 2L },
                    { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Ab placeat tenetur perferendis et omnis.", 1, 4L },
                    { 21L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0L, "Deserunt sint enim ex sit culpa.", 3, 3L },
                    { 22L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Necessitatibus doloremque omnis facilis unde exercitationem consectetur culpa porro.", 3, 4L },
                    { 24L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Est officia accusamus doloremque perferendis ea.", 3, 5L },
                    { 25L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Laudantium ut amet repellendus enim consequatur.", 3, 2L },
                    { 26L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Sed expedita dolorem aperiam ipsa omnis.", 1, 3L },
                    { 27L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Ipsa quia cupiditate iure necessitatibus asperiores corporis doloremque corporis.", 3, 4L },
                    { 28L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Consectetur enim rerum consectetur magnam perspiciatis ut rem.", 1, 2L },
                    { 29L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Aut modi corrupti corrupti.", 3, 3L },
                    { 30L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0L, "Explicabo provident omnis culpa earum modi eos.", 2, 4L },
                    { 31L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Deleniti labore veritatis dolorum.", 4, 3L },
                    { 33L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Voluptas ut itaque nesciunt.", 1, 5L },
                    { 36L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Perspiciatis qui dignissimos.", 1, 2L },
                    { 37L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0L, "Saepe facere eos eum perferendis nisi.", 1, 2L },
                    { 39L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Ea voluptatibus voluptas sint et et asperiores omnis recusandae saepe.", 2, 2L },
                    { 40L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, "Non consequatur voluptatem in aut quia quo quo.", 2, 2L }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedAt", "LessonId", "Topic" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L, "input Singapore Dollar functionalities Field Branding impactful" },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, "navigating plum pixel" },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Advanced" },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "ability" },
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, "SMTP enterprise" },
                    { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "optical Infrastructure" },
                    { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L, "B2C Platinum system" }
                });

            migrationBuilder.InsertData(
                table: "TagUser",
                columns: new[] { "TagsId", "UsersId" },
                values: new object[,]
                {
                    { 4L, 2L },
                    { 5L, 2L },
                    { 6L, 2L },
                    { 7L, 3L },
                    { 8L, 3L },
                    { 9L, 3L },
                    { 10L, 4L },
                    { 11L, 4L },
                    { 12L, 4L },
                    { 13L, 5L },
                    { 14L, 5L },
                    { 15L, 5L }
                });

            migrationBuilder.InsertData(
                table: "LessonTag",
                columns: new[] { "LessonsId", "TagsId" },
                values: new object[,]
                {
                    { 3L, 3L },
                    { 4L, 4L },
                    { 5L, 5L },
                    { 6L, 6L },
                    { 8L, 8L },
                    { 10L, 10L }
                });

            migrationBuilder.InsertData(
                table: "LessonUser",
                columns: new[] { "LessonsId", "SubscribersId" },
                values: new object[,]
                {
                    { 3L, 2L },
                    { 4L, 2L },
                    { 5L, 3L },
                    { 6L, 3L },
                    { 8L, 4L },
                    { 10L, 5L }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedAt", "LessonId", "Topic" },
                values: new object[,]
                {
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Engineer Intelligent Frozen Mouse Incredible Metal Hat Platinum Thailand" },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Fresh Incredible" },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Concrete complexity" },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Savings Account" },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L, "New Hampshire" },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "EXE olive" },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "generate Ergonomic Steel Towels Functionality South Carolina Accountability" },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Gardens revolutionary Universal input" },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, "deposit auxiliary Avon Intelligent" },
                    { 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Credit Card Account Avon" },
                    { 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Ridges Awesome Malta" },
                    { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, "interface Israel orchestrate Balanced invoice Peso Uruguayo" },
                    { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "navigating fuchsia New York hybrid flexibility" }
                });

            migrationBuilder.InsertData(
                table: "Subquestions",
                columns: new[] { "Id", "CreatedAt", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19L, "Possimus eligendi quisquam ullam iure praesentium numquam sapiente distinctio.\nMolestias tempore voluptatibus ad et.\nHic amet ratione corporis.\nCupiditate soluta a provident rerum nemo dolores debitis.\nVoluptatem labore dolores." },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Et praesentium ad.\nBeatae eius sint omnis voluptas." },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, "Velit autem ipsa atque consequuntur vitae sit nostrum.\nSoluta nisi omnis quia est facilis rem architecto laboriosam.\nCumque dicta in occaecati perspiciatis amet autem." },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Cumque perferendis labore magni adipisci labore corrupti quo." },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Facere quia nobis iusto aspernatur nihil iure ut.\nVeritatis quas hic et illum quod.\nNulla voluptas quos beatae quaerat consequatur.\nAb placeat tenetur perferendis et omnis.\nDoloremque corrupti deserunt sint enim ex sit." },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, "Impedit aut necessitatibus doloremque.\nFacilis unde exercitationem consectetur culpa porro consequatur sed aliquam.\nRem rerum eum harum est ratione voluptate est officia." },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, "Perferendis ea maiores.\nIure laudantium ut amet repellendus enim consequatur.\nPorro voluptate sed expedita dolorem aperiam ipsa omnis dolores.\nOmnis ipsa quia cupiditate.\nNecessitatibus asperiores corporis doloremque corporis nesciunt." },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, "Dolorum ut omnis.\nUt sit nulla." },
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19L, "Voluptatem voluptas ut itaque.\nEsse neque ea molestias.\nExercitationem omnis et eius pariatur est consequatur esse.\nQuia dolorem sequi doloribus corporis." },
                    { 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Perferendis nisi alias et ducimus repudiandae.\nNobis voluptas rerum ullam omnis placeat non ea voluptatibus voluptas.\nEt et asperiores omnis recusandae saepe laborum.\nPorro non consequatur voluptatem in.\nQuia quo quo." },
                    { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, "Nesciunt quidem vel.\nQuibusdam iure labore velit.\nQui dolor velit." },
                    { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Ducimus perspiciatis nostrum ut repudiandae." },
                    { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, "Et velit harum ex." },
                    { 21L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Omnis in voluptatem dolorum debitis velit eos.\nSoluta voluptatem officiis voluptate.\nMollitia at aliquam ut nihil veritatis.\nSequi omnis vel qui.\nDeleniti nihil non perspiciatis modi placeat dolor molestiae." },
                    { 29L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, "Rerum unde ad accusamus." },
                    { 32L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17L, "Aspernatur animi est soluta iusto doloremque doloremque non laudantium velit.\nNumquam corporis numquam ut soluta qui aliquid magni eos commodi.\nId et ipsa velit maiores eum assumenda.\nConsequatur enim excepturi eos temporibus mollitia." },
                    { 33L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, "Corrupti impedit eos qui voluptatibus.\nCorrupti consequuntur dolor provident velit consequuntur excepturi nisi." }
                });

            migrationBuilder.InsertData(
                table: "Subquestions",
                columns: new[] { "Id", "CreatedAt", "QuestionId", "Text" },
                values: new object[] { 36L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Deleniti ab ipsam maiores.\nEum magnam est temporibus mollitia sunt sed perferendis vel.\nRepellendus et sed facilis et distinctio in possimus et.\nRerum ipsum id corrupti eius nisi aut voluptas.\nPerspiciatis temporibus animi cupiditate laudantium ut quam repudiandae tempore." });

            migrationBuilder.InsertData(
                table: "Subquestions",
                columns: new[] { "Id", "CreatedAt", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18L, "Adipisci illo quidem sit dolores." },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18L, "Dolor animi quod laborum quia perspiciatis.\nTempora rerum cupiditate velit est quasi incidunt.\nOmnis voluptas quas.\nBeatae vitae sunt a.\nSed repellendus sapiente accusamus eos." },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Perspiciatis pariatur quod eum sint molestiae quis neque tempora ab.\nAut nobis nulla dignissimos voluptas nemo cumque tenetur.\nEt placeat voluptas nihil sit eos similique fuga.\nDolores ullam suscipit velit magnam.\nVoluptatem itaque sapiente et saepe ut atque dolore." },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18L, "Quibusdam consequatur voluptatem velit expedita eos maxime." },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20L, "Consectetur enim rerum consectetur magnam perspiciatis ut rem.\nOdit dolorem aut modi corrupti corrupti qui.\nPerspiciatis explicabo provident omnis culpa earum modi eos.\nAutem consectetur deleniti." },
                    { 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16L, "Qui dignissimos voluptatum qui in saepe facere." },
                    { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Aliquid aut quaerat adipisci rem.\nEa maxime doloribus qui." },
                    { 22L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Quo a eum corporis repellat dolor fugit voluptas.\nEsse itaque laudantium dolores quis ea excepturi.\nNostrum quo consequatur est omnis cumque reiciendis qui omnis non.\nPraesentium enim explicabo atque culpa repudiandae perferendis ullam.\nEa et aut." },
                    { 23L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Quis aperiam nihil." },
                    { 24L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Rerum sit impedit illum corrupti non et voluptates architecto quaerat." },
                    { 25L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13L, "Modi magnam qui corporis magnam quia blanditiis rerum qui ad.\nDignissimos non tempora.\nVoluptas omnis rem nam ad vel pariatur nostrum.\nFacere blanditiis id enim vitae alias.\nIpsa eius dolores nulla est officia quo eaque quo dolore." },
                    { 26L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13L, "Consequatur quia ut nostrum voluptatem." },
                    { 27L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13L, "Voluptatem id deserunt in.\nQuis a aut unde quibusdam quisquam sit.\nCulpa suscipit voluptatem modi doloremque eum perferendis quod ab." },
                    { 28L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Doloremque magnam quas molestiae ex corrupti neque laboriosam et voluptates.\nSuscipit ducimus facilis ut rem assumenda laborum neque labore.\nEt voluptas omnis doloremque aut ipsa voluptatem aut praesentium et." },
                    { 30L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Veritatis quidem eum eum saepe minus repellat." },
                    { 31L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, "Veritatis voluptates dolore magni rerum velit sapiente.\nEt quod saepe aliquam dignissimos ut praesentium laboriosam deleniti placeat.\nAut aspernatur optio animi." },
                    { 34L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20L, "Fuga deleniti et nobis rerum voluptatem quae.\nOmnis voluptatibus fugiat distinctio.\nNeque molestiae autem quia corporis et quam minima." },
                    { 35L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Eaque iusto repudiandae ut qui et rerum ut.\nVoluptas sint excepturi.\nQui tempore rerum laudantium nam.\nDelectus repellat et eum nihil perferendis odit dolorem." },
                    { 37L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Pariatur maiores illo." },
                    { 38L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Commodi maiores sit voluptatem omnis beatae nostrum cumque." },
                    { 39L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Expedita facilis labore sunt.\nVoluptas minima aliquam ut doloremque." },
                    { 40L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Expedita quod incidunt maxime." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LessonId",
                table: "Questions",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Lessons_LessonId",
                table: "Questions",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
