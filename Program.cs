using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpankBank1.DAL;
using SpankBank1.Interface;
using SpankBank1.Services;

namespace SpankBank1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Test
         
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
