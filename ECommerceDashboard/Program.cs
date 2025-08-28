using ECommerceDashboard.DAL.Contexts;
using ECommerceDashboard.DAL.Interfaces;
using ECommerceDashboard.DAL.Repositoy;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDashboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ECommerceDbContext>(options =>
            options.UseSqlServer("Data Source=DESKTOP-0BIL1GJ;Initial Catalog=ECommDatabase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
            builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
