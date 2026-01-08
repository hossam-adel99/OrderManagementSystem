
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Orders.AddItem;
using OrderManagement.Application.Orders.CreateOrder;
using OrderManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure.Persistence;
using OrderManagement.Infrastructure.Data;
using OrderManagement.Application.Orders.CompleteOrder;
using OrderManagement.Application.Orders.GetOrder;
using OrderManagement.Application.Orders.GetAllOrders;
using OrderManagement.Application.Products.GetAllProducts;
using OrderManagement.Application.Products.GetProduct;

namespace OrderManagement.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("Cs")));

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddScoped<CreateOrderHandler>();
            builder.Services.AddScoped<AddItemHandler>();
            builder.Services.AddScoped<GetOrderHandler>();
            builder.Services.AddScoped<CompleteOrderHandler>();
            builder.Services.AddScoped<GetAllOrdersHandler>();
            builder.Services.AddScoped<GetProductHandler>();
            builder.Services.AddScoped<GetAllProductsHandler>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    builder => builder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });



            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                await context.Database.MigrateAsync();
                await context.SeedProductsAsync();
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors("AllowAngular");

            app.Run();
        }
    }
}
