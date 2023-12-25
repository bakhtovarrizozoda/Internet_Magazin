using AutoMapper;
using Domain.Dtos.Category;
using Domain.Dtos.Customers;
using Domain.Dtos.Order;
using Domain.Dtos.OrderDetail;
using Domain.Dtos.Product;
using Domain.Dtos.User.UserDto;
using Domain.Entities;

namespace Infrastructure.AutomapperProfile;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Customers, GetCustomerDto>().ReverseMap();
        CreateMap<AddCustomerDto, Customers>().ReverseMap();

        CreateMap<Orders, GetOrderDto>().ReverseMap();
        CreateMap<AddOrderDto, Orders>().ReverseMap();

        CreateMap<Products, GetProductDto>().ReverseMap();
        CreateMap<AddProductDto, Products>().ReverseMap();

        CreateMap<OrderDetail, GetOrderDetailDto>().ReverseMap();
        CreateMap<AddOrderDetailDto, OrderDetail>().ReverseMap();

        CreateMap<Category, GetCategoryDto>().ReverseMap();
        CreateMap<AddCategoryDto, Category>().ReverseMap();

        CreateMap<User, GetAllUserDto>().ReverseMap();
    }
    
}