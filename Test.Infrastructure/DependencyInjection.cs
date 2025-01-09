using Test.Infrastructure.Contracts;
using Test.Infrastructure.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Infrastructure;

public static class DependencyInjection
{
   public static void AddServices(this IServiceCollection service)
    {
        service
            .AddScoped<ICustomerService, CustomerService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<ISaleService, SaleService>();
    }
}