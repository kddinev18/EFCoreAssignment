using AutoMapper;
using json2_assignment.DM.Models;
using json2_assignment.Domain.DTOs;

namespace json2_assignment.Domain;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Sale, SaleDto>().ReverseMap();
    }
}