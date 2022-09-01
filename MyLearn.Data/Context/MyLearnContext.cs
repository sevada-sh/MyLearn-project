using Microsoft.EntityFrameworkCore;
using MyLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearn.Data.Context
{
    public class MyLearnContext : DbContext
    {
        public MyLearnContext(DbContextOptions<MyLearnContext> options) : base(options)
        {


        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CategoryToCourse> CategoryToCourses { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<FactorDetail> FactorDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CategoryToCourse>().HasKey(t => new { t.CourseId, t.CategoryId });

            modelBuilder.Entity<Course>(
                p =>
               {
                   p.HasKey(w => w.CourseId);
               });

            modelBuilder.Entity<Order>(
                p =>
                {
                    p.HasKey(w => w.OrderId);
                });

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, OrderId = 1, CourseName = "دوره ی Asp.Net Core", CourseTeacher = "ایمان مداینی", CoursePrice = 230.000, CourseDescription = "این دوره تستی است", CourseLevel = "متوسط", CourseIsHolding = true, CourseVideosCount = 0, CourseTags = "asp.net,asp,.net,asp.net core," },
                new Course { CourseId = 2, OrderId = 2, CourseName = "دوره ی HTML و CSS", CourseTeacher = "حسن خسروجردی", CoursePrice = 330.000, CourseDescription = "این دوره تستی است", CourseLevel = "پیشرفته", CourseIsHolding = false, CourseVideosCount = 2, CourseTags = "asp.net,asp,.net,asp.net core," },
                new Course { CourseId = 3, OrderId = 3, CourseName = "دوره ی Python", CourseTeacher = "اردوخانی", CoursePrice = 500.000, CourseDescription = "این دوره تستی است", CourseLevel = "مقدماتی", CourseIsHolding = true, CourseVideosCount = 3, CourseTags = "asp.net,asp,.net,asp.net core," },
                new Course { CourseId = 4, OrderId = 4, CourseName = "دوره ی Django", CourseTeacher = "اردوخانی", CoursePrice = 650.000, CourseDescription = "این دوره تستی است", CourseLevel = "متوسط", CourseIsHolding = false, CourseVideosCount = 0, CourseTags = "asp.net,asp,.net,asp.net core," }
            );

            modelBuilder.Entity<Article>().HasData(

                new Article { ArticleId = 1, ArticleName = "زبان برنامه نویسی سی پلاس پلاس چه کاربرد هایی دارد؟", ArticleWriter = "ایمان مداینی", ArticleText = "ما در این مطلب قصد داریم بیشتر درباره زبان برنامه نویسی سی پلاس پلاس و کاربردهای مختلف آن صحبت کنیم و اطلاعاتی را درباره نرم افزارهایی که با استفاده از این زبان برنامه نویسی پرکاربرد طراحی شده اند به شما ارائه دهیم. زبان برنامه نویسی سی پلاس پلاس یکی از پرکاربردترین زبان های برنامه نویسی در دنیا است که قابلیت های متنوعی را به شما ارائه می دهد. علاوه بر این بسیاری از ابزارهایی که امروزه به صورت روزمره از آنها استفاده می کنیم نیز به همین زبان نوشته شده اند و به همین علت نیز آشنایی با کاربردهای مختلف آن می تواند برای شما مفید و کاربردی باشد. اگر شما هم جزء آن دسته از افرادی هستید که علاقه مند به داشتن اطلاعات بیشتر درباره کاربردهای مختلف زبان سی پلاس پلاس هستید به شما پیشنهاد می کنیم ادامه این مطلب را با دقت مطالعه کنید.", ArticeView = 0 },
                new Article { ArticleId = 2, ArticleName = "زبان برنامه نویسی سی پلاس پلاس چه کاربرد هایی دارد؟", ArticleWriter = "ایمان مداینی", ArticleText = "ما در این مطلب قصد داریم بیشتر درباره زبان برنامه نویسی سی پلاس پلاس و کاربردهای مختلف آن صحبت کنیم و اطلاعاتی را درباره نرم افزارهایی که با استفاده از این زبان برنامه نویسی پرکاربرد طراحی شده اند به شما ارائه دهیم. زبان برنامه نویسی سی پلاس پلاس یکی از پرکاربردترین زبان های برنامه نویسی در دنیا است که قابلیت های متنوعی را به شما ارائه می دهد. علاوه بر این بسیاری از ابزارهایی که امروزه به صورت روزمره از آنها استفاده می کنیم نیز به همین زبان نوشته شده اند و به همین علت نیز آشنایی با کاربردهای مختلف آن می تواند برای شما مفید و کاربردی باشد. اگر شما هم جزء آن دسته از افرادی هستید که علاقه مند به داشتن اطلاعات بیشتر درباره کاربردهای مختلف زبان سی پلاس پلاس هستید به شما پیشنهاد می کنیم ادامه این مطلب را با دقت مطالعه کنید.", ArticeView = 0 },
                new Article { ArticleId = 3, ArticleName = "زبان برنامه نویسی سی پلاس پلاس چه کاربرد هایی دارد؟", ArticleWriter = "ایمان مداینی", ArticleText = "ما در این مطلب قصد داریم بیشتر درباره زبان برنامه نویسی سی پلاس پلاس و کاربردهای مختلف آن صحبت کنیم و اطلاعاتی را درباره نرم افزارهایی که با استفاده از این زبان برنامه نویسی پرکاربرد طراحی شده اند به شما ارائه دهیم. زبان برنامه نویسی سی پلاس پلاس یکی از پرکاربردترین زبان های برنامه نویسی در دنیا است که قابلیت های متنوعی را به شما ارائه می دهد. علاوه بر این بسیاری از ابزارهایی که امروزه به صورت روزمره از آنها استفاده می کنیم نیز به همین زبان نوشته شده اند و به همین علت نیز آشنایی با کاربردهای مختلف آن می تواند برای شما مفید و کاربردی باشد. اگر شما هم جزء آن دسته از افرادی هستید که علاقه مند به داشتن اطلاعات بیشتر درباره کاربردهای مختلف زبان سی پلاس پلاس هستید به شما پیشنهاد می کنیم ادامه این مطلب را با دقت مطالعه کنید.", ArticeView = 0 },
                new Article { ArticleId = 4, ArticleName = "زبان برنامه نویسی سی پلاس پلاس چه کاربرد هایی دارد؟", ArticleWriter = "ایمان مداینی", ArticleText = "ما در این مطلب قصد داریم بیشتر درباره زبان برنامه نویسی سی پلاس پلاس و کاربردهای مختلف آن صحبت کنیم و اطلاعاتی را درباره نرم افزارهایی که با استفاده از این زبان برنامه نویسی پرکاربرد طراحی شده اند به شما ارائه دهیم. زبان برنامه نویسی سی پلاس پلاس یکی از پرکاربردترین زبان های برنامه نویسی در دنیا است که قابلیت های متنوعی را به شما ارائه می دهد. علاوه بر این بسیاری از ابزارهایی که امروزه به صورت روزمره از آنها استفاده می کنیم نیز به همین زبان نوشته شده اند و به همین علت نیز آشنایی با کاربردهای مختلف آن می تواند برای شما مفید و کاربردی باشد. اگر شما هم جزء آن دسته از افرادی هستید که علاقه مند به داشتن اطلاعات بیشتر درباره کاربردهای مختلف زبان سی پلاس پلاس هستید به شما پیشنهاد می کنیم ادامه این مطلب را با دقت مطالعه کنید.", ArticeView = 0 },
                new Article { ArticleId = 5, ArticleName = "زبان برنامه نویسی سی پلاس پلاس چه کاربرد هایی دارد؟", ArticleWriter = "ایمان مداینی", ArticleText = "ما در این مطلب قصد داریم بیشتر درباره زبان برنامه نویسی سی پلاس پلاس و کاربردهای مختلف آن صحبت کنیم و اطلاعاتی را درباره نرم افزارهایی که با استفاده از این زبان برنامه نویسی پرکاربرد طراحی شده اند به شما ارائه دهیم. زبان برنامه نویسی سی پلاس پلاس یکی از پرکاربردترین زبان های برنامه نویسی در دنیا است که قابلیت های متنوعی را به شما ارائه می دهد. علاوه بر این بسیاری از ابزارهایی که امروزه به صورت روزمره از آنها استفاده می کنیم نیز به همین زبان نوشته شده اند و به همین علت نیز آشنایی با کاربردهای مختلف آن می تواند برای شما مفید و کاربردی باشد. اگر شما هم جزء آن دسته از افرادی هستید که علاقه مند به داشتن اطلاعات بیشتر درباره کاربردهای مختلف زبان سی پلاس پلاس هستید به شما پیشنهاد می کنیم ادامه این مطلب را با دقت مطالعه کنید.", ArticeView = 0 },
                new Article { ArticleId = 6, ArticleName = "زبان برنامه نویسی سی پلاس پلاس چه کاربرد هایی دارد؟", ArticleWriter = "ایمان مداینی", ArticleText = "ما در این مطلب قصد داریم بیشتر درباره زبان برنامه نویسی سی پلاس پلاس و کاربردهای مختلف آن صحبت کنیم و اطلاعاتی را درباره نرم افزارهایی که با استفاده از این زبان برنامه نویسی پرکاربرد طراحی شده اند به شما ارائه دهیم. زبان برنامه نویسی سی پلاس پلاس یکی از پرکاربردترین زبان های برنامه نویسی در دنیا است که قابلیت های متنوعی را به شما ارائه می دهد. علاوه بر این بسیاری از ابزارهایی که امروزه به صورت روزمره از آنها استفاده می کنیم نیز به همین زبان نوشته شده اند و به همین علت نیز آشنایی با کاربردهای مختلف آن می تواند برای شما مفید و کاربردی باشد. اگر شما هم جزء آن دسته از افرادی هستید که علاقه مند به داشتن اطلاعات بیشتر درباره کاربردهای مختلف زبان سی پلاس پلاس هستید به شما پیشنهاد می کنیم ادامه این مطلب را با دقت مطالعه کنید.", ArticeView = 0 },
                new Article { ArticleId = 7, ArticleName = "زبان برنامه نویسی سی پلاس پلاس چه کاربرد هایی دارد؟", ArticleWriter = "ایمان مداینی", ArticleText = "ما در این مطلب قصد داریم بیشتر درباره زبان برنامه نویسی سی پلاس پلاس و کاربردهای مختلف آن صحبت کنیم و اطلاعاتی را درباره نرم افزارهایی که با استفاده از این زبان برنامه نویسی پرکاربرد طراحی شده اند به شما ارائه دهیم. زبان برنامه نویسی سی پلاس پلاس یکی از پرکاربردترین زبان های برنامه نویسی در دنیا است که قابلیت های متنوعی را به شما ارائه می دهد. علاوه بر این بسیاری از ابزارهایی که امروزه به صورت روزمره از آنها استفاده می کنیم نیز به همین زبان نوشته شده اند و به همین علت نیز آشنایی با کاربردهای مختلف آن می تواند برای شما مفید و کاربردی باشد. اگر شما هم جزء آن دسته از افرادی هستید که علاقه مند به داشتن اطلاعات بیشتر درباره کاربردهای مختلف زبان سی پلاس پلاس هستید به شما پیشنهاد می کنیم ادامه این مطلب را با دقت مطالعه کنید.", ArticeView = 0 }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "برنامه نویسی وب" },
                new Category { CategoryId = 2, CategoryName = "برنامه نویسی موبایل" },
                new Category { CategoryId = 3, CategoryName = "طراحی وب" },
                new Category { CategoryId = 4, CategoryName = "بانک های اطلاعاتی" },
                new Category { CategoryId = 5, CategoryName = "سئو" },
                new Category { CategoryId = 6, CategoryName = "امنیت" },
                new Category { CategoryId = 7, CategoryName = "گرافیک" }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, Price = 500.0M, QuantityInStock = 3 },
                new Order { OrderId = 2, Price = 400.0M, QuantityInStock = 4 },
                new Order { OrderId = 3, Price = 300.0M, QuantityInStock = 5 },
                new Order { OrderId = 4, Price = 200.0M, QuantityInStock = 2 }
            );

            modelBuilder.Entity<CategoryToCourse>().HasData(
                new CategoryToCourse { CategoryId = 1, CourseId = 1 },
                new CategoryToCourse { CategoryId = 2, CourseId = 1 },
                new CategoryToCourse { CategoryId = 3, CourseId = 1 },
                new CategoryToCourse { CategoryId = 4, CourseId = 1 },
                new CategoryToCourse { CategoryId = 5, CourseId = 1 },
                new CategoryToCourse { CategoryId = 6, CourseId = 1 },
                new CategoryToCourse { CategoryId = 7, CourseId = 1 },
                new CategoryToCourse { CategoryId = 1, CourseId = 2 },
                new CategoryToCourse { CategoryId = 2, CourseId = 2 },
                new CategoryToCourse { CategoryId = 3, CourseId = 2 },
                new CategoryToCourse { CategoryId = 4, CourseId = 2 },
                new CategoryToCourse { CategoryId = 5, CourseId = 2 },
                new CategoryToCourse { CategoryId = 6, CourseId = 2 },
                new CategoryToCourse { CategoryId = 7, CourseId = 2 },
                new CategoryToCourse { CategoryId = 1, CourseId = 3 },
                new CategoryToCourse { CategoryId = 2, CourseId = 3 },
                new CategoryToCourse { CategoryId = 3, CourseId = 3 },
                new CategoryToCourse { CategoryId = 4, CourseId = 3 },
                new CategoryToCourse { CategoryId = 5, CourseId = 3 },
                new CategoryToCourse { CategoryId = 6, CourseId = 3 },
                new CategoryToCourse { CategoryId = 7, CourseId = 3 },
                new CategoryToCourse { CategoryId = 1, CourseId = 4 },
                new CategoryToCourse { CategoryId = 2, CourseId = 4 },
                new CategoryToCourse { CategoryId = 3, CourseId = 4 },
                new CategoryToCourse { CategoryId = 4, CourseId = 4 },
                new CategoryToCourse { CategoryId = 5, CourseId = 4 },
                new CategoryToCourse { CategoryId = 6, CourseId = 4 },
                new CategoryToCourse { CategoryId = 7, CourseId = 4 }

             );

            base.OnModelCreating(modelBuilder);
        }

    }
}

