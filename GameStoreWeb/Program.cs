using GameStoreWeb.Data.Services;
using GameStoreWeb.Data;
using Microsoft.EntityFrameworkCore;
using GameStoreWeb.Data.ViewModels;
using GameStoreWeb.Data.Cart;
using GameStoreWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace GameStoreWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //Services configuration
              builder.Services.AddScoped<IDeveloperService, DeveloperService>();
              builder.Services.AddScoped<IProducersService, ProducersService>();
        
              builder.Services.AddScoped<IGamesService, GamesService>();
              builder.Services.AddScoped<IOrdersService, OrdersService>();
              builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
              builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));
               //Authentication and authorization
              builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
              builder.Services.AddMemoryCache();
              builder.Services.AddSession();
              builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            builder.Services.AddControllersWithViews();
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
            app.UseSession();

            //Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization(); 

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //seed database
            AppDbInitializer.Seed(app);
            AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
            app.Run();

        }
    }
}