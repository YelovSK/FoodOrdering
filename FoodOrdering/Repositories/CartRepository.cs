using FoodOrdering.Exceptions;
using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(MyDbContext context) : base(context)
    {
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

    public void RemoveItemFromCart(int cartId, int foodId)
    {
        var item = _context.CartItems.SingleOrDefault(i => i.FoodId == foodId && i.CartId == cartId);
        if (item == null)
        {
            throw new FoodOrderingException("Item not found");
        }
        
        _context.CartItems.Remove(item);
    }
}