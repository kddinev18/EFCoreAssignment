using EFCoreAssignment.Domain.Interfaces;
using EFCoreAssignment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreAssignment.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddSingleton<IAuthorRepository, AuthorRepository>();
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<ILibraryRepository, LibraryRepository>();
            services.AddSingleton<IBorrowRecordRepository, BorrowRecordRepository>();
        }
    }
}