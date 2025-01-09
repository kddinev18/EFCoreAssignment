using EFCoreAssignment.Data.Data.Contexts;
using EFCoreAssignment.Data.Data.Repositories;
using EFCoreAssignment.Data.Interfaces;
using EFCoreAssignment.Core.Interfaces;
using EFCoreAssignment.Core.Services;

namespace EFCoreAssignment.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EFCoreAssignmentDbContext>();

            builder.Services.AddScoped<IBaseRepository, BaseRepository>();

            builder.Services.AddScoped<IBaseService, BaseService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
