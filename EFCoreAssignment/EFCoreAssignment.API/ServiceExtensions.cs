using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using EFCoreAssignment.DataAccess;
using EFCoreAssignment.BusinessLogic;

namespace EFCoreAssignment.API;

public static class ServiceExtensions
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddServices(builder.Configuration);
        builder.Services
            .AddControllers(
                opt => opt.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider()))
            .AddJsonOptions(
                opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
    }

    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddData(builder.Configuration);
    }

    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void AddCors(this WebApplicationBuilder builder)
    {
        var origins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

        builder.Services.AddCors(options =>
        {
            // ReSharper disable once VariableHidesOuterVariable
            options.AddDefaultPolicy(builder =>
            {
                if (origins != null)
                {
                    builder
                        .WithOrigins(origins)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }
            });
        });
    }
    
    public static void AddAutoMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Mappings));
    }
}