using FoodOrdering.Enums;
using FoodOrdering.Exceptions;
using FoodOrdering.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(MyDbContext context) : base(context)
    {
    }

    public void UpdateOrderStatus(int orderId, eOrderStatus status)
    {
        var order = _context.Orders.Find(orderId);
        if (order == null)
        {
            throw new FoodOrderingException("Order not found");
        }

        _context.Orders.Attach(order);
        order.Status = status;
        _context.Entry(order).State = EntityState.Modified;
    }

    public Order AddOrder(int userId, Cart cart)
    {
        var order = new Order
        {
            UserId = userId,
            Status = eOrderStatus.Unpaid,
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