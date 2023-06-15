using FoodOrdering.Enums;
using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(MyDbContext context) : base(context)
    {
    }

    public Order AddOrder(int userId, Cart cart)
    {
        var order = new Order
        {
            UserId = userId,
            Status = eOrderStatus.Unpaid,
            Address = string.Empty,
            DeliveryType = 0,
        };

        _context.Orders.Add(order);
        Save();

        // Map cart items to order items
        foreach (var item in cart.Items)
        {
            _context.OrderItems.Add(new OrderItem
            {
                OrderId = order.Id,
                FoodId = item.FoodId,
                Quantity = item.Quantity,
            });
        }

        return order;
    }
}