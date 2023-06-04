using AutoMapper;
using FoodOrdering.Dto;
using FoodOrdering.Models;
using FoodOrdering.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderController(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    
    [HttpGet(Name = "GetAll")]
    public IEnumerable<OrderDto> GetAll()
    {
        var orders = _orderRepository.GetOrders().ToList();
        return _mapper.Map<List<Order>, List<OrderDto>>(orders);
    }
}