// <copyright file="MappingProfile.cs" company="ORB">
// Copyright (c) ORB. All rights reserved.
// </copyright>

using AutoMapper;
using Test.Data.Models;
using Test.Domain.Models.Category;
using Test.Domain.Models.Customer;
using Test.Domain.Models.Product;
using Test.Domain.Models.Sale;

namespace Test.WebHost.Models;


public class MappingProfile : Profile
{
   
    public MappingProfile()
    {
        this.CreateMap<Category, CategoryVM>();
        this.CreateMap<CategoryIM, Category>();
        this.CreateMap<CategoryUM, Category>();

        this.CreateMap<Customer, CustomerVM>();
        this.CreateMap<CustomerIM, Customer>();
        this.CreateMap<CustomerUM, Customer>();

        this.CreateMap<Product, ProductVM>();
        this.CreateMap<ProductIM, Product>();
        this.CreateMap<ProductUM, Product>();

        this.CreateMap<Sale, SaleVM>();
        this.CreateMap<SaleIM, Sale>();
        this.CreateMap<SaleUM, Sale>();
    }
}