using AutoMapper;
using EFCoreAssignment.DTOs;
using EFCoreAssignment.Data.Models;

namespace EFCoreAssignment.API
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<OrderDetailDTO, OrderDetail>();
                cfg.CreateMap<ProductDTO, Product>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}