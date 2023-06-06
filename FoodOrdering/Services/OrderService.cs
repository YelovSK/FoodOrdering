using AutoMapper;
using FoodOrdering.BusinessLogic.OrderState;
using FoodOrdering.BusinessLogic.PaymentProcessor;
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
        
        var context = new OrderContext(OrderContext.GetState(order.Status));
        context.SetNextStatus();
        
        UpdateOrderStatus(orderId, context.OrderStatus);
    }

    public OrderDto AddOrder(int userId, Cart cart)
    {
        var order = _orderRepository.AddOrder(userId, cart);
        _orderRepository.Save();
        
        return _mapper.Map<Order, OrderDto>(order);
    }

    public void PayOrder(int orderId, eOrderPaymentMethod paymentMethod)
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
        
        PaymentProcessor paymentProcessor = paymentMethod switch
        {
            eOrderPaymentMethod.OnlineBanking => new OnlineBankingPaymentProcessor(order),
            eOrderPaymentMethod.BankTransfer  => new BankTransferPaymentProcessor(order),
            _                                 => throw new FoodOrderingException("Unknown payment method")
        };
        
        order = paymentProcessor.ProcessPayment();
        
        UpdateOrderStatus(order.Id, order.Status);
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