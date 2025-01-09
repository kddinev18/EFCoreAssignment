using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using JSON1.Domain.Entities;
using JSON1.Application.Mapping.GetDtos;
using JSON1.Application.Mapping.PutDtos;

namespace JSON1.Application.Mapping
{
    public static class MappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<User, UserGetDto>.NewConfig();
            TypeAdapterConfig<User, UserPutDto>.NewConfig();
            TypeAdapterConfig<Product, ProductGetDto>.NewConfig();
            TypeAdapterConfig<Product, ProductPutDto>.NewConfig();
            TypeAdapterConfig<Order, OrderGetDto>.NewConfig();
            TypeAdapterConfig<Order, OrderPutDto>.NewConfig();
            TypeAdapterConfig<OrderDetails, OrderDetailsGetDto>.NewConfig();
            TypeAdapterConfig<OrderDetails, OrderDetailsPutDto>.NewConfig();
        }
    }
}
