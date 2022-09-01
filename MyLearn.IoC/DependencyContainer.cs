using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLearn.Application.Interfaces;
using MyLearn.Application.Services;
using MyLearn.Data.Repository;
using MyLearn.Domain.Interfaces;
using Quartz;
using Quartz.Impl;

namespace MyLearn.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Application Layer
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<ICourseService, CourseService>();
            service.AddScoped<IChatRoomService, ChatRoomService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IRemoveOrdersJobService, RemoveOrdersJobService>();
            service.AddScoped<ICommentService, CommentService>();
            service.AddScoped<IArticleService, ArticleService>();
            service.AddScoped<ICategoryService, CategoryService>();


            //Data Layer
            service.AddScoped<IAccountRepository, AccountRepository>();
            service.AddScoped<ICourseRepository, CourseRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IRemoveOrdersJobRepository, RemoveOrdersJobRepository>();
            service.AddScoped<ICommentRepository, CommentRepository>();
            service.AddScoped<IArticleRepository, ArticleRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();

            //Quartz
            service.AddScoped<ISchedulerFactory, StdSchedulerFactory>();
            service.AddScoped<RemoveOrdersJobService>();
        }
    }
}
