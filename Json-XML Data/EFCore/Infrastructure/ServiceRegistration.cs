using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
          
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<DepartmentRepository>();
            services.AddScoped<ProjectRepository>();
            services.AddScoped<AssignmentRepository>();

            return services;
        }
    }
}