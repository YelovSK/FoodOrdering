using AutoMapper;
using FoodOrdering.Dto;
using FoodOrdering.Exceptions;
using FoodOrdering.Models;
using FoodOrdering.Repositories;

namespace FoodOrdering.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public CartService(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public CartDto GetCartByUserId(int userId)
    {
        var cart = _cartRepository.SingleOrDefault(i => i.UserId == userId);

        if (cart == null)
        {
            throw new FoodOrderingException("User not found");
        }

        return _mapper.Map<Cart, CartDto>(cart);
    }

    public void AddItemToCart(int userId, int foodId, int quantity)
    {
        var cart = _cartRepository.SingleOrDefault(i => i.UserId == userId);
        if (cart == null)
        {
            throw new FoodOrderingException("Cart not found");
        }

        var item = cart.Items.SingleOrDefault(i => i.FoodId == foodId);

        // Update quantity of existing food
        if (item != null)
        {
            item.Quantity = quantity;
        }
        // Add new food
        else
        {
            cart.Items.Add(new CartItem()
            {
                CartId = cart.Id,
                FoodId = foodId,
                Quantity = quantity,
            });
        }

        _cartRepository.Save();
    }

    public void RemoveItemFromCart(int userId, int foodId)
    {
        var cart = _cartRepository.SingleOrDefault(i => i.UserId == userId);
        if (cart == null)
        {
            throw new FoodOrderingException("Cart not found");
        }

        var item = cart.Items.SingleOrDefault(i => i.FoodId == foodId);
        if (item == null)
        {
            throw new FoodOrderingException("Item not found");
        }

        cart.Items.Remove(item);
        _cartRepository.Save();
    }
}