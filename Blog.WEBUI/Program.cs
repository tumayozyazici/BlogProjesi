using Blog.DATA.Concrete;
using Blog.REPO.Concretes;
using Blog.REPO.Context;
using Blog.REPO.Interfaces;
using Blog.SERVICE.Services.ArticleServices;
using Blog.SERVICE.Services.TopicServices;
using Microsoft.AspNetCore.Identity;

namespace Blog.WEBUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DB
            builder.Services.AddDbContext<BlogContext>();

            //REPO
            builder.Services.AddScoped<IArticleREPO, ArticleREPO>();
            builder.Services.AddScoped<ITopicREPO, TopicREPO>();

            //SERVICE
            builder.Services.AddScoped<IArticleSERVICE, ArticleSERVICE>();
            builder.Services.AddScoped<ITopicSERVICE, TopicSERVICE>();

            //IDENTITY
            builder.Services.AddIdentity<Author, AppRole>()
                .AddEntityFrameworkStores<BlogContext>()
                .AddDefaultTokenProviders();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}