using FoodOrdering.BusinessLogic.DeliveryStrategy;
using FoodOrdering.Dto;
using FoodOrdering.Enums;
using FoodOrdering.Exceptions;
using FoodOrdering.Repositories;
using FoodOrdering.Services;

namespace FoodOrdering.Facades;

public class OrderingFacade
{
    private readonly IOrderService _orderService;
    private readonly ICartService _cartService;
    private readonly IFoodService _foodService;
    private readonly ICartRepository _cartRepository;
    
    public OrderingFacade(IOrderService orderService, ICartService cartService, IFoodService foodService, ICartRepository cartRepository)
    {
        _orderService = orderService;
        _cartService = cartService;
        _foodService = foodService;
        _cartRepository = cartRepository;
    }

    public OrderDto CreateOrder(int userId, eDeliveryType deliveryType)
    {
        var cart = _cartRepository.SingleOrDefault(i => i.UserId == userId);
        if (cart == null)
        {
            throw new FoodOrderingException("Cart not found");
        }

        return _orderService.AddOrder(userId, cart, deliveryType);
    }
    
    public void AddFoodToCart(int userId, int foodId, int quantity)
    {
        if (quantity < 0)
        {
            throw new FoodOrderingException("Quantity cannot be negative");
        }

        // Delete
        if (quantity == 0)
        {
            _cartService.RemoveItemFromCart(userId, foodId);
            return;
        }
        
        var cart = _cartService.GetCartByUserId(userId);
        if (cart == null)
        {
            throw new FoodOrderingException("Cart not found");
        }
        
        var food = _foodService.GetFood(foodId);
        if (food == null)
        {
            throw new FoodOrderingException("Food not found");
        }
        
        _cartService.AddItemToCart(userId, foodId, quantity);
    }
}