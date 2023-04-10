using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySpeak.Core.DAL.Migrations
{
    public partial class DuplicateTagsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE LessonTag
                SET TagsId = (
                    SELECT keep_id
                    FROM (
                        SELECT Name, MIN(id) as keep_id
                        FROM Tags
                        GROUP BY Name
                    ) as tag_keep
                    WHERE LessonTag.TagsId IN (
                        SELECT Id
                        FROM Tags
                        WHERE Tags.Name = tag_keep.Name
                    )
                );

                UPDATE TagUser
                SET TagsId = (
                    SELECT keep_id
                    FROM (
                        SELECT Name, MIN(id) as keep_id
                        FROM Tags
                        GROUP BY Name
                    ) as tag_keep
                    WHERE TagUser.TagsId IN (
                        SELECT Id
                        FROM Tags
                        WHERE Tags.Name = tag_keep.Name
                    )
                );

                DELETE FROM Tags
                WHERE Id NOT IN (
                    SELECT MIN(Id)
                    FROM Tags
                    GROUP BY Name
                );");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
