using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.DataAccess.Repository;
using EFCoreAssignment.Infrastructure.Contracts;
using EFCoreAssignment.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment;

public static class ServiceConfiguratorExtensions
{
    public static void AddContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
    }
    
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ISaleService, SaleService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<CustomerRepository>();
        builder.Services.AddScoped<CategoryRepository>();
        builder.Services.AddScoped<SaleRepository>();
        builder.Services.AddScoped<ProductRepository>();
    }
}