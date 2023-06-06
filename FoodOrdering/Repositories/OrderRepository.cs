using FoodOrdering.Enums;
using FoodOrdering.Exceptions;
using FoodOrdering.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Repositories;

public class OrderRepository : RepositoryBase, IOrderRepository
{
    public OrderRepository(MyDbContext context) : base(context)
    {
    }
    
    public IEnumerable<Order> GetOrders()
    {
        return _context.Orders.Include(i => i.User);
    }

    public IEnumerable<Order> GetOrders(int userId)
    {
        return _context.Orders.Include(i => i.User).Where(i => i.UserId == userId);
    }

    public Order? GetOrder(int id)
    {
        return _context.Orders.Find(id);
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

    public void DeleteOrder(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            throw new FoodOrderingException("Order not found");
        }

        _context.Orders.Remove(order);
    }
}