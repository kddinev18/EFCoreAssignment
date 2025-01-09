using AutoMapper;
using EFCoreAssignment.DataAccess.Models;
using EFCoreAssignment.Domain.Models.Order;
using EFCoreAssignment.Domain.Models.OrderDetail;
using EFCoreAssignment.Domain.Models.Product;
using EFCoreAssignment.Domain.Models.User;

namespace EFCoreAssignment.BusinessLogic;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<CreateUser, User>();
        CreateMap<User, ResponseUser>();
        CreateMap<UpdateUser, User>();

        CreateMap<CreateOrder, Order>();
        CreateMap<Order, ResponseOrder>();
        CreateMap<UpdateOrder, Order>();

        CreateMap<CreateOrderDetail, OrderDetail>();
        CreateMap<OrderDetail, ResponseOrderDetail>();
        CreateMap<UpdateOrderDetail, OrderDetail>();
        
        CreateMap<CreateProduct, Product>();
        CreateMap<Product, ResponseProduct>();
        CreateMap<UpdateProduct, Product>();
    }
}