using AutoMapper;
using FoodOrdering.Dto;
using FoodOrdering.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    // Can't get mock identity user to work
    private const int USER_ID = 1;
    
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public UserDto Get()
    {
        var user = _userService.GetUser(USER_ID);
        return _mapper.Map<UserDto>(user);
    }

    [HttpGet]
    public FullUserDto GetWithOrders()
    {
        return _userService.GetUser(USER_ID);
    }
    
    [HttpPost]
    public FullUserDto UpdateEmail(string email)
    {
        _userService.UpdateEmail(USER_ID, email);
        return _userService.GetUser(USER_ID);
    }
}