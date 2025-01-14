using JsonTRI.Application.Services;
using JsonTRI.Application.Services.Persistance;
using JsonTRI.Domain.Interfaces;
using JsonTRI.Domain.Entities;
using JsonTRI.Infrastucture.Persistance;
using JsonTRI.Infrastucture.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text.Json;

namespace JsonTRI.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register repositories
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBorrowRecordRepository, BorrowRecordRepository>();
            builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

            // Register services
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBorrowRecordService, BorrowRecordService>();
            builder.Services.AddScoped<ILibraryService, LibraryService>();

            // Add controllers, Swagger, etc.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Seed data
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                SeedData(dbContext);
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

        private static void SeedData(ApplicationDbContext dbContext)
        {
            try
            {
                // Load and parse JSON data
                var dataFilePath = Path.Combine(Directory.GetCurrentDirectory(), "seedData.json");
                var jsonData = File.ReadAllText(dataFilePath);
                var data = JsonSerializer.Deserialize<SeedData>(jsonData);

                if (data != null)
                {
                    if (!dbContext.Authors.Any())
                    {
                        dbContext.Authors.AddRange(data.Authors);
                        dbContext.Books.AddRange(data.Books);
                        dbContext.BorrowRecords.AddRange(data.BorrowRecords);
                        dbContext.Libraries.AddRange(data.Libraries);
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
    }

    // Define a class to map your JSON data for seeding
    public class SeedData
    {
        public List<Author> Authors { get; set; }
        public List<Book> Books { get; set; }
        public List<BorrowRecord> BorrowRecords { get; set; }
        public List<Library> Libraries { get; set; }
    }
}
