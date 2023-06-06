using AutoMapper;
using FoodOrdering.Models;

namespace FoodOrdering.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<User, UserDto>();
        CreateMap<User, UserInfoDto>();
        CreateMap<UserDto, UserInfoDto>();
        CreateMap<Cart, CartDto>();
        CreateMap<CartItem, FoodItemDto>();
        CreateMap<OrderItem, FoodItemDto>();
        CreateMap<Food, FoodDto>();
    }
}