using AutoMapper;
using FoodOrdering.Dto;
using FoodOrdering.Enums;
using FoodOrdering.Exceptions;
using FoodOrdering.Models;
using FoodOrdering.Repositories;

namespace FoodOrdering.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public void UpdateOrderStatus(int orderId, eOrderStatus status)
    {
        var order = _orderRepository.GetOrder(orderId);
        
        if (order == null)
        {
            throw new FoodOrderingException("Order not found");
        }
        
        // Update the order status
        order.Status = status;
        _orderRepository.UpdateOrderStatus(orderId, status);
        _orderRepository.Save();
    }

    public void AdvanceOrderStatus(int orderId)
    {
        var order = _orderRepository.GetOrder(orderId);
        if (order == null)
        {
            throw new FoodOrderingException("Order not found");
        }
        
        switch (order.Status)
        {
            case eOrderStatus.Unpaid:
                UpdateOrderStatus(orderId, eOrderStatus.Paid);
                break;
            case eOrderStatus.Paid:
                UpdateOrderStatus(orderId, eOrderStatus.Rejected);
                break;
            case eOrderStatus.Rejected:
                UpdateOrderStatus(orderId, eOrderStatus.Delivered);
                break;
            case eOrderStatus.Delivered:
                throw new FoodOrderingException("Order already delivered");
            default:
                throw new FoodOrderingException("Unknown order status");
        }
    }

    public OrderDto AddOrder(int userId, Cart cart)
    {
        var order = _orderRepository.AddOrder(userId, cart);
        _orderRepository.Save();
        
        return _mapper.Map<Order, OrderDto>(order);
    }

    public void PayOrder(int orderId)
    {
        var order = _orderRepository.GetOrder(orderId);
        if (order == null)
        {
            throw new FoodOrderingException("Order not found");
        }
        
        if (order.Status != eOrderStatus.Unpaid)
        {
            throw new FoodOrderingException("Order is already paid");
        }
        
        UpdateOrderStatus(orderId, eOrderStatus.Paid);
    }

    public OrderDto GetOrder(int id)
    {
        var order = _orderRepository.GetOrder(id);
        if (order == null)
        {
            throw new FoodOrderingException("Order not found");
        }
        
        return _mapper.Map<Order, OrderDto>(order);
    }

    public List<OrderDto> GetOrders(int userId)
    {
        var orders = _orderRepository.GetOrders(userId);

        return _mapper.Map<List<Order>, List<OrderDto>>(orders.ToList());
    }
}