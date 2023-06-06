using FoodOrdering.Exceptions;
using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public class CartRepository : RepositoryBase, ICartRepository
{
    public CartRepository(MyDbContext context) : base(context)
    {
    }

    public Cart? GetCartByUserId(int userId)
    {
        return _context.Carts.SingleOrDefault(i => i.UserId == userId);
    }

    public void AddFoodToCart(int cartId, int foodId, int quantity)
    {
        var cart = _context.Carts.SingleOrDefault(i => i.Id == cartId);
        if (cart == null)
        {
            throw new FoodOrderingException("Cart not found");
        }
        
        var item = _context.CartItems.SingleOrDefault(i => i.FoodId == foodId && i.CartId == cartId);

        // Update quantity of existing food
        if (item != null)
        {
            item.Quantity = quantity;
        }
        // Add new food
        else
        {
            _context.CartItems.Add(new CartItem
            {
                CartId = cartId,
                FoodId = foodId,
                Quantity = quantity,
            });
        }
    }

    public void RemoveItem(int itemFoodId, int itemCartId)
    {
        _context.CartItems.Remove(new CartItem
        {
            FoodId = itemFoodId,
            CartId = itemCartId,
        });
    }
}