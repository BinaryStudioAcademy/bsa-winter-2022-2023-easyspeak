﻿// <auto-generated />
using System;
using EasySpeak.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    [DbContext(typeof(EasySpeakCoreContext))]
    [Migration("20230317104834_FixCreatedAtBy")]
    partial class FixCreatedAtBy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.Property<long>("ChatsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("ChatsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ChatUser");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Call", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Chat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Friend", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("FriendshipStatus")
                        .HasColumnType("int");

                    b.Property<long>("RequesterId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RequesterId");

                    b.HasIndex("UserId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Lesson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LimitOfUsers")
                        .HasColumnType("int");

                    b.Property<string>("MediaPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LessonId")
                        .HasColumnType("bigint");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Sample", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Samples");

                    b.HasData(
                        new
                        {
                            Id = 2L,
                            Body = "Eligendi quisquam ullam iure praesentium numquam sapiente distinctio ad. Tempore voluptatibus ad et adipisci hic amet. Corporis soluta cupiditate soluta. Provident rerum nemo dolores debitis dicta voluptatem labore dolores adipisci. Adipisci illo quidem sit dolores. Ea dolor animi quod laborum quia perspiciatis sunt tempora.",
                            CreatedAt = new DateTime(2020, 7, 1, 1, 14, 20, 556, DateTimeKind.Unspecified).AddTicks(7372),
                            CreatedBy = 5L,
                            Title = "hic"
                        },
                        new
                        {
                            Id = 3L,
                            Body = "Incidunt perferendis omnis. Quas voluptatem beatae vitae sunt a ut sed repellendus. Accusamus eos enim consequatur et praesentium ad ut beatae eius. Omnis voluptas error et velit autem ipsa atque consequuntur vitae. Nostrum accusamus soluta nisi.",
                            CreatedAt = new DateTime(2020, 11, 26, 1, 10, 54, 982, DateTimeKind.Unspecified).AddTicks(9175),
                            CreatedBy = 4L,
                            Title = "velit"
                        },
                        new
                        {
                            Id = 4L,
                            Body = "Architecto laboriosam culpa cumque dicta in. Perspiciatis amet autem rerum recusandae perspiciatis pariatur. Eum sint molestiae quis neque tempora ab distinctio. Nobis nulla dignissimos voluptas nemo cumque tenetur quod et placeat. Nihil sit eos similique fuga enim dolores ullam suscipit.",
                            CreatedAt = new DateTime(2021, 1, 18, 12, 14, 38, 642, DateTimeKind.Unspecified).AddTicks(7703),
                            CreatedBy = 1L,
                            Title = "est"
                        },
                        new
                        {
                            Id = 5L,
                            Body = "Sapiente et saepe ut atque dolore accusantium soluta cumque perferendis. Magni adipisci labore corrupti. Ratione et quibusdam consequatur voluptatem velit expedita eos maxime.",
                            CreatedAt = new DateTime(2020, 2, 2, 15, 3, 56, 551, DateTimeKind.Unspecified).AddTicks(1864),
                            CreatedBy = 5L,
                            Title = "placeat"
                        },
                        new
                        {
                            Id = 6L,
                            Body = "Iusto aspernatur nihil iure ut blanditiis veritatis quas. Et illum quod atque nulla voluptas quos beatae quaerat consequatur. Ab placeat tenetur perferendis et omnis. Doloremque corrupti deserunt sint enim ex sit.",
                            CreatedAt = new DateTime(2021, 4, 7, 16, 50, 6, 239, DateTimeKind.Unspecified).AddTicks(5929),
                            CreatedBy = 3L,
                            Title = "facere"
                        },
                        new
                        {
                            Id = 7L,
                            Body = "Doloremque omnis facilis unde exercitationem consectetur culpa porro consequatur sed. Vel rem rerum eum harum. Ratione voluptate est officia accusamus doloremque perferendis ea. Unde iure laudantium ut amet repellendus enim consequatur dolor porro. Sed expedita dolorem aperiam ipsa omnis. Ut omnis ipsa quia cupiditate iure.",
                            CreatedAt = new DateTime(2019, 7, 23, 7, 33, 40, 245, DateTimeKind.Unspecified).AddTicks(9313),
                            CreatedBy = 5L,
                            Title = "impedit"
                        },
                        new
                        {
                            Id = 8L,
                            Body = "Nesciunt placeat et consectetur enim. Consectetur magnam perspiciatis ut rem perspiciatis odit dolorem. Modi corrupti corrupti.",
                            CreatedAt = new DateTime(2020, 1, 27, 9, 1, 30, 801, DateTimeKind.Unspecified).AddTicks(8159),
                            CreatedBy = 3L,
                            Title = "corporis"
                        },
                        new
                        {
                            Id = 9L,
                            Body = "Omnis culpa earum modi eos beatae autem. Deleniti labore veritatis dolorum. Omnis perferendis ut sit nulla autem ut voluptatem voluptas ut.",
                            CreatedAt = new DateTime(2021, 3, 25, 21, 11, 5, 602, DateTimeKind.Unspecified).AddTicks(6614),
                            CreatedBy = 5L,
                            Title = "perspiciatis"
                        },
                        new
                        {
                            Id = 10L,
                            Body = "Molestias porro exercitationem omnis et eius. Est consequatur esse sit quia dolorem sequi doloribus corporis. Perspiciatis qui dignissimos.",
                            CreatedAt = new DateTime(2021, 4, 7, 22, 46, 32, 439, DateTimeKind.Unspecified).AddTicks(5958),
                            CreatedBy = 3L,
                            Title = "esse"
                        },
                        new
                        {
                            Id = 11L,
                            Body = "Eos eum perferendis nisi alias et ducimus repudiandae ut. Voluptas rerum ullam omnis placeat non ea voluptatibus. Sint et et asperiores omnis recusandae saepe laborum enim. Non consequatur voluptatem in aut quia quo quo. Commodi aliquid aut quaerat adipisci. Modi ea maxime doloribus qui sint.",
                            CreatedAt = new DateTime(2021, 3, 24, 14, 25, 37, 776, DateTimeKind.Unspecified).AddTicks(56),
                            CreatedBy = 1L,
                            Title = "in"
                        });
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Subquestion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Subquestions");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<short>("Age")
                        .HasColumnType("smallint");

                    b.Property<int>("Country")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubscribed")
                        .HasColumnType("bit");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<int>("LanguageLevel")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Timezone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LessonTag", b =>
                {
                    b.Property<long>("LessonsId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagsId")
                        .HasColumnType("bigint");

                    b.HasKey("LessonsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("LessonTag");
                });

            modelBuilder.Entity("LessonUser", b =>
                {
                    b.Property<long>("LessonsId")
                        .HasColumnType("bigint");

                    b.Property<long>("SubscribersId")
                        .HasColumnType("bigint");

                    b.HasKey("LessonsId", "SubscribersId");

                    b.HasIndex("SubscribersId");

                    b.ToTable("LessonUser");
                });

            modelBuilder.Entity("TagUser", b =>
                {
                    b.Property<long>("TagsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("TagsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TagUser");
                });

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.HasOne("EasySpeak.Core.DAL.Entities.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasySpeak.Core.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Call", b =>
                {
                    b.HasOne("EasySpeak.Core.DAL.Entities.Chat", "Chat")
                        .WithMany("Calls")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Friend", b =>
                {
                    b.HasOne("EasySpeak.Core.DAL.Entities.User", "Requester")
                        .WithMany("Users")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EasySpeak.Core.DAL.Entities.User", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requester");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Message", b =>
                {
                    b.HasOne("EasySpeak.Core.DAL.Entities.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Notification", b =>
                {
                    b.HasOne("EasySpeak.Core.DAL.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Question", b =>
                {
                    b.HasOne("EasySpeak.Core.DAL.Entities.Lesson", "Lesson")
                        .WithMany("Questions")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Subquestion", b =>
                {
                    b.HasOne("EasySpeak.Core.DAL.Entities.Question", "Question")
                        .WithMany("Subquestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("LessonTag", b =>
                {
                    b.HasOne("EasySpeak.Core.DAL.Entities.Lesson", null)
                        .WithMany()
                        .HasForeignKey("LessonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasySpeak.Core.DAL.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LessonUser", b =>
                {
                    b.HasOne("EasySpeak.Core.DAL.Entities.Lesson", null)
                        .WithMany()
                        .HasForeignKey("LessonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasySpeak.Core.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("SubscribersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TagUser", b =>
                {
                    b.HasOne("EasySpeak.Core.DAL.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasySpeak.Core.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Chat", b =>
                {
                    b.Navigation("Calls");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Lesson", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.Question", b =>
                {
                    b.Navigation("Subquestions");
                });

            modelBuilder.Entity("EasySpeak.Core.DAL.Entities.User", b =>
                {
                    b.Navigation("Friends");

                    b.Navigation("Notifications");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
