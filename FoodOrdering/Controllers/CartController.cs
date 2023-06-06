using FoodOrdering.Dto;
using FoodOrdering.Facades;
using FoodOrdering.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CartController : ControllerBase
{
    // Can't get mock identity user to work
    private const int USER_ID = 1;
    
    private readonly ICartService _cartService;
    private readonly OrderingFacade _orderingFacade;

    public CartController(OrderingFacade orderingFacade, ICartService cartService)
    {
        _orderingFacade = orderingFacade;
        _cartService = cartService;
    }
    
    [HttpGet]
    public CartDto GetCart()
    {
        return _cartService.GetCartByUserId(USER_ID);
    }
    
    [HttpPost(Name = "AddItemToCart")]
    public CartDto AddItemToCart(int foodId, int quantity)
    {
        // Add item if not in cart, updates quantity if in cart. Removes item if quantity == 0.
        _orderingFacade.AddFoodToCart(USER_ID, foodId, quantity);
        return _cartService.GetCartByUserId(USER_ID);
    }
}