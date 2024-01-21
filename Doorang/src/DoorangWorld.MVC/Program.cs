using DoorangWorld.Business.Services.Implementes;
using DoorangWorld.Business.Services.Interfaces;
using DoorangWorld.Core.Entities;
using DoorangWorld.Core.Repositories;
using DoorangWorld.Data.DAL;
using DoorangWorld.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DoorangWorld.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IsettingService,SettingService>();
            builder.Services.AddScoped<ISettingRepository,SettingRepository>();
            builder.Services.AddScoped<IExploreWorldRepository,ExploreWorldRepository>();
            builder.Services.AddScoped<IExploreWorldService,ExploreWorldService>();
            builder.Services.AddScoped<IAccountService,AccountService>();

            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer("Server=;Database=DoorangMVC-RemziHesenov;Trusted_Connection=true;") ;

            });
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
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
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}