using Assignment.Infrastructure.Contracts;
using Assignment.Infrastructure.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.Webhost
{
    public static class ServiceExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();
        }
    }
}