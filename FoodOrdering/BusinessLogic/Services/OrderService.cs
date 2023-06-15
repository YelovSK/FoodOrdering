using AutoMapper;
using FoodOrdering.BusinessLogic.DeliveryStrategy;
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

    public void AdvanceOrderStatus(int orderId)
    {
        var order = _orderRepository.GetById(orderId);
        if (order == null)
        {
            throw new FoodOrderingException("Order not found");
        }
        
        order.SetNextStatus();
        order.UpdateState();

        _orderRepository.Save();
    }

    public OrderDto AddOrder(int userId, Cart cart, eDeliveryType deliveryType)
    {
        var order = _orderRepository.AddOrder(userId, cart);
        IDeliveryStrategy strategy = deliveryType switch
        {
            eDeliveryType.HomeDelivery   => new HomeDelivery(),
            eDeliveryType.BranchDelivery => new BranchDelivery(),
            _                            => throw new FoodOrderingException("Delivery type not found")
        };
        new DeliveryService(order, strategy).Execute();
        _orderRepository.Save();
        
        return _mapper.Map<Order, OrderDto>(order);
    }

    public void PayOrder(int orderId, eOrderPaymentMethod paymentMethod)
    {
        var order = _orderRepository.GetById(orderId);
        if (order == null)
        {
            throw new FoodOrderingException("Order not found");
        }
        
        if (order.Status != eOrderStatus.Unpaid)
        {
            throw new FoodOrderingException("Order is already paid");
        }

        var notification = new Notification
        {
            UserId = order.UserId,
            SentDate = DateTime.UtcNow,
        };
        
        PaymentProcessor paymentProcessor = paymentMethod switch
        {
            eOrderPaymentMethod.OnlineBanking => new OnlineBankingPaymentProcessor(order, notification),
            eOrderPaymentMethod.BankTransfer  => new BankTransferPaymentProcessor(order, notification),
            _                                 => throw new FoodOrderingException("Unknown payment method")
        };
        
        paymentProcessor.ProcessPayment();
        
        _orderRepository.Save();
    }

    public OrderDto GetOrder(int id)
    {
        var order = _orderRepository.GetById(id);
        if (order == null)
        {
            throw new FoodOrderingException("Order not found");
        }
        
        return _mapper.Map<Order, OrderDto>(order);
    }

    public List<OrderDto> GetOrders(int userId)
    {
        var orders = _orderRepository.Find(i => i.UserId == userId);

        return _mapper.Map<List<Order>, List<OrderDto>>(orders.ToList());
    }
}