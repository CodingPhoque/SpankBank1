using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SpankBank1.DAL;
using SpankBank1.Interface;
using SpankBank1.Models; // Import the namespace for your models
using SpankBank1.Services;

namespace SpankBank1
{
    public class Program
    {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IAccountService, BankService>();

        

            builder.Services.AddRazorPages();

            // Register BankContext with the connection string from appsettings.json
            builder.Services.AddDbContext<BankContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

        

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Make sure this comes before authorization
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}

