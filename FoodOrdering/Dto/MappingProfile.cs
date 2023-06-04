using AutoMapper;
using FoodOrdering.Models;

namespace FoodOrdering.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderDto>();
    }
}