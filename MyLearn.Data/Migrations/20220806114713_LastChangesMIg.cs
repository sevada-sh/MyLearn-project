using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLearn.Data.Migrations
{
    public partial class LastChangesMIg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Accounts_accountsUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ArticleTitle",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "accountsUserId",
                table: "Comments",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_accountsUserId",
                table: "Comments",
                newName: "IX_Comments_AccountId");

            migrationBuilder.AddColumn<string>(
                name: "CourseTags",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTeacher",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWriter",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "CourseTags",
                value: "asp.net,asp,.net,asp.net core,");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "CourseTags",
                value: "asp.net,asp,.net,asp.net core,");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3,
                column: "CourseTags",
                value: "asp.net,asp,.net,asp.net core,");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4,
                column: "CourseTags",
                value: "asp.net,asp,.net,asp.net core,");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Accounts_AccountId",
                table: "Comments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Accounts_AccountId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CourseTags",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsTeacher",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsWriter",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Comments",
                newName: "accountsUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AccountId",
                table: "Comments",
                newName: "IX_Comments_accountsUserId");

            migrationBuilder.AddColumn<string>(
                name: "ArticleTitle",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Accounts_accountsUserId",
                table: "Comments",
                column: "accountsUserId",
                principalTable: "Accounts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
