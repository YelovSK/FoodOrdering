using FoodOrdering.Dto;
using FoodOrdering.Enums;
using FoodOrdering.Facades;
using FoodOrdering.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController : ControllerBase
{
    // Can't get mock identity user to work
    private const int USER_ID = 1;

    private readonly IOrderService _orderService;
    private readonly OrderingFacade _orderingFacade;

    public OrderController(IOrderService orderService, OrderingFacade orderingFacade)
    {
        _orderService = orderService;
        _orderingFacade = orderingFacade;
    }

    [HttpGet(Name = "GetOrders")]
    public List<OrderDto> GetOrders(bool onlyActive = false)
    {
        var orders = _orderService.GetOrders(USER_ID);
        if (onlyActive)
        {
            return orders.Where(o => o.Status != eOrderStatus.Delivered).ToList();
        }
    
        return orders;
    }

    [HttpPost]
    public OrderDto CreateOrder(eDeliveryType deliveryType)
    {
        return _orderingFacade.CreateOrder(USER_ID, deliveryType);
    }
    
    [HttpPost]
    public OrderDto PayOnlineBanking(int orderId)
    {
        _orderService.PayOrder(orderId, eOrderPaymentMethod.OnlineBanking);
        return _orderService.GetOrder(orderId);
    }

    [HttpPost]
    public OrderDto PayBankTransfer(int orderId)
    {
        _orderService.PayOrder(orderId, eOrderPaymentMethod.BankTransfer);
        return _orderService.GetOrder(orderId);
    }

    [HttpPost]
    public OrderDto Pay(int orderId, eOrderPaymentMethod paymentMethod)
    {
        _orderService.PayOrder(orderId, paymentMethod);
        return _orderService.GetOrder(orderId);
    }
    
    [HttpPost]
    public OrderDto AdvanceOrderStatus(int orderId)
    {
        _orderService.AdvanceOrderStatus(orderId);
        return _orderService.GetOrder(orderId);
    }
}