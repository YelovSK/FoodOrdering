using FoodOrdering.Models;

namespace FoodOrdering.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly MyDbContext _context;

    public OrderRepository(MyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> GetOrders()
    {
        return _context.Orders;
    }

    public Order GetOrder(int id)
    {
        return _context.Orders.Find(id);
    }

    public void AddOrder(Order order)
    {
        _context.Orders.Add(order);
    }

    public void DeleteOrder(int id)
    {
        var order = _context.Orders.Find(id);
        _context.Orders.Remove(order);
    }

    public void Save() => _context.SaveChanges();
}