using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLearn.Data.Migrations
{
    public partial class CommentAndArticleMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticeView = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleWriter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commenttext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountsUserId = table.Column<int>(type: "int", nullable: false),
                    coursesCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Accounts_accountsUserId",
                        column: x => x.accountsUserId,
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Courses_coursesCourseId",
                        column: x => x.coursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_accountsUserId",
                table: "Comments",
                column: "accountsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_coursesCourseId",
                table: "Comments",
                column: "coursesCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
