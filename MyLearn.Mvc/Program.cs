using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLearn.Data.Context;
using MyLearn.IoC;
using MyLearn.Mvc;
using MyLearn.Mvc.Jobs;
using Quartz;
using System.Security.Claims;
using Quartz.Spi;

var builder = WebApplication.CreateBuilder(args);


//#region Quartz

//builder.Services.AddSingleton(new JobSchedule(jobtype: typeof(RemoveOrdersJob), cronexpression:
//    "2 2 */2 * * "
//));

//builder.Services.AddScoped<IJobFactory, JobFactory>();
//builder.Services.AddHostedService<QuartzHostedService>();
//#endregion

builder.Services.AddControllersWithViews();

#region Context

builder.Services.AddDbContext<MyLearnContext>(option =>
option.UseSqlServer("name=ConnectionStrings:MyLearnCon"));

builder.Services.AddDbContext<IdentityDbContext>(option =>
option.UseSqlServer("name=ConnectionStrings:MyLearnCon", optionbuilder =>
             optionbuilder.MigrationsAssembly("MyLearn.Data")));

#endregion

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>().AddDefaultTokenProviders();


#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.LoginPath = "/Login";
    option.LogoutPath = "/Logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(30);
}).AddGoogle(options =>
{
    options.ClientId = "324210477250-vjh2ltjtf3q0lkneniihaco3vtddc94u.apps.googleusercontent.com";
    options.ClientSecret = "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";
});

#endregion

builder.Services.AddSignalR();

#region Authorization

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("AdminOnly",
        policy1 => policy1.RequireClaim("AdminNumber"));

    option.AddPolicy("WriterOnly",
        policy2 => policy2.RequireClaim("WriterNumber"));

    option.AddPolicy("TeacherOnly",
        policy3 => policy3.RequireClaim("TeacherNumber"));
});

#endregion


builder.Services.AddRazorPages();

builder.Services.AddMvc();

RegisterService(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();




#region myHandler


app.MapHub<ChatHub>("/chatHub");
app.MapHub<AgentHub>("/agentHub");

static void myHandler(IApplicationBuilder app)
{
    app.Use(async (context, next) =>
    {
        if (context.Request.Path.StartsWithSegments("/Admin"))
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Response.Redirect("/Account/Login");
            }
            else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
            {
                context.Response.Redirect("/Account/Login");
            }
            else
            {
                await next.Invoke();
            }
        }
    });
}

#endregion


#region NotFound

app.UseStatusCodePagesWithRedirects("~/Home/NotFound");

#endregion


app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();

    endpoints.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

});




static void RegisterService(IServiceCollection service)
{
    DependencyContainer.RegisterServices(service);
}

app.MapRazorPages();

app.Run();

