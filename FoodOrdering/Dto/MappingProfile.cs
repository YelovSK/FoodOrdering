using AutoMapper;
using FoodOrdering.Models;

namespace FoodOrdering.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderDto>().ForMember(
            dest => dest.DeliveryType,
            opt => opt.MapFrom(src => src.DeliveryType.ToString())
        );
        CreateMap<User, FullUserDto>();
        CreateMap<User, UserDto>();
        CreateMap<FullUserDto, UserDto>();
        CreateMap<Cart, CartDto>();
        CreateMap<CartItem, FoodItemDto>();
        CreateMap<OrderItem, FoodItemDto>();
        CreateMap<Food, FoodDto>();
        CreateMap<Notification, NotificationDto>();
    }
}