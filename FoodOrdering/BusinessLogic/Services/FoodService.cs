using AutoMapper;
using FoodOrdering.Dto;
using FoodOrdering.Exceptions;
using FoodOrdering.Models;
using FoodOrdering.Repositories;

namespace FoodOrdering.Services;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;
    private readonly IMapper _mapper;

    public FoodService(IFoodRepository foodRepository, IMapper mapper)
    {
        _foodRepository = foodRepository;
        _mapper = mapper;
    }
    
    public FoodDto GetFood(int foodId)
    {
        var food = _foodRepository.GetById(foodId);
        if (food == null)
        {
            throw new FoodOrderingException("Food not found");
        }
        
        return _mapper.Map<Food, FoodDto>(food);
    }
}