namespace Task;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task.DAL.Context;
using Task.DAL.Repository;
using Task.Domain.Service;
using Task.Infrastructure.Service;
using Task.Infrastructure.Interface;
using Task.Infrastructure.Repository;
using Task.Infrastructre.IService;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    services.AddScoped<IProjectRepository, ProjectRepository>();
    services.AddScoped<IAssignmentRepository, AssignmentRepository>();
    services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    
    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddScoped<IProjectService, ProjectService>();
    services.AddScoped<IAssignmentService, AssignmentService>();

    services.AddControllers();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
