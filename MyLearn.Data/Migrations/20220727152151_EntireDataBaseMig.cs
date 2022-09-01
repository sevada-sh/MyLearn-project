using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLearn.Data.Migrations
{
    public partial class EntireDataBaseMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CourseTeacher = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CoursePrice = table.Column<double>(type: "float", nullable: false),
                    CourseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    CourseVideosCount = table.Column<int>(type: "int", nullable: false),
                    CourseLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseIsHolding = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryToCourses",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryToCourses", x => new { x.CourseId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryToCourses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryToCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "برنامه نویسی وب" },
                    { 2, "برنامه نویسی موبایل" },
                    { 3, "طراحی وب" },
                    { 4, "بانک های اطلاعاتی" },
                    { 5, "سئو" },
                    { 6, "امنیت" },
                    { 7, "گرافیک" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 1, 500.0m, 3 },
                    { 2, 400.0m, 4 },
                    { 3, 300.0m, 5 },
                    { 4, 200.0m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseDescription", "CourseIsHolding", "CourseLevel", "CourseName", "CoursePrice", "CourseTeacher", "CourseTime", "CourseVideosCount", "OrderId" },
                values: new object[,]
                {
                    { 1, "این دوره تستی است", true, "متوسط", "دوره ی Asp.Net Core", 230.0, "ایمان مداینی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 2, "این دوره تستی است", false, "پیشرفته", "دوره ی HTML و CSS", 330.0, "حسن خسروجردی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, "این دوره تستی است", true, "مقدماتی", "دوره ی Python", 500.0, "اردوخانی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, "این دوره تستی است", false, "متوسط", "دوره ی Django", 650.0, "اردوخانی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "CategoryToCourses",
                columns: new[] { "CategoryId", "CourseId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 6, 4 },
                    { 7, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryToCourses_CategoryId",
                table: "CategoryToCourses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OrderId",
                table: "Courses",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CategoryToCourses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
