﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLearn.Data.Context;

#nullable disable

namespace MyLearn.Data.Migrations
{
    [DbContext(typeof(MyLearnContext))]
    [Migration("20220802150202_CommentAndArticleMig")]
    partial class CommentAndArticleMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyLearn.Domain.Models.Account", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleId"), 1L, 1);

                    b.Property<int>("ArticeView")
                        .HasColumnType("int");

                    b.Property<string>("ArticleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleWriter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ArticleId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "برنامه نویسی وب"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "برنامه نویسی موبایل"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "طراحی وب"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "بانک های اطلاعاتی"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "سئو"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "امنیت"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "گرافیک"
                        });
                });

            modelBuilder.Entity("MyLearn.Domain.Models.CategoryToCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryToCourses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            CourseId = 1,
                            CategoryId = 2
                        },
                        new
                        {
                            CourseId = 1,
                            CategoryId = 3
                        },
                        new
                        {
                            CourseId = 1,
                            CategoryId = 4
                        },
                        new
                        {
                            CourseId = 1,
                            CategoryId = 5
                        },
                        new
                        {
                            CourseId = 1,
                            CategoryId = 6
                        },
                        new
                        {
                            CourseId = 1,
                            CategoryId = 7
                        },
                        new
                        {
                            CourseId = 2,
                            CategoryId = 1
                        },
                        new
                        {
                            CourseId = 2,
                            CategoryId = 2
                        },
                        new
                        {
                            CourseId = 2,
                            CategoryId = 3
                        },
                        new
                        {
                            CourseId = 2,
                            CategoryId = 4
                        },
                        new
                        {
                            CourseId = 2,
                            CategoryId = 5
                        },
                        new
                        {
                            CourseId = 2,
                            CategoryId = 6
                        },
                        new
                        {
                            CourseId = 2,
                            CategoryId = 7
                        },
                        new
                        {
                            CourseId = 3,
                            CategoryId = 1
                        },
                        new
                        {
                            CourseId = 3,
                            CategoryId = 2
                        },
                        new
                        {
                            CourseId = 3,
                            CategoryId = 3
                        },
                        new
                        {
                            CourseId = 3,
                            CategoryId = 4
                        },
                        new
                        {
                            CourseId = 3,
                            CategoryId = 5
                        },
                        new
                        {
                            CourseId = 3,
                            CategoryId = 6
                        },
                        new
                        {
                            CourseId = 3,
                            CategoryId = 7
                        },
                        new
                        {
                            CourseId = 4,
                            CategoryId = 1
                        },
                        new
                        {
                            CourseId = 4,
                            CategoryId = 2
                        },
                        new
                        {
                            CourseId = 4,
                            CategoryId = 3
                        },
                        new
                        {
                            CourseId = 4,
                            CategoryId = 4
                        },
                        new
                        {
                            CourseId = 4,
                            CategoryId = 5
                        },
                        new
                        {
                            CourseId = 4,
                            CategoryId = 6
                        },
                        new
                        {
                            CourseId = 4,
                            CategoryId = 7
                        });
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("Commenttext")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("accountsUserId")
                        .HasColumnType("int");

                    b.Property<int>("coursesCourseId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("accountsUserId");

                    b.HasIndex("coursesCourseId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<bool>("CourseIsHolding")
                        .HasColumnType("bit");

                    b.Property<string>("CourseLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("CoursePrice")
                        .HasColumnType("float");

                    b.Property<string>("CourseTeacher")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CourseTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CourseVideosCount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseDescription = "این دوره تستی است",
                            CourseIsHolding = true,
                            CourseLevel = "متوسط",
                            CourseName = "دوره ی Asp.Net Core",
                            CoursePrice = 230.0,
                            CourseTeacher = "ایمان مداینی",
                            CourseTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseVideosCount = 0,
                            OrderId = 1
                        },
                        new
                        {
                            CourseId = 2,
                            CourseDescription = "این دوره تستی است",
                            CourseIsHolding = false,
                            CourseLevel = "پیشرفته",
                            CourseName = "دوره ی HTML و CSS",
                            CoursePrice = 330.0,
                            CourseTeacher = "حسن خسروجردی",
                            CourseTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseVideosCount = 2,
                            OrderId = 2
                        },
                        new
                        {
                            CourseId = 3,
                            CourseDescription = "این دوره تستی است",
                            CourseIsHolding = true,
                            CourseLevel = "مقدماتی",
                            CourseName = "دوره ی Python",
                            CoursePrice = 500.0,
                            CourseTeacher = "اردوخانی",
                            CourseTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseVideosCount = 3,
                            OrderId = 3
                        },
                        new
                        {
                            CourseId = 4,
                            CourseDescription = "این دوره تستی است",
                            CourseIsHolding = false,
                            CourseLevel = "متوسط",
                            CourseName = "دوره ی Django",
                            CoursePrice = 650.0,
                            CourseTeacher = "اردوخانی",
                            CourseTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CourseVideosCount = 0,
                            OrderId = 4
                        });
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Factor", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinally")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("accountsUserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("accountsUserId");

                    b.ToTable("Factors");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.FactorDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailId"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("FactorId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DetailId");

                    b.HasIndex("CourseId");

                    b.HasIndex("FactorId");

                    b.ToTable("FactorDetails");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            Price = 500.0m,
                            QuantityInStock = 3
                        },
                        new
                        {
                            OrderId = 2,
                            Price = 400.0m,
                            QuantityInStock = 4
                        },
                        new
                        {
                            OrderId = 3,
                            Price = 300.0m,
                            QuantityInStock = 5
                        },
                        new
                        {
                            OrderId = 4,
                            Price = 200.0m,
                            QuantityInStock = 2
                        });
                });

            modelBuilder.Entity("MyLearn.Domain.Models.CategoryToCourse", b =>
                {
                    b.HasOne("MyLearn.Domain.Models.Category", "Category")
                        .WithMany("CategoryToCourses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyLearn.Domain.Models.Course", "Course")
                        .WithMany("CategoryToCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Comment", b =>
                {
                    b.HasOne("MyLearn.Domain.Models.Account", "accounts")
                        .WithMany("comments")
                        .HasForeignKey("accountsUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyLearn.Domain.Models.Course", "courses")
                        .WithMany()
                        .HasForeignKey("coursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("accounts");

                    b.Navigation("courses");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Course", b =>
                {
                    b.HasOne("MyLearn.Domain.Models.Order", "Order")
                        .WithOne("Course")
                        .HasForeignKey("MyLearn.Domain.Models.Course", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Factor", b =>
                {
                    b.HasOne("MyLearn.Domain.Models.Account", "accounts")
                        .WithMany("factors")
                        .HasForeignKey("accountsUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("accounts");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.FactorDetail", b =>
                {
                    b.HasOne("MyLearn.Domain.Models.Course", "courses")
                        .WithMany("factordetails")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyLearn.Domain.Models.Factor", "factor")
                        .WithMany("factordetails")
                        .HasForeignKey("FactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("courses");

                    b.Navigation("factor");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Account", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("factors");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Category", b =>
                {
                    b.Navigation("CategoryToCourses");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Course", b =>
                {
                    b.Navigation("CategoryToCourses");

                    b.Navigation("factordetails");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Factor", b =>
                {
                    b.Navigation("factordetails");
                });

            modelBuilder.Entity("MyLearn.Domain.Models.Order", b =>
                {
                    b.Navigation("Course")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
