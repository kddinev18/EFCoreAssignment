using JSON1.Application.Services.Persistance;
using JSON1.Application.Services;
using JSON1.Domain.Interfaces;
using JSON1.Infrastucture.Persistance;
using JSON1.Infrastucture.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text.Json;

namespace JSON1.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb"));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var usersJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "json1.json"));
                    var jsonData = JsonSerializer.Deserialize<JsonData>(usersJson);

                    Console.WriteLine("Seeding data...");
                    if (jsonData != null)
                    {
                        if (!dbContext.Users.Any())
                        {
                            dbContext.Users.AddRange(jsonData.Users);
                            dbContext.Products.AddRange(jsonData.Products);
                            dbContext.Orders.AddRange(jsonData.Orders);
                            dbContext.OrderDetails.AddRange(jsonData.OrderDetails);
                            dbContext.SaveChanges();
                            Console.WriteLine("Data seeded successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Data already exists.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("JSON file is empty or malformed.");
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}. Please ensure the JSON file is located in the correct directory.");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error parsing JSON file: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error initializing data: {ex.Message}");
                }
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
